using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class agreementController : ApiController
    {
        AGDal dal = new AGDal();
        //添加
        [HttpPost]
        public int Add(agreement m)
        {
            return dal.Add(m); 
               
        }
        //显示
        [HttpPost]
        public List<agreement> Show()
        {
            return dal.Show();
        }
        //分页
        public List<agreement> UserInfoShowPage(string Name, int PageInex, int PageSize)
        {
            return dal.UserInfoShowPage(Name, PageInex, PageSize);
        }
    }
}
