﻿using FluentValidation;
using SmartWork.Core.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartWork.Utils.Validators
{
    public class EditUserValidator : AbstractValidator<EditUserViewModel>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(128)
                .WithMessage("Please, specify your full name");
            RuleFor(x => x.PhoneNumber).Password();
        }
    }
}