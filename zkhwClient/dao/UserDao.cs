using System;
using System.Data;
using zkhwClient.bean;
using System.Linq;
using System.Windows.Forms;

namespace zkhwClient.dao
{
    class UserDao
    {
        public DataTable exists(UserInfo user)
        {
            //string despwd = "";
            //if (user.Pwd != null&&!"".Equals(user.Pwd)) {
            //    despwd = MemoryPassword.MyEncrypt.EncryptDES(user.Pwd);
            //}
            String sql = "select id,name from zkhw_user_info where username = '" + user.UserName + "'AND password = '" + user.Pwd + "'";

            DataSet ds = new DataSet();
            ds.Clear();
            ds = DbHelperMySQL.Query(sql);
            return ds.Tables[0];
        }
        public bool updatePassWord(bean.UserInfo user)
        {
            int ret = 0;
            String sql = "update zkhw_user_info set password='" + user.Pwd + "' where username = '" + user.UserName + "'";
            ret = DbHelperMySQL.ExecuteSql(sql);
            return ret == 0 ? false : true;
        }
        public DataTable listUser()  
        {
            String sql = "select username name,password from zkhw_user_info where 1=1 and username != 'admin' ";
            DataSet ds = new DataSet();
            ds.Clear();
            ds = DbHelperMySQL.Query(sql);
            return ds.Tables[0];
        }
        public bool addUser(bean.UserInfo ui)
        {
            if (ui.Enable==0) {
                ui.Enable = 1;
            }
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int rt = 0;
            String sql = "select * from userinfo where name='"+ui.UserName+"'";
            DataSet ds = new DataSet();
            ds.Clear();
            ds = DbHelperMySQL.Query(sql);
            //string id = Result.GetNewId();
            if (ds.Tables[0].Rows.Count <= 0)
            {
                string sql1 = "insert into zkhw_user_info (name,pwd,enable,createTime,power) values ('" + ui.UserName + "', '" + ui.Pwd + "', '" + ui.Enable + "', '" + time + "', '" + ui.Power + "')";
                rt = DbHelperMySQL.ExecuteSql(sql1);              
            }

            return rt == 0 ? false : true;
        }
        public bool updateUser(bean.UserInfo ui)
        {
            int ret = 0;
            String sql = "update zkhw_user_info set name='" + ui.UserName + "',enable='" + ui.Enable + "',power='"+ui.Power+"' where id='" +ui.Id+ "'";
            ret = DbHelperMySQL.ExecuteSql(sql);
            return ret == 0 ? false : true;
        }
        public bool deleteUser(string id, string name)
        {
            int ret = 0;
            String sql = "delete from zkhw_user_info where id = '" + id + "'";
            ret = DbHelperMySQL.ExecuteSql(sql);

            return ret == 0 ? false : true;
        }

    }
}
