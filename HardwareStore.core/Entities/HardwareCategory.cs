

using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class HardwareCategory: BasesEntities.BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Category { get; set; }
        public double Gaing { get; set; }


    }
}
