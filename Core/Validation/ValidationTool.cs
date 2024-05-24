﻿using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Core.Validation
{
    public class ValidationTool
    {
        public static bool Validate(IValidator validator, object entity, out List<ValidationErrorModel> errors)
        {
            errors = Enumerable.Empty<ValidationErrorModel>().ToList();
            ValidationErrorModel model = null;
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                  
                    model = new ValidationErrorModel();
                    model.ErrorMessage = item.ErrorMessage;
                    model.ErrorCode = item.ErrorCode;
                    model.PropertyName = item.PropertyName;
                    errors.Add(model);
                }
            }

            return result.IsValid;
        }
    }
}
