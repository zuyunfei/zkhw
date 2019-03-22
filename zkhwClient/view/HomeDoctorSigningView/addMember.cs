using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zkhwClient.dao;

namespace zkhwClient.view.HomeDoctorSigningView
{
    public partial class addMember : Form
    {
        public string FID { get; set; }
        public addMember()
        {
            InitializeComponent();
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string name = 姓名.Text;
            string zhiwu = 职务.Text;
            string lianxifangs = 联系方式.Text;
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(zhiwu) && !string.IsNullOrWhiteSpace(lianxifangs))
            {
                foreach (Control ctrl in groupBox1.Controls)
                {
                    if (ctrl is RadioButton)
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            str = ctrl.Text;

                        }
                    }
                }
                string sql = $"select COUNT(id) from zkhw_qy_tdcy where FuID='{FID}' and ZhiWei='{str}'";
                bool zw = DbHelperMySQL.Exists(sql);
                if (zw)
                {
                    MessageBox.Show("此团队已存在队长！");
                    return;
                }
                else
                {
                    string issql = "insert into zkhw_qy_tdcy(id,FuID,ZhiWei,ZhiWu,XingMing,LianXiFangShi) values(@id,@FuID,@ZhiWei,@ZhiWu,@XingMing,@LianXiFangShi)";
                    MySqlParameter[] args = new MySqlParameter[] {
                    new MySqlParameter("@id",Result.GetNewId()),
                    new MySqlParameter("@FuID", FID),
                    new MySqlParameter("@ZhiWei", str),
                    new MySqlParameter("@ZhiWu", zhiwu),
                    new MySqlParameter("@XingMing", name),
                    new MySqlParameter("@LianXiFangShi", lianxifangs)
                };
                    int rue = DbHelperMySQL.ExecuteSql(issql, args);
                    if (rue > 0)
                    {
                        MessageBox.Show("创建成功！");
                    }
                }

            }
            else
            {
                MessageBox.Show("请输入完整信息！");
            }
        }
    }
}
