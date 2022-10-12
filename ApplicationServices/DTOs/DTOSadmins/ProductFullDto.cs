using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class ProductFullDto
    {

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? BrandName { get; set; }
        public string? Description { get; set; }
        public bool State { get; set; }
        public string? HardwareCategory { get; set; }
        public string? SupplierName { get; set; }
        public string? ImgProduct { get; set; }
    }
}
