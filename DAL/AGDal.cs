using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AGDal
    {
        //添加
        public int Add(agreement m)
        {
            string Sql = $"insert into agreement values('{m.AGDaima}','{m.AGName}','{m.AGgqje}','{m.AGyfkje}','{m.AGhtye}','{m.AgYfkzb}')";
            return DBHelper.ExecuteNonQuery(Sql); 
        }
        //显示
        public List<agreement> Show()
        {
            string sql = "select * from  agreement";
            return DBHelper.GetList<agreement>(sql);
        }
        //分页
        //用户分页显示
        public List<agreement> UserInfoShowPage(string Name, int PageInex, int PageSize)
        {
            var Where = "";
            if (!string.IsNullOrEmpty(Name))
            {
                Where += "and UserName like '%" + Name + "%' ";
            }
            SqlParameter[] para = new SqlParameter[]
            {
            new SqlParameter("@Where",Where),
            new SqlParameter("@PageIndex",PageInex),
            new SqlParameter("@PageSize",PageSize),
            new SqlParameter("@AllCount",System.Data.SqlDbType.Int),
            new SqlParameter("@AllPage",System.Data.SqlDbType.Int),
            };
            para[3].Direction = System.Data.ParameterDirection.Output;
            para[4].Direction = System.Data.ParameterDirection.Output;

            var db = _dbhelper.QuerySQLPro("Show_Page", para);
            var str = JsonConvert.SerializeObject(db);
            var list = JsonConvert.DeserializeObject<List<agreement>>(str);
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    item.AllCount = Convert.ToInt32(para[3].Value);
                    item.AllPage = Convert.ToInt32(para[4].Value);
                }
            }
            return list;
        }
    }
}
