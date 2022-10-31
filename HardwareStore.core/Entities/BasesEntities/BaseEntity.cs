using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHub.core.Entities.BasesEntities
{
    public class BaseEntity
    {

        public int CreateBy { get; set; }
        public DateTime CreationDate { get; set; }  
        public DateTime LastModified { get; set; }
        public bool State { get; set; }
    }
}
