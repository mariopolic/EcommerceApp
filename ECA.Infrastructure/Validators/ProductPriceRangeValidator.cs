using ECA.Infrastructure.RequestModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Validators
{
    public class ProductPriceRangeValidator:AbstractValidator<ProductPriceRangeRequestModel>
    {
        public ProductPriceRangeValidator()
        {
            RuleFor(x => x.MinPrice).GreaterThanOrEqualTo(0).WithMessage("Min price can not be less than 0");
            RuleFor(x => x.MaxPrice).GreaterThan(x => x.MinPrice).WithMessage("min price can not be greater than max");
        }
    }
}
