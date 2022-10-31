

using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class Purchase: BasesEntities.BaseEntity
    {
        [Key]
        public int PurchaseId { get; set; }
        public int SupplierId { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DatePurchase { get; set; }
        public Supplier? Supplier { get; set; }




    }
}
