using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zkhwClient.view
{
    public partial class resident_diseases : Form
    {

        public string disease_name = "";
        public string disease_date = "";
        public resident_diseases()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void follow_medicine_record_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disease_name = this.comboBox1.Text;
            disease_date = this.dateTimePicker1.Text;
            this.DialogResult = DialogResult.OK;

        }
    }
}
