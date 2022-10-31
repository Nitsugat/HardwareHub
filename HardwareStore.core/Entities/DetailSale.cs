

using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class DetailSale:BasesEntities.BaseEntity
    {

        [Key]
        public int DetailId { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantitly { get; set; }
        public Product? Product { get; set; }
        public Sale? Sale { get; set; }

    }
}
