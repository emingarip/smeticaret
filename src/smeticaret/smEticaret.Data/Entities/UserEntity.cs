using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class UserEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public int RoleID { get; set; }
        public ICollection<RoleEntity> role { get; set; }

    }
}
