using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class ProductEntity
    {
        public int id { get; set; }
        public string name { get; set; }

        public decimal price { get; set; }
        public int stock { get; set; }

        public int categoryid { get; set; }
        public categoryEntity category { get; set; }
        public string imageUrl { get; set; }
        public int sellerid { get; set; }

    }
}
