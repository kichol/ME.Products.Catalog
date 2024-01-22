using AutoMapper;
using ME.Products.Application.Contracts.Persistence;
using ME.Products.Domain.Entities;
using MediatR;

namespace ME.Products.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public CreateProductCommandHandler(IMapper mapper, IProductRepository ProductRepository)
        {
            _mapper = mapper;
            _productRepository = ProductRepository;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var createProductCommandResponse = new CreateProductCommandResponse();

            var validator = new CreateProductCommandValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createProductCommandResponse.Success = false;
                createProductCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createProductCommandResponse.Success)
            {
                var Product = new Product() { 
                    Name = request.Name, 
                    Code = request.Code,
                    Price = request.Price
                };
                Product = await _productRepository.AddAsync(Product);
                createProductCommandResponse.Product = _mapper.Map<CreateProductDto>(Product);
            }

            return createProductCommandResponse;

   
        }
    }
}