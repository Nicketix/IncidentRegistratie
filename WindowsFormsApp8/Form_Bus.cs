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
    public partial class Form_Bus : Form
    {
        public Form_Bus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Form_Bus_A_v2 FBA = new Form_Bus_A_v2())
            {
                FBA.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
