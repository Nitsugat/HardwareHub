

using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class Supplier: BasesEntities.BaseEntity
    {

        [Key]
        public int SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string? SupplierSurname { get; set; }
        public string? CUIL { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }


    }
}
