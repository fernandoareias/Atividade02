﻿using System;
using FluentValidation.Results;

namespace Atividade02.Core.Common.Validators.Interfaces
{
    public interface IValidatorServices
    {
        ValidationResult ValidationResult { get; set; }
        void AddError(string message);

        void AddError(string code, string message);
        void AddError(ValidationResult validationResult);
    }
}

