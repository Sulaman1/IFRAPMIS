using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain.UsersAndRoles
{
    public class RoleViewModel
    {
        public string RoleName { get; set; }
        public int UserCount { get; set; }
        public List<UserViewModel> Users { get; set; }
    }

}
