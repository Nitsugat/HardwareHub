
using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class TypeUser: BasesEntities.BaseEntity
    {
        [Key]
        public int TypeId { get; set; }
        public string? Type { get; set; }
    }
}
