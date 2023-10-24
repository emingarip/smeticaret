using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class OrderItemEntity
    {
        public int id { get; set; }
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public OrderEntity order { get; set; }

        public int  productid { get; set; }

        [ForeignKey(nameof(productid))]
        public ProductEntity product { get; set; }

        [Required,Range(1,int.MaxValue)]
        public int quantity { get; set; }

        [Required,Range(0,double.MaxValue),DataType(DataType.Currency)]
        public decimal paid { get; set; }
    }
}
