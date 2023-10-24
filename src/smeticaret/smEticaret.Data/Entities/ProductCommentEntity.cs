using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public  class ProductCommentEntity
    {
        public int id { get; set; }
        public int productid { get; set; }
        [ForeignKey(nameof(productid))]
        public ProductEntity product { get; set; }
        public int userId { get; set; }
        [ForeignKey(nameof(userId))]
        public UserEntity user { get; set; }
        [Required,MaxLength(250)]
        public string message { get; set; }
        [Required,Range(1,5)]
        public byte starCount { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
    }
}
