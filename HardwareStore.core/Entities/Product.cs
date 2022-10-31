using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardwareHub.core.Entities
{
    public class Product: BasesEntities.BaseEntity
    {

        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int BrandId { get; set; }
        public string? ImgProduct { get; set; }
        public int? HardwareCategoryId { get; set; }
        public int SupplierId { get; set; }
        public string? Desciption { get; set; }
        public bool State { get; set; }
        public Supplier? Supplier { get; set; }
        public HardwareCategory? HardwareCategory { get; set; }
        public Brands? Brand { get; set; }

    }
}
