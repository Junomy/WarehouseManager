using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using FluentValidation;

namespace BLL.Validators
{
    class ProvidersDTOValidator : AbstractValidator<ProviderDTO>
    {
        public ProvidersDTOValidator()
        {
            RuleFor(provider => provider.Name).NotNull().NotEmpty();
            RuleFor(provider => provider.Address).NotNull().NotEmpty();
        }
    }
}
