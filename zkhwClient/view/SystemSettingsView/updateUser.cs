using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zkhwClient
{
    public partial class updateUser : Form
    {
        public updateUser()
        {
            InitializeComponent();
        }

        private void updateUser_Load(object sender, EventArgs e)
        {
            string str = Application.StartupPath;//项目路径
            this.button1.BackgroundImage = Image.FromFile(@str + "/images/update.png");
            this.button2.BackgroundImage = Image.FromFile(@str + "/images/cancel.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //屏蔽双击
        protected override void DefWndProc(ref Message m)
        {
            byte msg = 0x00A3;
            if (m.Msg == Convert.ToInt32(msg))
            {
                return;
            }
            base.DefWndProc(ref m);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = this.textBox2.Text;
            string name = this.textBox1.Text;
            if (name != null && !"".Equals(name))
            {
                if (name == "admin") { MessageBox.Show("管理员账号不能被修改！"); }
                else
                {
                    bean.UserInfo ui = new bean.UserInfo();
                    ui.Id = id;
                    ui.UserName = name;
                    service.UserService us = new service.UserService();
                    bool istrue = us.updateUser(ui);
                    if (istrue)
                    {
                        this.Hide();
                        this.DialogResult = DialogResult.OK;
                    }

                }
            }
        }
    }
}
