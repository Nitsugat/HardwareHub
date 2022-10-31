
using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class PurchaseDetail: BasesEntities.BaseEntity
    {

        [Key]
        public int DetailId { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantitly { get; set; }
        public Product? Product { get; set; }
        public Purchase? Purchase { get; set; }



    }
}
