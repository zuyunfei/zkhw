using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zkhwClient.bean
{
    class UserInfo
    {
        private String id;
        private String userName;
        private String password;
        private String lasttime;
        private String loginnumber;
        private String depaid;
        private String name;
        private String type;



        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        public string Lasttime
        {
            get
            {
                return lasttime;
            }

            set
            {
                lasttime = value;
            }
        }
        public string Loginnumber
        {
            get
            {
                return loginnumber;
            }

            set
            {
                loginnumber = value;
            }
        }
        public string Depaid
        {
            get
            {
                return depaid;
            }

            set
            {
                depaid = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }
    }
}
