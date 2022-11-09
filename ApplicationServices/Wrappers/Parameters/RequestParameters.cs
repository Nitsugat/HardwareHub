using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Wrappers.Parameters
{
    public class RequestParameters
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public RequestParameters()
        {
            PageSize = 4;
            PageIndex = 1;
        }
        public RequestParameters(int pageIndex, int pageSize)
        {
            PageSize = pageSize > 10 ? 10 : pageSize;
            PageIndex = pageIndex > 1 ? 1 : pageIndex;
        }
    }
}
