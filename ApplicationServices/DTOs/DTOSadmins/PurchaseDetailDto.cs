using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class PurchaseDetailDto
    {
        public int DetailId { get; set; }
        public int ProductId { get; set; }
        public int PurchaseId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantitly { get; set; }

    }
}
