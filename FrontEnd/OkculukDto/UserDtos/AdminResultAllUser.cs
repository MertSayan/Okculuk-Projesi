using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkculukDto.UserDtos
{
    public class AdminResultAllUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string RegionName { get; set; }
        public string InstitutionName { get; set; }
    }
}
