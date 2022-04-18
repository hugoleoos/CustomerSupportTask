using FluentValidation;

namespace Arvato.Domain.Models.Validations
{
    public class CustomerSupportValidation : AbstractValidator<CustomerSupport>
    {
        public CustomerSupportValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("The field {PropertyName} is riquered");
            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("The field {PropertyName} is riquered");
            RuleFor(c => c.Inquiry)
                .NotNull().WithMessage("The field {PropertyName} is riquered");
            RuleFor(c => c.DescriptionSupport)
                .NotEmpty().WithMessage($"The field {nameof(CustomerSupport.DescriptionSupport)} is riquered");
            RuleFor(c => c.Aggreement)
                .NotEqual(false).WithMessage("The field {PropertyName} is riquered");
        }
    }
}
