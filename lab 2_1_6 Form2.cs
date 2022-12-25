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
    public partial class Form2 : Form
    {
        public Software software;
        string software1;
        public Form2()
        {
            InitializeComponent();
            label6.Visible = false;
            maskedTextBox1.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (software1 == "OS")
            {
                software = new OS(textBox1.Text, textBox4.Text,int.Parse(textBox2.Text), double.Parse(textBox3.Text), int.Parse(maskedTextBox1.Text));
            }
            else if (software1 == "Applied")
            {
                software = new Applied(textBox1.Text, textBox4.Text, int.Parse(textBox2.Text), double.Parse(textBox3.Text), int.Parse(maskedTextBox1.Text));
            }
            else
            {
                software = new Service(textBox1.Text, textBox4.Text, int.Parse(textBox2.Text), double.Parse(textBox3.Text), int.Parse(maskedTextBox1.Text));
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            software1 = comboBaox1.Items[comboBox1.SelectedIndex].ToString();
            if (software1 != null)
            {
                label6.Visible = true;
                maskedTextBox1.Visible=true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }
    }
}
