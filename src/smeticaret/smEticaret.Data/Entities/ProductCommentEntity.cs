using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public  class ProductCommentEntity
    {
        public int id { get; set; }
        public int productid { get; set; }
        public ProductEntity product { get; set; }
        public int userId { get; set; }
        public UserEntity user { get; set; }
        public string message { get; set; }
        public byte starCount { get; set; }
        public DateTime createdAt { get; set; }
    }
}
