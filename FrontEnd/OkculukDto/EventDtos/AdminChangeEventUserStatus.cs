using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkculukDto.EventDtos
{
    public class AdminChangeEventUserStatus
    {
        public int EventUserId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }


    }
}
