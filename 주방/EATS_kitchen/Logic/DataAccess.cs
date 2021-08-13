using EATS_kitchen.Model;
using kiosk1.Model;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kiosk1.Logic
{
    public class DataAccess
    {
        public static async Task<MessageDialogResult> ShowMessageAsync(
            string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative)
        {
            // this.
            return await ((MetroWindow)Application.Current.MainWindow)
                .ShowMessageAsync(title, message, style, null);
        }

        public static List<Ordertbl> GetOrder()
        {
            List<Ordertbl> orders;
            using (var ctx = new EATSEntities())
            {
                orders = ctx.Ordertbl.ToList();
            }
            return orders;
        }

        internal static List<OrderDetailtbl> GetDetail()
        {
            List<OrderDetailtbl> list;

            using (var ctx = new EATSEntities())
                list = ctx.OrderDetailtbl.ToList();

            return list;
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
