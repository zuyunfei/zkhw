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
    public partial class addTeamMembers : Form
    {
        public addTeamMembers()
        {
            InitializeComponent();
        }

        private void 取消_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 确定_Click(object sender, EventArgs e)
        {
            string tdname = 团队名称.Text;
            if (!string.IsNullOrWhiteSpace(tdname))
            {
                string sql = "insert into zkhw_qy_tdcy(id,TuanDuiMingCheng,createtime) values(@id,@TuanDuiMingCheng,@createtime)";
                MySqlParameter[] args = new MySqlParameter[] {
                    new MySqlParameter("@id",Result.GetNewId()),
                    new MySqlParameter("@TuanDuiMingCheng", tdname),
                    new MySqlParameter("@createtime", DateTime.Now)
                };
                int rue = DbHelperMySQL.ExecuteSql(sql, args);
                if (rue > 0)
                {
                    MessageBox.Show("创建成功！");
                }
            }
            else
            {
                MessageBox.Show("请输入团队名称！");
            }
        }
    }
}
