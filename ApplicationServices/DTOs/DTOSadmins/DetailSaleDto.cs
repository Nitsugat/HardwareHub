

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class DetailSaleDto
    {
        public int DetailId { get; set; }
        public string? ProductoName { get; set; }
        public int Quantitly { get; set; }
        public int PriceUnit { get; set; }
        public string? Date { get; set; }
        public ProductDto? ProductDto { get; set; }

    }
}