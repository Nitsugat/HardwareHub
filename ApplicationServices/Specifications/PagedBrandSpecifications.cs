using Ardalis.Specification;
using HardwareHub.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Specifications
{
    public class PagedBrandSpecifications: Specification<Brands>
    {

        public PagedBrandSpecifications(int pageSize , int pageNumber, string brandName)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(brandName))
            {
                Query.Search(x => x.BrandName , "%" + brandName + "%");
            } 

        }
    }
}
