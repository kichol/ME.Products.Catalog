using FluentValidation;

namespace ME.Products.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyCode} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyCode} must not exceed 50 characters.");

            RuleFor(p => p.Price)
               .NotEmpty()
               .GreaterThan(0)
                .WithMessage("{Price should be greater than zero.");


        }
    }
}
