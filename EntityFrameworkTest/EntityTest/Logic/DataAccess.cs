﻿using EntityInsertTest.Model;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

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
