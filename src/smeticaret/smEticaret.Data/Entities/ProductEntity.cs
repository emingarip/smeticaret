using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class ProductEntity
    {
        public int id { get; set; }
        [Required,MaxLength(50)]
        public string name { get; set; }

        [Required,Range(0,double.MaxValue),DataType(DataType.Currency)]
        public decimal price { get; set; }
        public int stock { get; set; }

        public int categoryid { get; set; }
        [ForeignKey(nameof(categoryid))]
        public categoryEntity category { get; set; }
        [Url]
        public string imageUrl { get; set; }
        public int sellerid { get; set; }

        [ForeignKey(nameof(sellerid))]
        public UserEntity user { get; set; }

    }
}
