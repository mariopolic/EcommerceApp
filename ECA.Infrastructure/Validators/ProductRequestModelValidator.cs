using ECA.ViewModels.RequestModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Validators
{
    public class ProductRequestModelValidator:AbstractValidator<ProductRequestModel>
    {
        public ProductRequestModelValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName can not be empty");
        }
    }
}
