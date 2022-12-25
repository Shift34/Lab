using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp8;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        SoftwareContainer<Software> softwareContainer = new SoftwareContainer<Software>();
        public Form1()
        {
            InitializeComponent();
            softwareContainer.Add(new OS("Windows 10", "Microsoft", 2019,200, 30000));
            softwareContainer.Add(new Applied("Windows 10", "Microsoft", 2018, 199, 30000));
            softwareContainer.Add(new Service("Windows 10", "Microsoft", 2017, 198, 30000));
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            if (form.ShowDialog() == DialogResult.OK)
            {
                softwareContainer.Add(form.software);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoftwareSortedList.Items.Clear();
            foreach (var Software in softwareContainer)
            {
                SoftwareSortedList.Items.Add(Software);
            }
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = new List<Software>();
            List<Software> software;
            software = softwareContainer.ToList();
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString()=="Name")
            {
                int i = int.Parse(maskedTextBox1.Text);
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == ">")
                {
                    result = software.FindAll(t => t.Name.Length > i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "<")
                {
                    result = software.FindAll(t => t.Name.Length < i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "=")
                {
                    result = software.FindAll(t => t.Name.Length == i);
                }
            }
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Developer")
            {
                int i = int.Parse(maskedTextBox1.Text);
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == ">")
                {
                    result = software.FindAll(t => t.Developer.Length > i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "<")
                {
                    result = software.FindAll(t => t.Developer.Length < i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "=")
                {
                    result = software.FindAll(t => t.Developer.Length == i);
                }
            }
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Price")
            {
                int i = int.Parse(maskedTextBox1.Text);
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == ">")
                {
                    result = software.FindAll(t => t.Price > i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "<")
                {
                    result = software.FindAll(t => t.Price < i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "=")
                {
                    result = software.FindAll(t => t.Price == i);
                }
            }
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "Year")
            {
                int i = int.Parse(maskedTextBox1.Text);
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == ">")
                {
                    result = software.FindAll(t => t.Year > i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "<")
                {
                    result = software.FindAll(t => t.Year < i);
                }
                if (comboBox2.Items[comboBox2.SelectedIndex].ToString() == "=")
                {
                    result = software.FindAll(t => t.Year == i);
                }
            }
            SoftwareSortedList.Items.Clear();
            foreach (var Software in result)
            {
                SoftwareSortedList.Items.Add(Software);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
