using AutoMapper;
using ME.Products.Application.Contracts.Persistence;
using ME.Products.Application.Exceptions;
using ME.Products.Domain.Entities;
using MediatR;

namespace ME.Products.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IAsyncRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            _mapper = mapper;
            _productRepository = ProductRepository;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var ProductToUpdate = await _productRepository.GetByIdAsync(request.ProductId);
            if (ProductToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            var updateProductCommandResponse = new UpdateProductCommandResponse();

            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, ProductToUpdate, typeof(UpdateProductCommand), typeof(Product));

            await _productRepository.UpdateAsync(ProductToUpdate);

            return updateProductCommandResponse;

        }
    }
}