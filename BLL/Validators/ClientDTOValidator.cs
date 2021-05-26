using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using FluentValidation;

namespace BLL.Validators
{
    public class ClientDTOValidator : AbstractValidator<ClientDTO>
    {
        public ClientDTOValidator()
        {
            RuleFor(client => client.Name).NotEmpty().NotNull();
            RuleFor(client => client.Address).NotEmpty().NotNull();
        }
    }
}
