using FluentValidation;

namespace ApplicationServices.Services.CreateCommand.BrandCommands
{
    public class CreateBrandValidation: AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandValidation()
        {
            RuleFor(x => x.BrandName)
                .NotEmpty().WithMessage("El campo no puede ser vacío")
                .MinimumLength(2).WithMessage("Este campo debe tener una longitud de caracteres mayor a 2")
                .MaximumLength(30);


        }
    }
}
