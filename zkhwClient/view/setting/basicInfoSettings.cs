using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zkhwClient.dao;

namespace zkhwClient.view.setting
{
    public partial class basicInfoSettings : Form
    {
        areaConfigDao areadao = new areaConfigDao();
        basicSettingDao bsdao = new basicSettingDao();
        string xcuncode = null;
        string xzcode = null;
        string qxcode = null;
        string shicode = null;
        string shengcode = null;
        public basicInfoSettings()
        {
            InitializeComponent();
        }
        private void basicInfoSettings_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox1.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox1.ValueMember = "code";//操作时获取的值 

            showCombobox();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            shengcode = this.comboBox1.SelectedValue.ToString();
            this.comboBox2.DataSource = areadao.shiInfo(shengcode);//绑定数据源
            this.comboBox2.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox2.ValueMember = "code";//操作时获取的值 
            this.comboBox3.DataSource = null;
            this.comboBox4.DataSource = null;
            this.comboBox5.DataSource = null;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            shicode = this.comboBox2.SelectedValue.ToString();
            this.comboBox3.DataSource = areadao.quxianInfo(shicode);//绑定数据源
            this.comboBox3.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox3.ValueMember = "code";//操作时获取的值 
            this.comboBox4.DataSource = null;
            this.comboBox5.DataSource = null;
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            qxcode = this.comboBox3.SelectedValue.ToString();
            this.comboBox4.DataSource = areadao.zhenInfo(qxcode);//绑定数据源
            this.comboBox4.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox4.ValueMember = "code";//操作时获取的值 
            this.comboBox5.DataSource = null;
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            xzcode = this.comboBox4.SelectedValue.ToString();
            MessageBox.Show(xzcode);
            this.comboBox5.DataSource = areadao.cunInfo(xzcode);//绑定数据源
            this.comboBox5.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox5.ValueMember = "code";//操作时获取的值 
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            xcuncode = this.comboBox5.SelectedValue.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string organ_code = null;
            string organ_name = textBox1.Text;
            string input_name = this.comboBox6.SelectedValue.ToString();
            string responsibility_doctor = this.comboBox7.SelectedValue.ToString();
            string bc = this.comboBox8.SelectedValue.ToString();
            string xcg = this.comboBox9.SelectedValue.ToString();
            string sh = this.comboBox10.SelectedValue.ToString();
            string sgtz = this.comboBox11.SelectedValue.ToString();
            string ncg = this.comboBox12.SelectedValue.ToString();
            string xdt = this.comboBox13.SelectedValue.ToString();
            string xy = this.comboBox14.SelectedValue.ToString();
            string wx = textBox3.Text;
            string other = textBox2.Text;
            string captain = this.comboBox15.SelectedValue.ToString();
            string members = textBox4.Text;
            string operation = this.comboBox16.SelectedValue.ToString();
            string car_name = this.comboBox17.SelectedValue.ToString();
            string create_user = null;
            string create_name = null;

            if (xcuncode != null && !"".Equals(xcuncode))
            {
                bsdao.addBasicSetting(shengcode, shicode, qxcode, xzcode, xcuncode, organ_code, organ_name, input_name, responsibility_doctor, bc, xcg, sh, sgtz, ncg, xdt, xy, wx, other, captain, members, operation, car_name, create_user, create_name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showCombobox();
        }

        private void showCombobox() {
            this.comboBox6.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox6.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox6.ValueMember = "code";//操作时获取的值

            this.comboBox7.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox7.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox7.ValueMember = "code";//操作时获取的值

            this.comboBox8.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox8.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox8.ValueMember = "code";//操作时获取的值

            this.comboBox8.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox8.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox8.ValueMember = "code";//操作时获取的值

            this.comboBox9.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox9.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox9.ValueMember = "code";//操作时获取的值

            this.comboBox10.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox10.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox10.ValueMember = "code";//操作时获取的值

            this.comboBox11.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox11.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox11.ValueMember = "code";//操作时获取的值

            this.comboBox12.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox12.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox12.ValueMember = "code";//操作时获取的值

            this.comboBox13.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox13.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox13.ValueMember = "code";//操作时获取的值

            this.comboBox14.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox14.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox14.ValueMember = "code";//操作时获取的值

            this.comboBox15.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox15.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox15.ValueMember = "code";//操作时获取的值

            this.comboBox16.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox16.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox16.ValueMember = "code";//操作时获取的值

            this.comboBox17.DataSource = areadao.shengInfo();//绑定数据源
            this.comboBox17.DisplayMember = "name";//显示给用户的数据集表项
            this.comboBox17.ValueMember = "code";//操作时获取的值
        }
    }
}
