using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  HOTT2._0.Models;

namespace HOTT2._0.Repository
{
    interface IPostRepository
    {
            Task<List<HoTT_Hotline_Report_Rawdata>> GetPosts();
        
    }
}
