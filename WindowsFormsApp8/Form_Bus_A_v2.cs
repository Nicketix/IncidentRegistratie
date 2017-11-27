using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form_Bus_A_v2 : Form
    {
        public Form_Bus_A_v2()
        {
            InitializeComponent();

            //Systeemtijd
            label26.Text = DateTime.Now.ToString();

            //Nu komt er een stukje om de  comboboxes bij stap 3 te vullen -- TIJDELIJK
            comboBox4.Items.Add("Hans Andela");
            comboBox4.Items.Add("Pieter Storm");
            comboBox4.Items.Add("Thymen Berger");
            

            comboBox5.Items.Add("612");

            comboBox6.Items.Add("8655");

            comboBox7.Items.Add("Leeuwarden, Busstation");
            comboBox7.Items.Add("Leeuwarden, Zaailand");
            comboBox7.Items.Add("Leeuwarden, Harmonie");
            comboBox7.Items.Add("Leeuwarden, Wissesdwinger");
            comboBox7.Items.Add("Leeuwarden, Stenden Hogeschool");
            comboBox7.Items.Add("Leeuwarden, NHL Hogeschool");

            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;

            listBox2.Items.Add("Leeuwarden, Busstation");
            listBox2.Items.Add("Leeuwarden, Zaailand");
            listBox2.Items.Add("Leeuwarden, Harmonie");
            listBox2.Items.Add("Leeuwarden, Wissesdwinger");
            listBox2.Items.Add("Leeuwarden, Stenden Hogeschool");
            listBox2.Items.Add("Leeuwarden, NHL Hogeschool");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox2.Enabled = true;
            }
            else if (!checkBox2.Checked)
            {
                comboBox2.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                comboBox3.Enabled = true;
            }
            else if (!checkBox3.Checked)
            {
                comboBox3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) //Stap 1: Volgende >>
        {
            tableLayoutPanel6.Enabled = false;
            tableLayoutPanel7.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //Stap 2: Ja-button
        {
            if (radioButton2.Checked)
            {
                tableLayoutPanel9.Enabled = true;
            }
            else if (!radioButton2.Checked)
            {
                tableLayoutPanel9.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e) //Stap 2: << Vorige
        {
            tableLayoutPanel6.Enabled = true;
            tableLayoutPanel7.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e) //Stap 2: Volgende >>
        {
            tableLayoutPanel7.Enabled = false;
            tableLayoutPanel17.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e) //Stap 3: << Vorige
        {
            tableLayoutPanel7.Enabled = true;
            tableLayoutPanel17.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e) //Stap 3: Volgende >>
        {
            tableLayoutPanel17.Enabled = false;
            tableLayoutPanel21.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e) //Stap 4: << Vorige
        {
            tableLayoutPanel17.Enabled = true;
            tableLayoutPanel21.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e) //Stap 4: Volgende >>
        {
            tableLayoutPanel21.Enabled = false;
        }
    }
}
