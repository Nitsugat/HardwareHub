using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class ProductDto
    {

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int BrandId { get; set; }
        public int? HardwareCategory { get; set; }
        public int? Supplier { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }

    }
}
