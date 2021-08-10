using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk1.Model
{
    public class Tables
    {
        public Tables() => MenuList = new List<MenuItems>();
        
        public int TableNum { get; set; }
        public List<MenuItems> MenuList { get; set; }
    }
}
