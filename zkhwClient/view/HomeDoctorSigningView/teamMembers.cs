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
            string sql = "select ID,TuanDuiMingCheng from zkhw_qy_tdcy";
            DataSet datas = DbHelperMySQL.Query(sql);
            if (datas != null && datas.Tables.Count > 0)
            {
                List<TDMC> ts = Result.ToDataList<TDMC>(datas.Tables[0]);
                Result.Bind(comboBox1, ts, "TuanDuiMingCheng", "ID", "--请选择--");
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
    }
    public class TDMC
    {
        public string ID { get; set; }
        public string TuanDuiMingCheng { get; set; }
    }
}
