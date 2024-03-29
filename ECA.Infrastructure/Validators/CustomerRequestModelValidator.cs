﻿using ECA.ViewModels.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Validators
{
    public class CustomerRequestModelValidator:AbstractValidator<CustomerRequestModel>
    {
        public CustomerRequestModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.FirstName).NotEqual("string").WithMessage("FirstName can not be equal to string");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required");
        }
    }
}
