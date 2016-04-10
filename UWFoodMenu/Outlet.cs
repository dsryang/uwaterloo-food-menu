using System.Collections.Generic;

namespace UWFoodMenu
{
    public class Outlet
    {
        public string outlet_name { get; set; }
        public int outlet_id { get; set; }
        public List<Menu> menu { get; set; }
    }
}