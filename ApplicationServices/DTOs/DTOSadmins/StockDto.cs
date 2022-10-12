using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class StockDto
    {
        public int StockId { get; set; }
        public string? ProductName { get; set; }
        public int Quantitly { get; set; }
        public double PublicPrice { get; set; }
        public string? DateUpdate { get; set; }

    }
}
