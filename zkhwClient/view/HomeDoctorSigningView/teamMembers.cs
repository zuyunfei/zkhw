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
    public partial class teamMembers : Form
    {
        public teamMembers()
        {
            InitializeComponent();
            ComboBoxBin();
        }

        private void 新建团队_Click(object sender, EventArgs e)
        {
            addTeamMembers addTeam = new addTeamMembers();
            addTeam.StartPosition = FormStartPosition.CenterScreen;
            addTeam.ShowDialog();
        }

        private void ComboBoxBin()
        {
            string sql = "select ID,TuanDuiMingCheng from zkhw_qy_tdcy where TuanDuiMingCheng is not null";
            DataSet datas = DbHelperMySQL.Query(sql);
            if (datas != null && datas.Tables.Count > 0)
            {
                List<TDMC> ts = Result.ToDataList<TDMC>(datas.Tables[0]);
                Result.Bind(comboBox1, ts, "TuanDuiMingCheng", "ID", "--请选择--");
            }
        }

        private void GroupBoxBin(string fid)
        {
            while (groupBox1.Controls.Count != 0)
            {
                groupBox1.Controls.Clear();
                groupBox1.Dispose();
            }
            string sql = $"select id,ZhiWei,ZhiWu,XingMing,LianXiFangShi from zkhw_qy_tdcy where FID='{fid}'";
            DataSet datas = DbHelperMySQL.Query(sql);
            if (datas != null && datas.Tables.Count > 0)
            {
                #region 设置groupbox控件
                DataTable data = datas.Tables[0];
                int x, y, row = 0;
                Label label = null;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (i % 5 == 0 && i != 0)
                    {
                        row++;
                    }
                    x = 34 + i % 5 * 25;
                    y = 34 + row * 363;
                    GroupBox groubox = new GroupBox();
                    groubox.Text = "";
                    groubox.Size = new Size(243, 322);
                    groubox.Location = new Point(x, y);
                    #region 设置groupbox中控件
                    label = new Label();
                    label.Location = new Point(86, 21);
                    label.Font = new Font("宋体", 15, FontStyle.Bold);
                    label.Text = data.Rows[i]["XingMing"].ToString();
                    groubox.Controls.Add(label);
                    label = new Label();
                    label.Location = new Point(88, 63);
                    label.Text = data.Rows[i]["ZhiWei"].ToString();
                    groubox.Controls.Add(label);
                    label = new Label();
                    label.Location = new Point(6, 228);
                    label.Text = "联系方式：";
                    groubox.Controls.Add(label);
                    label = new Label();
                    label.Location = new Point(85, 228);
                    label.Text = data.Rows[i]["LianXiFangShi"].ToString();
                    groubox.Controls.Add(label);
                    label = new Label();
                    label.Location = new Point(36, 26);
                    label.Text = "职务：";
                    groubox.Controls.Add(label);
                    label = new Label();
                    label.Location = new Point(82, 26);
                    label.Text = data.Rows[i]["ZhiWu"].ToString();
                    groubox.Controls.Add(label);
                    #endregion
                    groupBox1.Controls.Add(groubox);
                }

                #endregion
            }
        }

        private void 新建成员_Click_1(object sender, EventArgs e)
        {
            addMember addMember = new addMember();
            addMember.FID = comboBox1.SelectedValue?.ToString();
            if (string.IsNullOrWhiteSpace(addMember.FID))
            {
                MessageBox.Show("前选择团队！");
                return;
            }
            addMember.StartPosition = FormStartPosition.CenterScreen;
            addMember.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fid = ((ComboBox)sender).SelectedValue?.ToString();
            GroupBoxBin(fid);
        }
    }
    public class TDMC
    {
        public string ID { get; set; }
        public string TuanDuiMingCheng { get; set; }
    }
}
