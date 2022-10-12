using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class SaleDto
    {
        public int SaleId { get; set; }
        public int ClientName { get; set; }
        public int ProductId { get; set; }
        public int DetailSaleId { get; set; }
        public ClientDto? Client { get; set; }
        public ProductDto? ProductDto { get; set; }
        public DetailSaleDto? DetailSale { get; set; }
    }
}
