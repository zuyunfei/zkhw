﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zkhwClient.view.PublicHealthView
{
    public partial class aUPersonalBasicInfo : Form
    {

        service.personalBasicInfoService personalBasicInfoService = new service.personalBasicInfoService();
        public string id = "";

        DataTable goodsList = new DataTable();//既往史疾病清单表 resident_diseases
        DataTable goodsList0 = new DataTable();//既往史手术清单表 operation_record
        DataTable goodsList1 = new DataTable();//既往史外伤清单表 traumatism_record
        DataTable goodsList2 = new DataTable();//既往史输血清单表 metachysis_record
        DataTable goodsList3 = new DataTable();//家族史表 family_record


        public aUPersonalBasicInfo()
        {
            InitializeComponent();
        }
        private void aUHypertensionPatientServices_Load(object sender, EventArgs e)
        {
            this.label47.ForeColor = Color.SkyBlue;
            label47.Font = new Font("微软雅黑", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134)));
            label47.Left = (this.panel1.Width - this.label47.Width) / 2;
            label47.BringToFront();

            //既往史疾病清单表 
            DataTable dt = personalBasicInfoService.queryResident_diseases(id);
            goodsList = dt.Clone();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow drtmp = goodsList.NewRow();
                drtmp["id"] = dt.Rows[i]["id"].ToString();
                drtmp["resident_base_info_id"] = dt.Rows[i]["resident_base_info_id"].ToString();
                drtmp["disease_name"] = dt.Rows[i]["disease_name"].ToString();
                drtmp["disease_date"] = dt.Rows[i]["disease_date"].ToString();
                goodsList.Rows.Add(drtmp);
            }
            goodsListBind();
            ///////////////////////////////////
            //既往史手术清单表 
            DataTable dt0 = personalBasicInfoService.queryOperation_record(id);
            goodsList0 = dt0.Clone();
            for (int i = 0; i < dt0.Rows.Count; i++)
            {
                DataRow drtmp = goodsList0.NewRow();
                drtmp["id"] = dt0.Rows[i]["id"].ToString();
                drtmp["resident_base_info_id"] = dt0.Rows[i]["resident_base_info_id"].ToString();
                drtmp["operation_name"] = dt0.Rows[i]["operation_name"].ToString();
                drtmp["operation_time"] = dt0.Rows[i]["operation_time"].ToString();
                goodsList0.Rows.Add(drtmp);
            }
            goodsList0Bind();
            ///////////////////////////////////
            //既往史外伤清单表 traumatism_record 
            DataTable dt1 = personalBasicInfoService.queryTraumatism_record(id);
            goodsList1 = dt1.Clone();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow drtmp = goodsList1.NewRow();
                drtmp["id"] = dt1.Rows[i]["id"].ToString();
                drtmp["resident_base_info_id"] = dt1.Rows[i]["resident_base_info_id"].ToString();
                drtmp["traumatism_name"] = dt1.Rows[i]["traumatism_name"].ToString();
                drtmp["traumatism_time"] = dt1.Rows[i]["traumatism_time"].ToString();
                goodsList1.Rows.Add(drtmp);
            }
            goodsList1Bind();
            ///////////////////////////////////
            //既往史输血清单表 metachysis_record
            DataTable dt2 = personalBasicInfoService.queryMetachysis_record(id);
            goodsList2 = dt2.Clone();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                DataRow drtmp = goodsList2.NewRow();
                drtmp["id"] = dt2.Rows[i]["id"].ToString();
                drtmp["resident_base_info_id"] = dt2.Rows[i]["resident_base_info_id"].ToString();
                drtmp["metachysis_reasonn"] = dt2.Rows[i]["metachysis_reasonn"].ToString();
                drtmp["metachysis_time"] = dt2.Rows[i]["metachysis_time"].ToString();
                goodsList2.Rows.Add(drtmp);
            }
            goodsList2Bind();
            ///////////////////////////////////
            //家族史表 family_record 
            DataTable dt3 = personalBasicInfoService.queryFamily_record(id);
            goodsList3 = dt3.Clone();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                DataRow drtmp = goodsList3.NewRow();
                drtmp["id"] = dt3.Rows[i]["id"].ToString();
                drtmp["resident_base_info_id"] = dt3.Rows[i]["resident_base_info_id"].ToString();
                drtmp["relation"] = dt3.Rows[i]["relation"].ToString();
                drtmp["disease_name"] = dt3.Rows[i]["disease_name"].ToString();
                goodsList3.Rows.Add(drtmp);
            }
            goodsList3Bind();
            ///////////////////////////////////



        }

        //既往史疾病清单表 resident_diseases////////////////////////////////////////////////////////////////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            resident_diseases hm = new resident_diseases();
            if (hm.ShowDialog() == DialogResult.OK)
            {
                DataRow[] drr = goodsList.Select("disease_name = '" + hm.disease_name.ToString() + "'");
                if (drr.Length > 0)
                {
                    MessageBox.Show("疾病记录已存在！");
                    return;
                }
                DataRow drtmp = goodsList.NewRow();
                drtmp["id"] = 0;
                drtmp["resident_base_info_id"] = id;
                drtmp["disease_name"] = hm.disease_name.ToString();
                drtmp["disease_date"] = hm.disease_date.ToString();
                goodsList.Rows.Add(drtmp);
            }
            goodsListBind();
        }
        private void goodsListBind()
        {

            this.dataGridView1.DataSource = goodsList;
            this.dataGridView1.Columns[0].Visible = false;//id
            this.dataGridView1.Columns[1].Visible = false;//resident_base_info_id
            this.dataGridView1.Columns[2].HeaderCell.Value = "疾病名称";
            this.dataGridView1.Columns[3].HeaderCell.Value = "确认日期";


            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                this.dataGridView1.SelectedRows[0].Selected = false;
            }
            if (goodsList != null && goodsList.Rows.Count > 0)
            {
                this.dataGridView1.Rows[goodsList.Rows.Count - 1].Selected = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (goodsList == null) { return; }
            if (goodsList.Rows.Count > 0)
            {
                goodsList.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                goodsListBind();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //既往史手术清单表  operation_record////////////////////////////////////////////////////////////////////////////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            operation_record hm = new operation_record();
            if (hm.ShowDialog() == DialogResult.OK)
            {
                DataRow drtmp = goodsList0.NewRow();
                drtmp["id"] = 0;
                drtmp["resident_base_info_id"] = id;
                drtmp["operation_name"] = hm.operation_name.ToString();
                drtmp["operation_time"] = hm.operation_time.ToString();
                goodsList0.Rows.Add(drtmp);
            }
            goodsList0Bind();
        }
        private void goodsList0Bind()
        {

            this.dataGridView2.DataSource = goodsList0;
            this.dataGridView2.Columns[0].Visible = false;//id
            this.dataGridView2.Columns[1].Visible = false;//resident_base_info_id
            this.dataGridView2.Columns[2].HeaderCell.Value = "手术名称";
            this.dataGridView2.Columns[3].HeaderCell.Value = "手术时间";


            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.RowsDefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            if (this.dataGridView2.SelectedRows.Count > 0)
            {
                this.dataGridView2.SelectedRows[0].Selected = false;
            }
            if (goodsList0 != null && goodsList0.Rows.Count > 0)
            {
                this.dataGridView2.Rows[goodsList0.Rows.Count - 1].Selected = true;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (goodsList0 == null) { return; }
            if (goodsList0.Rows.Count > 0)
            {
                goodsList0.Rows.RemoveAt(this.dataGridView2.SelectedRows[0].Index);
                goodsList0Bind();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //既往史外伤清单表 traumatism_record////////////////////////////////////////////////////////////////////////////////////////
        private void button7_Click(object sender, EventArgs e)
        {
            traumatism_record hm = new traumatism_record();
            if (hm.ShowDialog() == DialogResult.OK)
            {
                DataRow drtmp = goodsList1.NewRow();
                drtmp["id"] = 0;
                drtmp["resident_base_info_id"] = id;
                drtmp["traumatism_name"] = hm.traumatism_name.ToString();
                drtmp["traumatism_time"] = hm.traumatism_time.ToString();
                goodsList1.Rows.Add(drtmp);
            }
            goodsList1Bind();
        }
        private void goodsList1Bind()
        {

            this.dataGridView3.DataSource = goodsList1;
            this.dataGridView3.Columns[0].Visible = false;//id
            this.dataGridView3.Columns[1].Visible = false;//resident_base_info_id
            this.dataGridView3.Columns[2].HeaderCell.Value = "外伤名称";
            this.dataGridView3.Columns[3].HeaderCell.Value = "外伤时间";


            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.RowsDefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            if (this.dataGridView3.SelectedRows.Count > 0)
            {
                this.dataGridView3.SelectedRows[0].Selected = false;
            }
            if (goodsList1 != null && goodsList1.Rows.Count > 0)
            {
                this.dataGridView3.Rows[goodsList1.Rows.Count - 1].Selected = true;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (goodsList1 == null) { return; }
            if (goodsList1.Rows.Count > 0)
            {
                goodsList1.Rows.RemoveAt(this.dataGridView3.SelectedRows[0].Index);
                goodsList1Bind();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //既往史输血清单表 metachysis_record////////////////////////////////////////////////////////////////////////////////////////
        private void button9_Click(object sender, EventArgs e)
        {
            metachysis_record hm = new metachysis_record();
            if (hm.ShowDialog() == DialogResult.OK)
            {
                DataRow drtmp = goodsList2.NewRow();
                drtmp["id"] = 0;
                drtmp["resident_base_info_id"] = id;
                drtmp["metachysis_reasonn"] = hm.metachysis_reasonn.ToString();
                drtmp["metachysis_time"] = hm.metachysis_time.ToString();
                goodsList2.Rows.Add(drtmp);
            }
            goodsList2Bind();
        }
        private void goodsList2Bind()
        {

            this.dataGridView4.DataSource = goodsList2;
            this.dataGridView4.Columns[0].Visible = false;//id
            this.dataGridView4.Columns[1].Visible = false;//resident_base_info_id
            this.dataGridView4.Columns[2].HeaderCell.Value = "输血原因";
            this.dataGridView4.Columns[3].HeaderCell.Value = "输血时间";


            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.RowsDefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            if (this.dataGridView4.SelectedRows.Count > 0)
            {
                this.dataGridView4.SelectedRows[0].Selected = false;
            }
            if (goodsList2 != null && goodsList2.Rows.Count > 0)
            {
                this.dataGridView4.Rows[goodsList2.Rows.Count - 1].Selected = true;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (goodsList2 == null) { return; }
            if (goodsList2.Rows.Count > 0)
            {
                goodsList2.Rows.RemoveAt(this.dataGridView3.SelectedRows[0].Index);
                goodsList2Bind();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //家族史表 family_record ////////////////////////////////////////////////////////////////////////////////////////
        private void button11_Click(object sender, EventArgs e)
        {
            family_record hm = new family_record();
            if (hm.ShowDialog() == DialogResult.OK)
            {
                DataRow[] drr = goodsList3.Select("relation = '" + hm.relation.ToString() + "'");
                if (drr.Length > 0)
                {
                    MessageBox.Show("关系已存在！");
                    return;
                }
                DataRow drtmp = goodsList3.NewRow();
                drtmp["id"] = 0;
                drtmp["resident_base_info_id"] = id;
                drtmp["relation"] = hm.relation.ToString();
                drtmp["disease_name"] = hm.disease_name.ToString();
                goodsList3.Rows.Add(drtmp);
            }
            goodsList3Bind();
        }
        private void goodsList3Bind()
        {

            this.dataGridView6.DataSource = goodsList3;
            this.dataGridView6.Columns[0].Visible = false;//id
            this.dataGridView6.Columns[1].Visible = false;//resident_base_info_id
            this.dataGridView6.Columns[2].HeaderCell.Value = "关系";
            this.dataGridView6.Columns[3].HeaderCell.Value = "疾病名称";


            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.RowsDefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            if (this.dataGridView6.SelectedRows.Count > 0)
            {
                this.dataGridView6.SelectedRows[0].Selected = false;
            }
            if (goodsList3 != null && goodsList3.Rows.Count > 0)
            {
                this.dataGridView6.Rows[goodsList3.Rows.Count - 1].Selected = true;
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (goodsList3 == null) { return; }
            if (goodsList3.Rows.Count > 0)
            {
                goodsList3.Rows.RemoveAt(this.dataGridView6.SelectedRows[0].Index);
                goodsList3Bind();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bean.resident_base_infoBean resident_base_infoBean = new bean.resident_base_infoBean();

            resident_base_infoBean.name = this.textBox1.Text.Replace(" ", "");
            resident_base_infoBean.archive_no = this.textBox2.Text.Replace(" ", "");
            resident_base_infoBean.pb_archive = this.textBox2.Text.Replace(" ", "");
            if (this.radioButton1.Checked == true) { resident_base_infoBean.sex = this.radioButton1.Text; };
            if (this.radioButton2.Checked == true) { resident_base_infoBean.sex = this.radioButton2.Text; };
            if (this.radioButton3.Checked == true) { resident_base_infoBean.sex = this.radioButton3.Text; };
            if (this.radioButton25.Checked == true) { resident_base_infoBean.sex = this.radioButton25.Text; };
            resident_base_infoBean.birthday = this.dateTimePicker1.Text;
            resident_base_infoBean.id_number = this.textBox12.Text.Replace(" ", "");
            resident_base_infoBean.company = this.textBox14.Text.Replace(" ", "");
            resident_base_infoBean.phone = this.textBox16.Text.Replace(" ", "");
            resident_base_infoBean.link_name = this.textBox18.Text.Replace(" ", "");
            resident_base_infoBean.link_phone = this.textBox20.Text.Replace(" ", "");
            if (this.radioButton4.Checked == true) { resident_base_infoBean.resident_type = this.radioButton4.Text; };
            if (this.radioButton5.Checked == true) { resident_base_infoBean.resident_type = this.radioButton5.Text; };

            if (this.radioButton6.Checked == true) { resident_base_infoBean.nation = this.radioButton6.Text; };
            if (this.radioButton7.Checked == true) { resident_base_infoBean.nation = this.radioButton7.Text; };

            if (this.radioButton8.Checked == true) { resident_base_infoBean.blood_group = this.radioButton8.Text; };
            if (this.radioButton9.Checked == true) { resident_base_infoBean.blood_group = this.radioButton9.Text; };
            if (this.radioButton10.Checked == true) { resident_base_infoBean.blood_group = this.radioButton10.Text; };
            if (this.radioButton11.Checked == true) { resident_base_infoBean.blood_group = this.radioButton11.Text; };
            if (this.radioButton12.Checked == true) { resident_base_infoBean.blood_group = this.radioButton12.Text; };

            if (this.radioButton13.Checked == true) { resident_base_infoBean.blood_rh = this.radioButton13.Text; };
            if (this.radioButton14.Checked == true) { resident_base_infoBean.blood_rh = this.radioButton14.Text; };
            if (this.radioButton15.Checked == true) { resident_base_infoBean.blood_rh = this.radioButton15.Text; };

            if (this.radioButton22.Checked == true) { resident_base_infoBean.education = this.radioButton22.Text; };
            if (this.radioButton23.Checked == true) { resident_base_infoBean.education = this.radioButton23.Text; };
            if (this.radioButton24.Checked == true) { resident_base_infoBean.education = this.radioButton24.Text; };
            if (this.radioButton26.Checked == true) { resident_base_infoBean.education = this.radioButton26.Text; };
            if (this.radioButton27.Checked == true) { resident_base_infoBean.education = this.radioButton27.Text; };
            if (this.radioButton28.Checked == true) { resident_base_infoBean.education = this.radioButton28.Text; };
            if (this.radioButton29.Checked == true) { resident_base_infoBean.education = this.radioButton29.Text; };
            if (this.radioButton30.Checked == true) { resident_base_infoBean.education = this.radioButton30.Text; };
            if (this.radioButton31.Checked == true) { resident_base_infoBean.education = this.radioButton31.Text; };
            if (this.radioButton32.Checked == true) { resident_base_infoBean.education = this.radioButton32.Text; };

            if (this.radioButton33.Checked == true) { resident_base_infoBean.profession = this.radioButton33.Text; };
            if (this.radioButton34.Checked == true) { resident_base_infoBean.profession = this.radioButton34.Text; };
            if (this.radioButton35.Checked == true) { resident_base_infoBean.profession = this.radioButton35.Text; };
            if (this.radioButton36.Checked == true) { resident_base_infoBean.profession = this.radioButton36.Text; };
            if (this.radioButton37.Checked == true) { resident_base_infoBean.profession = this.radioButton37.Text; };
            if (this.radioButton38.Checked == true) { resident_base_infoBean.profession = this.radioButton38.Text; };
            if (this.radioButton39.Checked == true) { resident_base_infoBean.profession = this.radioButton39.Text; };
            if (this.radioButton40.Checked == true) { resident_base_infoBean.profession = this.radioButton40.Text; };
            if (this.radioButton41.Checked == true) { resident_base_infoBean.profession = this.radioButton41.Text; };

            if (this.radioButton42.Checked == true) { resident_base_infoBean.marital_status = this.radioButton42.Text; };
            if (this.radioButton43.Checked == true) { resident_base_infoBean.marital_status = this.radioButton43.Text; };
            if (this.radioButton44.Checked == true) { resident_base_infoBean.marital_status = this.radioButton44.Text; };
            if (this.radioButton45.Checked == true) { resident_base_infoBean.marital_status = this.radioButton45.Text; };
            if (this.radioButton46.Checked == true) { resident_base_infoBean.marital_status = this.radioButton46.Text; };

            if (this.radioButton47.Checked == true) { resident_base_infoBean.pay_type = this.radioButton47.Text; };
            if (this.radioButton48.Checked == true) { resident_base_infoBean.pay_type = this.radioButton48.Text; };
            if (this.radioButton49.Checked == true) { resident_base_infoBean.pay_type = this.radioButton49.Text; };
            if (this.radioButton50.Checked == true) { resident_base_infoBean.pay_type = this.radioButton50.Text; };
            if (this.radioButton51.Checked == true) { resident_base_infoBean.pay_type = this.radioButton51.Text; };
            if (this.radioButton52.Checked == true) { resident_base_infoBean.pay_type = this.radioButton52.Text; };
            if (this.radioButton53.Checked == true) { resident_base_infoBean.pay_type = this.radioButton53.Text; };
            if (this.radioButton54.Checked == true) { resident_base_infoBean.pay_type = this.radioButton54.Text; };

            if (this.radioButton55.Checked == true) { resident_base_infoBean.drug_allergy = this.radioButton55.Text; };
            if (this.radioButton56.Checked == true) { resident_base_infoBean.drug_allergy = this.radioButton56.Text; };
            if (this.radioButton57.Checked == true) { resident_base_infoBean.drug_allergy = this.radioButton57.Text; };
            if (this.radioButton58.Checked == true) { resident_base_infoBean.drug_allergy = this.radioButton58.Text; };
            if (this.radioButton59.Checked == true) { resident_base_infoBean.drug_allergy = this.radioButton59.Text; };

            if (this.radioButton60.Checked == true) { resident_base_infoBean.exposure = this.radioButton60.Text; };
            if (this.radioButton61.Checked == true) { resident_base_infoBean.exposure = this.radioButton61.Text; };
            if (this.radioButton62.Checked == true) { resident_base_infoBean.exposure = this.radioButton62.Text; };
            if (this.radioButton63.Checked == true) { resident_base_infoBean.exposure = this.radioButton63.Text; };



            resident_base_infoBean.heredity_name = this.richTextBox4.Text;


            foreach (Control ctr in this.panel20.Controls)
            {
                //判断该控件是不是CheckBox
                if (ctr is CheckBox)
                {
                    //将ctr转换成CheckBox并赋值给ck
                    CheckBox ck = ctr as CheckBox;
                    if (ck.Checked)
                    {
                        resident_base_infoBean.deformity_name += "," + ck.Text;
                    }
                }
            }
            if (resident_base_infoBean.deformity_name != null && resident_base_infoBean.deformity_name != "")
            {
                resident_base_infoBean.deformity_name = resident_base_infoBean.deformity_name.Substring(1);
            }

            if (this.radioButton18.Checked == true) { resident_base_infoBean.kitchen = this.radioButton18.Text; };
            if (this.radioButton19.Checked == true) { resident_base_infoBean.kitchen = this.radioButton19.Text; };
            if (this.radioButton20.Checked == true) { resident_base_infoBean.kitchen = this.radioButton20.Text; };
            if (this.radioButton21.Checked == true) { resident_base_infoBean.kitchen = this.radioButton21.Text; };

            if (this.radioButton70.Checked == true) { resident_base_infoBean.fuel = this.radioButton70.Text; };
            if (this.radioButton71.Checked == true) { resident_base_infoBean.fuel = this.radioButton71.Text; };
            if (this.radioButton72.Checked == true) { resident_base_infoBean.fuel = this.radioButton72.Text; };
            if (this.radioButton73.Checked == true) { resident_base_infoBean.fuel = this.radioButton73.Text; };
            if (this.radioButton74.Checked == true) { resident_base_infoBean.fuel = this.radioButton74.Text; };
            if (this.radioButton75.Checked == true) { resident_base_infoBean.fuel = this.radioButton75.Text; };

            if (this.radioButton76.Checked == true) { resident_base_infoBean.drink = this.radioButton76.Text; };
            if (this.radioButton77.Checked == true) { resident_base_infoBean.drink = this.radioButton77.Text; };
            if (this.radioButton78.Checked == true) { resident_base_infoBean.drink = this.radioButton78.Text; };
            if (this.radioButton79.Checked == true) { resident_base_infoBean.drink = this.radioButton79.Text; };
            if (this.radioButton80.Checked == true) { resident_base_infoBean.drink = this.radioButton80.Text; };
            if (this.radioButton81.Checked == true) { resident_base_infoBean.drink = this.radioButton81.Text; };

            if (this.radioButton82.Checked == true) { resident_base_infoBean.toilet = this.radioButton82.Text; };
            if (this.radioButton83.Checked == true) { resident_base_infoBean.toilet = this.radioButton83.Text; };
            if (this.radioButton84.Checked == true) { resident_base_infoBean.toilet = this.radioButton84.Text; };
            if (this.radioButton85.Checked == true) { resident_base_infoBean.toilet = this.radioButton85.Text; };
            if (this.radioButton86.Checked == true) { resident_base_infoBean.toilet = this.radioButton86.Text; };

            if (this.radioButton87.Checked == true) { resident_base_infoBean.poultry = this.radioButton87.Text; };
            if (this.radioButton88.Checked == true) { resident_base_infoBean.poultry = this.radioButton88.Text; };
            if (this.radioButton89.Checked == true) { resident_base_infoBean.poultry = this.radioButton89.Text; };
            if (this.radioButton90.Checked == true) { resident_base_infoBean.poultry = this.radioButton90.Text; };





            ////以下页面未用 数据库字段格式要求
            resident_base_infoBean.synchro_time = DateTime.Now.ToString();
            resident_base_infoBean.create_time = DateTime.Now.ToString();
            resident_base_infoBean.update_time = DateTime.Now.ToString();

            resident_base_infoBean.is_hypertension = "0";
            resident_base_infoBean.is_diabetes = "0";
            resident_base_infoBean.is_psychosis = "0";
            resident_base_infoBean.is_tuberculosis = "0";
            resident_base_infoBean.is_heredity = "0";
            resident_base_infoBean.is_deformity = "0";
            resident_base_infoBean.is_poor = "0";
            resident_base_infoBean.is_signing = "0";
            resident_base_infoBean.is_synchro = "0";


            bool isfalse = personalBasicInfoService.aUpersonalBasicInfo(resident_base_infoBean, id, goodsList, goodsList0, goodsList1, goodsList2, goodsList3);
            if (isfalse)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox12.Text.Replace(" ", "").Length == 18 && id == "") {
                DataTable dt = personalBasicInfoService.query(this.textBox12.Text.Replace(" ", ""));
                if (dt.Rows.Count > 0) {
                    this.textBox12.Text = "";
                    MessageBox.Show("此身份证号已注册");
                }
            }
        }
    }
}
