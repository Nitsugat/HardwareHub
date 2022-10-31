

using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class User: BasesEntities.BaseEntity
    {

        [Key]
        public int UserId { get; set; }
        public int Cuil { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }
        public int TypeUserId { get; set; }
        public TypeUser? Type { get; set; }


    }
}
