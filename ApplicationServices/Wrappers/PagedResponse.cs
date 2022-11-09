using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Wrappers
{
    public class PagedResponse<T>: Response<T>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public PagedResponse(T data , int pageSize, int pageIndex)
        {
            PageIndex=pageIndex;
            PageSize=pageSize; 
            Data = data;
            Message = null;
            Succeed = true;
            Errors = null;
        }
    }
}
