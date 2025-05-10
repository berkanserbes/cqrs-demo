using CQRS_Demo.Application.Features.Products.Dtos;
using CQRS_Demo.Domain.Entities;
using CQRS_Demo.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Demo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
	private readonly AppDbContext _context;

	public CreateProductCommandHandler(AppDbContext context)
	{
		_context = context;
	}

	public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var product = new Product
		{
			Name = request.Name,
			Price = request.Price
		};

		await _context.Products.AddAsync(product, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);

		return new ProductDto
		{
			Id = product.Id,
			Name = product.Name,
			Price = product.Price
		};
	}
}
