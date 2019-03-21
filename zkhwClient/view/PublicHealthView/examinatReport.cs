using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zkhwClient.dao;

namespace zkhwClient.view.PublicHealthView
{
    public partial class examinatReport : Form
    {
        public examinatReport()
        {
            InitializeComponent();
            string sql = @"SELECT count(XingBie)sun,XingBie
from zkhw_tj_bgdc
GROUP BY XingBie
";
            DataSet dataSet = DbHelperMySQL.Query(sql);
            DataTable data = dataSet.Tables[0];
            if (data != null && data.Rows.Count > 0)
            {
                if (data.Rows[0]["XingBie"].ToString() == "女")
                {
                    女.Text = data.Rows[0]["sun"].ToString();
                    男.Text = data.Rows[1]["sun"].ToString();
                }
                else
                {
                    女.Text = data.Rows[1]["sun"].ToString();
                    男.Text = data.Rows[0]["sun"].ToString();
                }
                总数.Text = data.Compute("sum(sun)", "true").ToString();
            }

        }

        private void examinatProgress_Load(object sender, EventArgs e)
        {
            //让默认的日期时间减一天
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddDays(-1);
            string str = Application.StartupPath;//项目路径
            this.button1.BackgroundImage = Image.FromFile(@str + "/images/check.png");
            this.统计查询.BackgroundImage = Image.FromFile(@str + "/images/check.png");

            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);

            queryExaminatProgress(GetData(pagerControl1.PageIndex, pagerControl1.PageSize, out int count));
            pagerControl1.DrawControl(count);
        }
        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            queryExaminatProgress(GetData(pagerControl1.PageIndex, pagerControl1.PageSize, out int count));
            pagerControl1.DrawControl(count);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="pageindex">当前页面</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="count">总数</param>
        /// <returns></returns>
        private DataTable GetData(int pageindex, int pagesize, out int count)
        {
            pageindex = pageindex - 1;
            string timesta = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string timeend = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            string sheng = comboBox1.SelectedValue?.ToString();
            string shi = comboBox2.SelectedValue?.ToString();
            string xian = comboBox3.SelectedValue?.ToString();
            string cun = comboBox4.SelectedValue?.ToString();
            string zu = comboBox5.SelectedValue?.ToString();
            string juming = textBox1.Text;
            var pairs = new Dictionary<string, string>();
            pairs.Add("timesta", timesta);
            pairs.Add("timeend", timeend);
            pairs.Add("sheng", sheng);
            pairs.Add("shi", shi);
            pairs.Add("xian", xian);
            pairs.Add("cun", cun);
            pairs.Add("zu", zu);
            pairs.Add("juming", juming);
            string sql = $@"select SQL_CALC_FOUND_ROWS 
id,
DATE_FORMAT(DengJiShiJian,'%Y%m%d') DengJiShiJian,
CONCAT(Sheng,Shi,Xian,Cun,Zu) QuYu,
BianHao,
XingMing,
XingBie,
ShenFenZhengHao,
ShiFouTongBu,
BaoGaoShengChan
from zkhw_tj_bgdc where 1=1 ";
            if (pairs != null && pairs.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(pairs["timesta"]) && !string.IsNullOrWhiteSpace(pairs["timeend"]))
                {
                    sql += $" and date_format(DengJiShiJian,'%Y-%m-%d') between '{pairs["timesta"]}' and '{pairs["timeend"]}'";
                }
                if (!string.IsNullOrWhiteSpace(pairs["sheng"]))
                {
                    sql += $" and Sheng='{pairs["sheng"]}'";
                }
                if (!string.IsNullOrWhiteSpace(pairs["shi"]))
                {
                    sql += $" and Shi='{pairs["shi"]}'";
                }
                if (!string.IsNullOrWhiteSpace(pairs["xian"]))
                {
                    sql += $" and Xian='{pairs["xian"]}'";
                }
                if (!string.IsNullOrWhiteSpace(pairs["cun"]))
                {
                    sql += $" and Cun='{pairs["cun"]}'";
                }
                if (!string.IsNullOrWhiteSpace(pairs["zu"]))
                {
                    sql += $" and Zu='{pairs["zu"]}'";
                }
                if (!string.IsNullOrWhiteSpace(pairs["juming"]))
                {
                    sql += $" or XingMing='{pairs["juming"]}' or BianHao='{pairs["juming"]}' or ShenFenZhengHao='{pairs["juming"]}'";
                }
            }
            //sql += $" and id > ({pageindex}-1)*{pagesize} limit {pagesize}; select found_rows()";
            sql += $@" and id >=(
select id From zkhw_tj_bgdc Order By id limit {pageindex},1
) limit {pagesize}; select found_rows()";
            DataSet dataSet = DbHelperMySQL.Query(sql);
            DataTable dt = dataSet.Tables[0];
            count = Convert.ToInt32(dataSet.Tables[1].Rows[0][0]);
            return dt;
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="data"></param>
        private void queryExaminatProgress(DataTable data)
        {
            //if (dataGridView1.DataSource != null)
            //{
            //    DataTable dts = (DataTable)dataGridView1.DataSource;
            //    dts.Rows.Clear();
            //    dataGridView1.DataSource = dt;
            //}
            //else
            //{
            //    dataGridView1.Rows.Clear();
            //}

            if (data != null)
            {
                this.dataGridView1.DataSource = data;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderCell.Value = "登记时间";
                this.dataGridView1.Columns[2].HeaderCell.Value = "区域";
                this.dataGridView1.Columns[3].HeaderCell.Value = "编号";
                this.dataGridView1.Columns[4].HeaderCell.Value = "姓名";
                this.dataGridView1.Columns[5].HeaderCell.Value = "性别";
                this.dataGridView1.Columns[6].HeaderCell.Value = "身份证号";
                this.dataGridView1.Columns[7].HeaderCell.Value = "是否同步";
                this.dataGridView1.Columns[8].HeaderCell.Value = "报告生产时间";

                //DataGridViewButtonColumn DGBC = new DataGridViewButtonColumn();
                //dataGridView1.Columns.Add(DGBC);

                this.dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
                this.dataGridView1.AllowUserToAddRows = false;
                this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridView1.Columns[0].Visible = false;

                this.dataGridView1.ReadOnly = true;
                for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }

        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            queryExaminatProgress(GetData(pagerControl1.PageIndex, pagerControl1.PageSize, out int count));
            pagerControl1.DrawControl(count);
        }

        private void 统计查询_Click(object sender, EventArgs e)
        {
            string stan = dateTimePicker3.Value.ToString("yyyy-MM-dd");
            string end = dateTimePicker4.Value.ToString("yyyy-MM-dd");
            string sql = $@"SELECT XingBie,'64',COUNT(XingBie) 人数,
COUNT(CASE
    WHEN(bchao = '是') THEN '0'
END
) as B超异常,
COUNT(CASE
    WHEN(XinDian = '是') THEN
        '0'
END
) as 心电异常,
COUNT(CASE
    WHEN(NiaoChangGui = '是') THEN
        '0'
END
) as 尿常规异常,
COUNT(CASE
    WHEN(XueYa = '是') THEN
        '0'
END
) as 血压异常,
COUNT(CASE
    WHEN(ShengHua = '是') THEN
        '0'
END
) as 生化异常
from zkhw_tj_bgdc where nianling >= '0' and nianling<= '64' and date_format(DengJiShiJian,'%Y-%m-%d') between '{stan}' and '{end}'
GROUP BY XingBie;

SELECT XingBie,'70',COUNT(XingBie) 人数,
COUNT(CASE
    WHEN(bchao = '是') THEN
        '0'
END
) as B超异常,
COUNT(CASE
    WHEN(XinDian = '是') THEN
        '0'
END
) as 心电异常,
COUNT(CASE
    WHEN(NiaoChangGui = '是') THEN
        '0'
END
) as 尿常规异常,
COUNT(CASE
    WHEN(XueYa = '是') THEN
        '0'
END
) as 血压异常,
COUNT(CASE
    WHEN(ShengHua = '是') THEN
        '0'
END
) as 生化异常
from zkhw_tj_bgdc where nianling >= '65' and nianling<= '70' and date_format(DengJiShiJian,'%Y-%m-%d') between '{stan}' and '{end}'
GROUP BY XingBie;

SELECT XingBie,'75',COUNT(XingBie) 人数,
COUNT(CASE
    WHEN(bchao = '是') THEN
        '0'
END
) as B超异常,
COUNT(CASE
    WHEN(XinDian = '是') THEN
        '0'
END
) as 心电异常,
COUNT(CASE
    WHEN(NiaoChangGui = '是') THEN
        '0'
END
) as 尿常规异常,
COUNT(CASE
    WHEN(XueYa = '是') THEN
        '0'
END
) as 血压异常,
COUNT(CASE
    WHEN(ShengHua = '是') THEN
        '0'
END
) as 生化异常
from zkhw_tj_bgdc where nianling >= '70' and nianling<= '75' and date_format(DengJiShiJian,'%Y-%m-%d') between '{stan}' and '{end}'
GROUP BY XingBie;

SELECT XingBie,'76',COUNT(XingBie) 人数,
COUNT(CASE
    WHEN(bchao = '是') THEN
        '0'
END
) as B超异常,
COUNT(CASE
    WHEN(XinDian = '是') THEN
        '0'
END
) as 心电异常,
COUNT(CASE
    WHEN(NiaoChangGui = '是') THEN
        '0'
END
) as 尿常规异常,
COUNT(CASE
    WHEN(XueYa = '是') THEN
        '0'
END
) as 血压异常,
COUNT(CASE
    WHEN(ShengHua = '是') THEN
        '0'
END
) as 生化异常
from zkhw_tj_bgdc where nianling >= '75' and date_format(DengJiShiJian,'%Y-%m-%d') between '{stan}' and '{end}'
GROUP BY XingBie";
            DataSet dataSet = DbHelperMySQL.Query(sql);
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                for (int i = 0; i < dataSet.Tables.Count; i++)
                {
                    DataTable data = dataSet.Tables[i];
                    if (data != null && data.Rows.Count > 0)
                    {
                        switch (data.Rows[0][1].ToString())
                        {
                            case "64":
                                #region 064
                                DataRow[] rows = data.Select("XingBie='女'");
                                if (rows != null && rows.Length > 0)
                                {
                                    女064.Text = rows[0]["人数"].ToString();
                                }
                                DataRow[] rowss = data.Select("XingBie='男'");
                                if (rowss != null && rowss.Length > 0)
                                {
                                    男064.Text = rowss[0]["人数"].ToString();
                                }
                                B超064.Text = data.Compute("sum(B超异常)", "true").ToString();
                                心电064.Text = data.Compute("sum(心电异常)", "true").ToString();
                                尿常规064.Text = data.Compute("sum(尿常规异常)", "true").ToString();
                                血压064.Text = data.Compute("sum(血压异常)", "true").ToString();
                                生化064.Text = data.Compute("sum(生化异常)", "true").ToString();
                                #endregion
                                break;
                            case "70":
                                #region 6570
                                DataRow[] nv6570 = data.Select("XingBie='女'");
                                if (nv6570 != null && nv6570.Length > 0)
                                {
                                    女6570.Text = nv6570[0]["人数"].ToString();
                                }
                                DataRow[] nan6570 = data.Select("XingBie='男'");
                                if (nan6570 != null && nan6570.Length > 0)
                                {
                                    男6570.Text = nan6570[0]["人数"].ToString();
                                }
                                B超6570.Text = data.Compute("sum(B超异常)", "true").ToString();
                                心电6570.Text = data.Compute("sum(心电异常)", "true").ToString();
                                尿常规6570.Text = data.Compute("sum(尿常规异常)", "true").ToString();
                                血压6570.Text = data.Compute("sum(血压异常)", "true").ToString();
                                生化6570.Text = data.Compute("sum(生化异常)", "true").ToString();
                                #endregion
                                break;
                            case "75":
                                #region 7075   
                                DataRow[] nv7075 = data.Select("XingBie='女'");
                                if (nv7075 != null && nv7075.Length > 0)
                                {
                                    女7075.Text = nv7075[0]["人数"].ToString();
                                }
                                DataRow[] nan7075 = data.Select("XingBie='男'");
                                if (nan7075 != null && nan7075.Length > 0)
                                {
                                    男7075.Text = nan7075[0]["人数"].ToString();
                                }
                                B超7075.Text = data.Compute("sum(B超异常)", "true").ToString();
                                心电7075.Text = data.Compute("sum(心电异常)", "true").ToString();
                                尿常规7075.Text = data.Compute("sum(尿常规异常)", "true").ToString();
                                血压7075.Text = data.Compute("sum(血压异常)", "true").ToString();
                                生化7075.Text = data.Compute("sum(生化异常)", "true").ToString();
                                #endregion
                                break;
                            case "76":
                                #region 75
                                DataRow[] nv75 = data.Select("XingBie='女'");
                                if (nv75 != null && nv75.Length > 0)
                                {
                                    女75.Text = nv75[0]["人数"].ToString();
                                }
                                DataRow[] nan75 = data.Select("XingBie='男'");
                                if (nan75 != null && nan75.Length > 0)
                                {
                                    男75.Text = nan75[0]["人数"].ToString();
                                }
                                B超75.Text = data.Compute("sum(B超异常)", "true").ToString();
                                心电75.Text = data.Compute("sum(心电异常)", "true").ToString();
                                尿常规75.Text = data.Compute("sum(尿常规异常)", "true").ToString();
                                血压75.Text = data.Compute("sum(血压异常)", "true").ToString();
                                生化75.Text = data.Compute("sum(生化异常)", "true").ToString();
                                #endregion
                                break;
                        }
                    }
                }
            }
        }
    }
}
