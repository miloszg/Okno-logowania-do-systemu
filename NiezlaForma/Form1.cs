using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiezlaForma
{
    public partial class Form1 : Form
    {
        public string imie;
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            richTextBox1.Enabled = false;
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            imie = textBox1.Text;
            StringBuilder sb = new StringBuilder("Pan(i) ");
            DateTime d = new DateTime(2000, 6, 5);
            if (dateTimePicker1.Value < d)
            {                
                sb.Append(textBox1.Text);
                textBox1.Text = Convert.ToString(sb);
            }
            else
            {
                //do nothing
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //HASŁO haslo
            if (textBox3.Text == "haslo")
            { groupBox1.Enabled = true; }
            else
            { groupBox1.Enabled = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            s.Append("Narodowosc: " + comboBox1.SelectedItem.ToString() + "\n");
            s.Append("Imie: " + textBox1.Text + "\n");
            s.Append("Nazwisko: " + textBox2.Text + "\n");
            s.Append("Data urodzin: " + Convert.ToString(dateTimePicker1.Value) + "\n");

            using (StreamWriter ff = new StreamWriter("TestFile.txt"))
            {
                ff.Write(s);
            }
            richTextBox1.Enabled = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int wystapienia = 0;
            string slowa = richTextBox1.Text;
            
            string[] split = slowa.Split(new Char[] { ' ', ',', '.', ':', '\t','\n' });

            foreach (string s in split)
            {
                if (s==imie)
                    wystapienia++;
            }
            toolStripStatusLabel1.Text = "Ilość wystapień: " + wystapienia;
        }
    }
}
