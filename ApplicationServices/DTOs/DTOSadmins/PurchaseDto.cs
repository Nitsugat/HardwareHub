using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class PurchaseDto
    {
        public int PurchaseId { get; set; }
        public string? SupplierName { get; set; }
        public int TotalPrice { get; set; }
        public string? Date { get; set; }


    }
}
