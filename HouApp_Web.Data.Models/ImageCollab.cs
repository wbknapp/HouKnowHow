using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouApp_Web.Data.Models
{
    public class ImageCollab
    {
        public int ImageCollabId { get; set; }
        public string LocLat { get; set; }
        public string LocLong { get; set; }

        public string Address { get; set; }
        public string UrlString { get; set; }
        public string PostType { get; set; }

        public string Description { get; set; }
    }
   
}
