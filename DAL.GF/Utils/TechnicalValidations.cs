using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GF.Utils
{
    public class TechnicalValidations: AbstractValidator<TechnicalsDTO>
    {
        public TechnicalValidations()
        {
            RuleFor(t => t.TechnicalCode).NotNull()
                .NotEmpty()
                .WithMessage("This field is required")
                .Matches(@"^[a-zA-Z0-9\-']*$");
            RuleFor(t => t.TechnicalFullName).NotNull().Length(1, 30)
                .WithMessage("It's greather than the quantity established");
            RuleFor(t => t.BranchOfficeCode).NotNull()
                 .NotEmpty()
                .WithMessage("This field is required");               
                
        }
    }
}
