﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_Demo.Application.Features.Products.Dtos;

public class ProductDto
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public decimal Price { get; set; }
}
