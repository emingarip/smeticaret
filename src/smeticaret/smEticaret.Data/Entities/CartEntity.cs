using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class CartEntity
    {
        public int id { get; set; }
        public int userid { get; set; }

        [ForeignKey(nameof(userid))]
        public UserEntity user { get; set; }
    }
}
