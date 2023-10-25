using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class UserEntity
    {
        public int id { get; set; }
        [Required,MaxLength(50)]
        public string name { get; set; }
        [Required, MaxLength(50)]
        public string lastName { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
        [Required]
        public string passwordHash { get; set; }

        public int RoleID { get; set; }
        [ForeignKey(nameof(RoleID))]
        public RoleEntity role { get; set; }

    }
}
