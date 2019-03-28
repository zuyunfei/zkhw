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
    public partial class more0 : Form
    {
        public more0()
        {
            InitializeComponent();
        }
        public string advice = "";
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.panel1.Controls)
            {
                //判断该控件是不是CheckBox
                if (ctr is CheckBox)
                {
                    //将ctr转换成CheckBox并赋值给ck
                    CheckBox ck = ctr as CheckBox;
                    if (ck.Checked)
                    {
                        advice += "," + ck.Text;
                    }
                }
            }
            if (advice != null && advice != "")
            {
                advice = advice.Substring(1);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
