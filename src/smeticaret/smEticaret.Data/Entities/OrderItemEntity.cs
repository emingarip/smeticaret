using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class OrderItemEntity
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public OrderEntity order { get; set; }
        public int  productid { get; set; }
        public ProductEntity product { get; set; }
        public int quantity { get; set; }
        public decimal paid { get; set; }
    }
}
