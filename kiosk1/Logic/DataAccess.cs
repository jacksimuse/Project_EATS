using kiosk1.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk1.Logic
{
    public class DataAccess
    {
        public static List<Ordertbl> GetOrder()
        {
            List<Ordertbl> orders;
            using (var ctx = new EATSEntities())
            {
                orders = ctx.Ordertbl.ToList();
            }
            return orders;
        }

        public static int SetOrder(Ordertbl order)
        {
            using (var ctx = new EATSEntities())
            {
                ctx.Ordertbl.AddOrUpdate(order);
                return ctx.SaveChanges(); // commit
            }
        }

        public static List<Menutbl> GetMenu()
        {
            List<Menutbl> menus;
            using (var ctx = new EATSEntities())
            {
                menus = ctx.Menutbl.ToList();
            }
            return menus;
        }

        public static int SetMenu(Menutbl menu)
        {
            using (var ctx = new EATSEntities())
            {
                ctx.Menutbl.AddOrUpdate(menu);
                return ctx.SaveChanges(); // commit
            }
        }
    }
}
