using FluentValidation;
using HardwareHub.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHub.Infrastructure.Validator
{
    public class ProveedorValidator: AbstractValidator<Supplier>
    {
        public ProveedorValidator()
        {
            RuleFor(p => p.EmailAddress)
                .EmailAddress();
            RuleFor(p => p.SupplierName)
                .NotEmpty();
            RuleFor(p => p.PhoneNumber)
                .Length(11, 13);


        }

    }
}
