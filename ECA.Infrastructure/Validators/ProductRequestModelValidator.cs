﻿using ECA.ViewModels.RequestModel;
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
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product Name can not be empty");
            RuleFor(x => x.ProductName).NotEqual("string").WithMessage("Product Name can not be string");
        }
    }
}
