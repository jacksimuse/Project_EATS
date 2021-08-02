using EntityInsertTest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest.Logic
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
    }
}
