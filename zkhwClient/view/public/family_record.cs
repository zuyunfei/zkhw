﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zkhwClient.view
{
    public partial class family_record : Form
    {

        public string relation = "";
        public string disease_name = "";
        public family_record()
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
            relation = this.comboBox1.Text;
            foreach (Control ctr in this.panel1.Controls)
            {
                //判断该控件是不是CheckBox
                if (ctr is CheckBox)
                {
                    //将ctr转换成CheckBox并赋值给ck
                    CheckBox ck = ctr as CheckBox;
                    if (ck.Checked)
                    {
                        disease_name += "," + ck.Text;
                    }
                }
            }
            if (disease_name != null && disease_name != "")
            {
                disease_name = disease_name.Substring(1);
            }
            this.DialogResult = DialogResult.OK;

        }
    }
}
