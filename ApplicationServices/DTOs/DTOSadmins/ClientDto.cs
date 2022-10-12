using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? CUIL { get; set; }
        public string? EmailAddress { get; set; }
    }
}
