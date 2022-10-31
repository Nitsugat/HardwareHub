

using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities

{
    public class Brands: BasesEntities.BaseEntity
    {

        [Key]
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public IList<Product>? Products { get; set; }
    }
}
