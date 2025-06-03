using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectCoreBLL.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        public string Name { get; set; }

        public float? ItemValue { get; set; }

        public int Category { get; set; }

        public int? CollectionItemID { get; set; }
    }
}
