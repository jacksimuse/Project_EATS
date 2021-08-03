using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTest.model;
namespace OrderTest.Logic
{
    class DataAccess
    {
        public static List<Menutbl> GetMenus()
        {
            List<Menutbl> menus;
            using (var db = new EATSEntities())
            {
                menus = db.Menutbl.ToList();
            }
            return menus;
        }
    }
}
