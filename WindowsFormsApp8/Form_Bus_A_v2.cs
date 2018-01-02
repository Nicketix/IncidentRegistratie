using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace WindowsFormsApp8
{
    public partial class Form_Bus_A_v2 : Form
    {
        string sqlMainQuery = "null";

        public Form_Bus_A_v2()
        {
            InitializeComponent();
            textBox1.Select();

            //Systeemtijd
            label26.Text = DateTime.Now.ToString();

            //Nu komt er een stukje om de  comboboxes bij stap 3 te vullen -- TIJDELIJK
            comboBox4.Items.Add("Hans Andela");
            comboBox4.Items.Add("Pieter Storm");
            comboBox4.Items.Add("Thymen Berger");
            

            comboBox5.Items.Add("612");

            comboBox6.Items.Add("8655");

            comboBox7.Items.Add("2");

            comboBox8.Items.Add("Leeuwarden, Busstation");
            comboBox8.Items.Add("Leeuwarden, Zaailand");
            comboBox8.Items.Add("Leeuwarden, Harmonie");
            comboBox8.Items.Add("Leeuwarden, Wissesdwinger");
            comboBox8.Items.Add("Leeuwarden, Stenden Hogeschool");
            comboBox8.Items.Add("Leeuwarden, NHL Hogeschool");

            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;

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
            button4_Click(this, new EventArgs());
            textBox1.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                IncidentCombobox2.Enabled = true;
            }
            else if (!checkBox2.Checked)
            {
                IncidentCombobox2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) //Stap 1: Volgende >>
        {
            tableLayoutPanel6.Enabled = false;
            tableLayoutPanel7.Enabled = true;
            string categorie = IncidentCombobox1.Text;
            if (categorie.StartsWith("SV") )
            {
                tableLayoutPanel24.Visible = true;
            }
            else if(categorie.StartsWith("MT"))
            {
                tableLayoutPanel24.Visible = false;
            }
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

        private void Form_Bus_A_v2_Load(object sender, EventArgs e)
        {
            
        }

        private DataTable GetIncidentenTagsList()
        {
            DataTable dtIncidentenTags = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(connString))
            {
                using (OleDbCommand cmd = new OleDbCommand(sqlMainQuery, con))
                {
                    con.Open();

                    OleDbDataReader reader = cmd.ExecuteReader();

                    dtIncidentenTags.Load(reader);

                    IncidentCombobox1.DisplayMember = "Incident_naam";
                    IncidentCombobox2.DisplayMember = "Incident_naam";
                }
            }
            return dtIncidentenTags;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var list = new List<string>();
            int i = 0;
            foreach (var item in listBox1.Items)
            {
                list.Add(item.ToString());
                i++;
            }

            if (i == 0)
            {
                sqlMainQuery = "SELECT Incident_naam, COUNT(*) AS num_count FROM Incidenttags";
            }
            else if (i == 1)
            {
                sqlMainQuery = "SELECT Incident_naam, COUNT(*) AS num_count FROM Incidenttags WHERE Tag_naam = '" + list[0] + "' GROUP BY Incident_naam ORDER BY 2 DESC";
            }

            else if (i == 2)
            {
                sqlMainQuery = "SELECT Incident_naam, COUNT(*) AS num_count FROM Incidenttags WHERE Tag_naam = '" + list[0] + "' OR Tag_naam = '" + list[1] + "' GROUP BY Incident_naam ORDER BY 2 DESC";
            }

            else if (i == 3)
            {
                sqlMainQuery = "SELECT Incident_naam, COUNT(*) AS num_count FROM Incidenttags WHERE Tag_naam = '" + list[0] + "' OR Tag_naam = '" + list[1] + "' OR Tag_naam = '" + list[2] + "' GROUP BY Incident_naam ORDER BY 2 DESC";
            }

            else if (i == 4)
            {
                sqlMainQuery = "SELECT Incident_naam, COUNT(*) AS num_count FROM Incidenttags WHERE Tag_naam = '" + list[0] + "' OR Tag_naam = '" + list[1] + "' OR Tag_naam = '" + list[2] + "' OR Tag_naam = '" + list[3] + "' GROUP BY Incident_naam ORDER BY 2 DESC";
            }

            else if (i == 5)
            {
                sqlMainQuery = "SELECT Incident_naam, COUNT(*) AS num_count FROM Incidenttags WHERE Tag_naam = '" + list[0] + "' OR Tag_naam = '" + list[1] + "' OR Tag_naam = '" + list[2] + "' OR Tag_naam = '" + list[3] + "' OR Tag_naam = '" + list[4] + "' GROUP BY Incident_naam ORDER BY 2 DESC";
            }

            IncidentCombobox1.DataSource = GetIncidentenTagsList();
            IncidentCombobox2.DataSource = GetIncidentenTagsList();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }
    }
}
