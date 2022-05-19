using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations;

public class CustomerCreditCardDtoValidator : AbstractValidator<CustomerCreditCardDto>
{
    public CustomerCreditCardDtoValidator()
    {
        RuleFor(x => x.CardBrand).NotNull().WithMessage("{PropertyName} is required").NotEmpty()
            .WithMessage("{PropertyName} is required");
        RuleFor(x => x.CardPan).NotNull().WithMessage("{PropertyName} is required").NotEmpty()
            .WithMessage("{PropertyName} is required");
        RuleFor(x => x.CustomerId).NotNull().WithMessage("{PropertyName} is required").NotEmpty()
            .WithMessage("{PropertyName} is required");
        RuleFor(x => x.StatusId).NotNull().WithMessage("{PropertyName} is required").NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}