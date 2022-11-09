using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.CreateCommand.ProductCreateCommand
{
    public class ProductCreateCommandValidator:AbstractValidator<ProductCreateCommand>
    {

        public ProductCreateCommandValidator()
        {
            RuleFor(x => x.ProductName)
                .NotNull().WithMessage("El nombre de la marca no puede ser nulo")
                .MaximumLength(15).WithMessage("El nombre de la marca tiene que tener una longitud menor a 15");
            RuleFor(x => x.BrandId)
                .NotNull().WithMessage("El producto debe tener una marca,¡Intente nuevamente!");
            RuleFor(x => x.HardwareCategoryId)
                .NotNull().WithMessage("El producto debe tener una categoria de hardware, ¡Intente nuevamente!");
            RuleFor(x => x.SupplierId)
                .NotNull().WithMessage("EL producto debe tener un proveedor, ¡Intente nuevamente!");
                

        }

    }
}
