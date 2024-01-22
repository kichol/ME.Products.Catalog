using FluentValidation;
using ME.Products.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ME.Products.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandValidator(IProductRepository ProductRepository)
        {
            _productRepository = ProductRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Code)
                .NotEmpty().WithMessage("{PropertyCode} is required.")
                .NotNull();

            RuleFor(e => e)
                .MustAsync(ProductNameAndCodeUnique)
                .WithMessage("An Product with the same name and code already exists.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("{Price should be greater than zero.");

            RuleFor(p => p.Price)
                .PrecisionScale(10, 2, true)
                .WithMessage("{Price should have max 2 scale.");
        }

        private async Task<bool> ProductNameAndCodeUnique(CreateProductCommand e, CancellationToken token)
        {
            return !await _productRepository.IsProductNameAndCodeUnique(e.Name, e.Code);
        }
    }
}
