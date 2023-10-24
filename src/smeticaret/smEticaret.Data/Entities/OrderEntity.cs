using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class OrderEntity
    {
        public int id { get; set; }
        public int userid { get; set; }
        [ForeignKey(nameof(userid))]
        public UserEntity user { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required, MaxLength(250)]
        public string DeliveryAdress { get; set; }
    }
}
