using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
 

namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
        [System.Web.Http.HttpPost]
        public string Post(string id)
        {
            var postInfo2 = "ok0";

          
            return postInfo2;
        }
        public string Get(string id)
        {
            var postInfo2 = "ok0";


            return postInfo2;
        }
    }
}