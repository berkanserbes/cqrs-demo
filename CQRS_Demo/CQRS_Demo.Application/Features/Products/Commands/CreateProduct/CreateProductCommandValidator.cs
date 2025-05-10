using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Demo.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
	public CreateProductCommandValidator()
	{
		RuleFor(p => p.Name)
			.NotEmpty().WithMessage("Product name is required.")
			.MinimumLength(2).WithMessage("Product name must be at least 2 characters long.")
			.MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

		RuleFor(p => p.Price)
			.GreaterThan(0).WithMessage("Product price must be greater than 0.");

	}
}
