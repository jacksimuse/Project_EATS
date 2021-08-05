using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EATS_kitchen.Model;
using System.Collections.Generic;
using System.Linq;

namespace EATS_kitchen
{
    public class Commons
    {
        public static async Task<MessageDialogResult> ShowMessageAsync(
            string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative)
        {
            // this.
            return await ((MetroWindow)Application.Current.MainWindow)
                .ShowMessageAsync(title, message, style, null);
        }

        internal static List<OrderDetailtbl> GetDetail()
        {
            List<OrderDetailtbl> list;

            using (var ctx = new EATSEntities())
                list = ctx.OrderDetailtbl.ToList();

            return list;
        }


    }
}
