

using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class Stock: BasesEntities.BaseEntity
    {

        [Key]
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int Quantitly { get; set; }
        public double PublicPrice { get; set; }
        public DateTime DateUpdate { get; set; }
        public Product? Product { get; set; }
    }
}
