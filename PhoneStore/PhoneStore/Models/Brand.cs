using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string CountryOrigin { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
