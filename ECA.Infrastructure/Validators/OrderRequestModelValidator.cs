using ECA.ViewModels.RequestModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Validators
{
    public class OrderRequestModelValidator:AbstractValidator<OrderRequestModel>
    {
        public OrderRequestModelValidator()
        {
            RuleFor(x => x.customerId).NotEmpty().WithMessage("customerId can not be null");
        }
    }
}
