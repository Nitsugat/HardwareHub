
using HardwareHub.core.Entities.BasesEntities;
using System.ComponentModel.DataAnnotations;

namespace HardwareHub.core.Entities
{
    public class Client: BaseEntity
    {

        [Key]
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CUIL { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }


    }
}
