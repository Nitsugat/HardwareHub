using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.DTOs.DTOSadmins
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int Cuil { get; set; }
        public string? UserName { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }
        public string? TypeUser { get; set; }

    }
}
