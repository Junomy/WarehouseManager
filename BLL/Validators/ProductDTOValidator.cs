using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using FluentValidation;

namespace BLL.Validators
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(product => product.Name).NotEmpty().NotNull();
            RuleFor(product => product.Price).NotNull().GreaterThan(0);
        }
    }
}
