using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOTT2._0.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HOTT2._0.Repository
{
    public class PostRepository:IPostRepository 
    {
        HOTTEntities db;
        public PostRepository(HOTTEntities _db)
        {
            db = _db;
        }

        public async Task<HoTT_Hotline_Report_Rawdata> GetPosts()
        {
            if (db != null)
            {
                var query = from p in db.HoTT_Hotline_Report_Rawdata
                            select p;


                return await query.ToList();
            }

            return null;
        }

    }
}