using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.UpdateCommands.Brand
{
    public class UpdateBrandCommandValidator:AbstractValidator<UpdateBrandCommand>
    {

        public UpdateBrandCommandValidator()
        {
            RuleFor(z => z.BrandId)
                .NotNull().WithMessage("La marca con el Id proveeido no existe.");
            RuleFor(b => b.BrandName)
                .NotNull()
                .MinimumLength(3).WithMessage("El nombre de la marca debe tener una longitud de caracteres mayor a 3.");

        }
      
    }
}
