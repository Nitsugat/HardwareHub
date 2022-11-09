using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Wrappers.Parameters
{
    public class GetAllBrandsParameters: RequestParameters
    {
        public string? BrandName { get; set; }
    }
}
