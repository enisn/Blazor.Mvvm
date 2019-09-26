using Blazor.Mvvm.Core;
using Blazor.Mvvm.Core.Extensions;
using FluentValidation;
using FluentValidation.Internal;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Mvvm.FluentValidation.Components
{
    public class FluentValidationResourceValidator : FluentValidationValidator
    {
        public FluentValidationResourceValidator()
        {
            Events.LanguageChanged += (s, e) => ValidateModel(this.CurrentEditContext, this.Messages);
        }

        [Parameter]
        public Expression<Func<Toolbelt.Blazor.I18nText.Interfaces.I18nTextFallbackLanguage>> Resource { get; set; }

        private protected override void ValidateModel(EditContext editContext, ValidationMessageStore messages)
        {
            var validator = GetValidatorForModel(editContext.Model);
            if (validator == null)
                return;

            var validationResults = validator.Validate(editContext.Model);

            var _resource = Resource.Compile()();

            messages.Clear();
            foreach (var validationResult in validationResults.Errors)
            {
                messages.Add(editContext.Field(validationResult.PropertyName), _resource.GetValue(validationResult.ErrorCode, validationResult.ErrorMessage));
            }

            editContext.NotifyValidationStateChanged();
        }

        private protected override void ValidateField(EditContext editContext, ValidationMessageStore messages, in FieldIdentifier fieldIdentifier)
        {
            var properties = new[] { fieldIdentifier.FieldName };
            var context = new ValidationContext(fieldIdentifier.Model, new PropertyChain(), new MemberNameValidatorSelector(properties));

            var validator = GetValidatorForModel(fieldIdentifier.Model);
            if (validator == null)
                return;

            var validationResults = validator.Validate(context);

            var _resource = Resource.Compile()();

            messages.Clear(fieldIdentifier);
            foreach (var error in validationResults.Errors)
                messages.Add(fieldIdentifier, _resource.GetValue(error.ErrorCode, error.ErrorMessage));

            editContext.NotifyValidationStateChanged();
        }
        private protected override IValidator GetValidatorForModel(object model)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(model.GetType());
            var validatorInstance = Blazor.Mvvm.Startup.ServiceProvider.GetService(validatorType) as IValidator;

            return validatorInstance;
        }
    }
}
