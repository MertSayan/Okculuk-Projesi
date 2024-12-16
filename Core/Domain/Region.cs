using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }
        public List<User> Users { get; set; }
    }
}
