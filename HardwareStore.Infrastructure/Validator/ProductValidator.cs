using FluentValidation;
using HardwareHub.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHub.Infrastructure.Validator
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductName)
                .MaximumLength(12)
                .MinimumLength(3);

            

            RuleFor(product => product.ImgProduct)
                .NotEmpty();

        
                
             
        }
    }
}
