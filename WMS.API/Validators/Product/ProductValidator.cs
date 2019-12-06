using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WMS.Service.Definitions.Dtos;

namespace WMS.API.Validators.Product
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty().OverridePropertyName("نام کالا");
            RuleFor(c => c.BuyPrice).NotEmpty().NotNull().GreaterThan(0).OverridePropertyName("قیمت خرید");
        }
    }
}
