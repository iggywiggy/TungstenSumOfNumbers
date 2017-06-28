using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace SumOfNumbers.Infastructure
{
    public class StringParameterBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var value = GetValue(bindingContext);

            if (IsStringAllNumericalDigits(value))
            {
                bindingContext.Model = value;
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName,
                Constants.ContainsNumericsErrorMessage);
            return false;
        }

        private static bool IsStringAllNumericalDigits(string toBeChecked)
        {
            if (string.IsNullOrEmpty(toBeChecked))
                throw new ArgumentNullException(nameof(toBeChecked));

            return toBeChecked.All(char.IsNumber);
        }

        private string GetValue(ModelBindingContext context)
        {
            var value = context.ValueProvider.GetValue(context.ModelName);

            return value.AttemptedValue;
        }
    }
}