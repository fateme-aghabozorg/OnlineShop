using Online_Store.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public bool IsActive;

        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // '1' user has 'n' roles
        public ICollection<UserInRole> UserInRoles { get; set; }
        public DateTime RemoveTime { get; set; }
    }
}
