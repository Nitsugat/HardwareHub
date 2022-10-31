using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services.CreateCommand.HardwareCategories
{
    public class CreateHardwareCategorieValidator:AbstractValidator<HardwareCategorieCreateCommand>
    {
        public CreateHardwareCategorieValidator()
        {
            RuleFor(c => c.Category)
                .NotEmpty()
                .NotNull();
            RuleFor(c => c.Gaing)
                .NotEmpty()
                .NotNull()
                .LessThan(100.0);
                
        }
    }
}
