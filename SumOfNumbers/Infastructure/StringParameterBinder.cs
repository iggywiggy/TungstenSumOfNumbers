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

            if (bindingContext.ModelType != typeof(string))
                return false;

            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (value == null)
                return false;

            var key = value.AttemptedValue;


            return ValidateInput(bindingContext, key);
        }

        private static bool ValidateInput(ModelBindingContext bindingContext, string key)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            if (string.IsNullOrEmpty(key))
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, Constants.WrongValueType);
                return false;
            }

            if (HasNoneNumericalDigits(key))
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName,
                    Constants.ContainsNoneNumericsErrorMessage);
                return false;
            }


            if (Utils.ConvertStringToInt(key, out long _))
            {
                bindingContext.Model = key;
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName,
                Constants.CannotConvertStringToInteger);
            return false;
        }


        private static bool HasNoneNumericalDigits(string toBeChecked)
        {
            if (toBeChecked == null)
                throw new ArgumentNullException(nameof(toBeChecked));

            return string.IsNullOrEmpty(toBeChecked) && !toBeChecked.All(char.IsNumber);
        }
    }
}