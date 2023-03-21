using DAL.GF.DTO;
using FluentValidation;

namespace DAL.GF.Utils
{
    public class RemissionValidations: AbstractValidator<RemissionsDTO>
    {
        public RemissionValidations()
        {
            RuleFor(r => r.TechnicalCode).NotNull();
            RuleFor(r => r.ItemCode).NotNull();
            RuleFor(r => r.RemissionQuantity).ExclusiveBetween(0, 10).WithMessage("Quantity should be between 1 and 10");
        }
    }
}
