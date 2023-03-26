using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Text.Json;
using System.Runtime.Serialization.Json;

namespace WindowsFormsApp6
{
    [Serializable]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo directory = new DirectoryInfo(FBD.SelectedPath);
                FileInfo[] files = directory.GetFiles();
                List<Files> list = new List<Files>();
                BinaryFormatter bf = new BinaryFormatter();
                for (int i = 0; i < files.Length; i++)
                {
                    Files file = new Files(files[i].Name, files[i].Length, files[i].LastWriteTime, files[i].Attributes);
                    list.Add(file);
                }
                using (FileStream fstream = new FileStream("resultX.bin", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    bf.Serialize(fstream, list);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo directory = new DirectoryInfo(FBD.SelectedPath);
                FileInfo[] files = directory.GetFiles();
                List<Files> list = new List<Files>();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Files>)); 
                for (int i = 0; i < files.Length; i++)
                {
                    Files file = new Files(files[i].Name, files[i].Length, files[i].LastWriteTime, files[i].Attributes);
                    list.Add(file);
                }
                using (FileStream fstream = new FileStream("resultX.xml", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlSerializer.Serialize(fstream, list);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo directory = new DirectoryInfo(FBD.SelectedPath);
                FileInfo[] files = directory.GetFiles();
                List<Files> list = new List<Files>();
                var json = new DataContractJsonSerializer(typeof(List<Files>));
                for (int i = 0; i < files.Length; i++)
                {
                    Files file = new Files(files[i].Name, files[i].Length, files[i].LastWriteTime, files[i].Attributes);
                    list.Add(file);
                }
                using (FileStream fstream = new FileStream("resultX.json", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    json.WriteObject(fstream, list);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fstream = File.OpenRead("resultX.bin"))
            {
                List<Files> files = (List<Files>)bf.Deserialize(fstream);
                foreach(Files file in files)
                {
                    listBox1.Items.Add(file.Name);
                    listBox1.Items.Add(file.Length);
                    listBox1.Items.Add(file.LastWriteTime);
                    listBox1.Items.Add(file.Attributes);
                    listBox1.Items.Add(" ");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Files>));
            using (FileStream fstream = File.OpenRead("resultX.xml"))
            {
                List<Files> files = (List<Files>)xmlSerializer.Deserialize(fstream);
                foreach (Files file in files)
                {
                    listBox1.Items.Add(file.Name);
                    listBox1.Items.Add(file.Length);
                    listBox1.Items.Add(file.LastWriteTime);
                    listBox1.Items.Add(file.Attributes);
                    listBox1.Items.Add(" ");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var json = new DataContractJsonSerializer(typeof(List<Files>));
            using (FileStream fstream = File.OpenRead("resultX.json"))
            {
                List<Files> files = (List<Files>)json.ReadObject(fstream);
                foreach (Files file in files)
                {
                    listBox1.Items.Add(file.Name);
                    listBox1.Items.Add(file.Length);
                    listBox1.Items.Add(file.LastWriteTime);
                    listBox1.Items.Add(file.Attributes);
                    listBox1.Items.Add(" ");
                }
            }
        }
    }
    [Serializable]
    public class Files
    {
        public string Name;
        public long Length;
        public DateTime LastWriteTime;
        public FileAttributes Attributes;
        public Files() { }
        public Files(string Name, long Length, DateTime LastWriteTime, FileAttributes Attributes)
        {
            this.Name = Name;
            this.Length = Length;
            this.LastWriteTime = LastWriteTime;
            this.Attributes = Attributes;
        }
    }
}
