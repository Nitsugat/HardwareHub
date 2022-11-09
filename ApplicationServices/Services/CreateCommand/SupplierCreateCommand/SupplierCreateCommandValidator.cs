using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.CreateCommand.SupplierCreateCommand
{
    public class SupplierCreateCommandValidator:AbstractValidator<SupplierCreateCommand>
    {
        public SupplierCreateCommandValidator()
        {
            RuleFor(s => s.EmailAddress)
                .EmailAddress().WithMessage("Error, Ingrese un email valido")
                .NotEmpty();
            RuleFor(s => s.CUIL)
                .NotNull().WithMessage("El cuil no debe ser nulo, ingrese un numero de cuil para el proveedor")
                .MinimumLength(10).WithMessage("Ingrese un CUIL valido, el cuil debe tener una longitud mayor a 10 y menor a 12")
                .MaximumLength(12).WithMessage("Ingrese un CUIL valido, el cuil debe tener una longitud mayor a 10 y menor a 12");
            RuleFor(x => x.SupplierName)
                .NotNull()
                .MaximumLength(15)
                .MinimumLength(3);
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(12).WithMessage("Ingrese un numero de telefono válido (caracteristica) + (numero)")
                .MinimumLength(10).WithMessage("Ingrese un numero de telefono válido (caracteristica) + (numero)")
                .NotNull();

  
        }
    }
}
