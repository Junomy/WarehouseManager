using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using FluentValidation;

namespace BLL.Validators
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(driver => driver.Name).NotEmpty().NotNull();
            RuleFor(driver => driver.Surname).NotEmpty().NotNull();
            RuleFor(driver => driver.EmploymentDate).NotNull().Must(BeAValidDate);
            RuleFor(driver => driver.Hours).NotNull().InclusiveBetween(0, 12);
            RuleFor(driver => driver.Wage).NotNull().GreaterThan(0);
            RuleFor(driver => driver.Rating).NotNull().InclusiveBetween(0, 5);
        }
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
