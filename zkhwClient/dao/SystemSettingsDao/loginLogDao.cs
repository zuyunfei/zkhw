using System;
using System.Data;

namespace zkhwClient.dao
{
    class loginLogDao
    {
        public DataTable checkLog(string time1, string time2)
        {
            DataSet ds = new DataSet();
            string sql = "select * from zkhw_log_syslog a where a.createtime > '" + time1 + "' and  a.createtime <  '" + time2 + "'";
            ds = DbHelperMySQL.Query(sql);
            return ds.Tables[0];
        }

        public bool addCheckLog(bean.loginLogBean lb)
        {
            int rt = 0;
            //string id = Result.GetNewId();
            string type = "系统日志";
             String sql = "insert into zkhw_log_syslog (id,name,type,createtime,eventInfo) values ('" + Result.GetNewId() + "','" + lb.name + "','" + type + "', '" + lb.createTime + "', '" + lb.eventInfo + "')";
            rt = DbHelperMySQL.ExecuteSql(sql);
            return rt == 0 ? false : true;
        }
    }
}
