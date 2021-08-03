using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInsert.Model;

namespace DataInsert.Logic
{
    class DataAccess
    {
        public static int SetOrders(Ordertbl order)
        {
            using(var ctx=new EATSEntities())
            {
                ctx.Ordertbl.AddOrUpdate(order);
                return ctx.SaveChanges();   // commit
            }

        }
    }
}
