using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zkhwClient.view.PublicHealthView
{
    public partial class personRegist : Form
    {
        public personRegist()
        {
            InitializeComponent();
        }

        private void personRegist_Load(object sender, EventArgs e)
        {
            this.label1.Text = "居民健康档案登记";
            this.label1.ForeColor = Color.SkyBlue;
            label1.Font = new Font("微软雅黑", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
            label1.Left = (this.panel1.Width - this.label1.Width) / 2;
            label1.BringToFront();

            this.label13.Text = "登记记录";
            this.label13.ForeColor = Color.SkyBlue;
            label13.Font = new Font("微软雅黑", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
            label13.Left = (this.panel4.Width - this.label13.Width) / 2;
            label13.BringToFront();

            string str = Application.StartupPath;//项目路径   
            this.pictureBox1.Image = Image.FromFile(@str + "/images/身份证样图.png");
        }
    }
}
