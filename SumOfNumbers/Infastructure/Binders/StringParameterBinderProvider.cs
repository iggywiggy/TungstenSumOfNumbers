using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SumOfNumbers.Infastructure.Binders
{
    public class StringParameterBinderProvider : ModelBinderProvider
    {
        private readonly StringParameterBinder _stringParameterBinder;
        private readonly Type _type;

        public StringParameterBinderProvider(StringParameterBinder stringParameterBinder, Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (stringParameterBinder == null)
                throw new ArgumentNullException(nameof(stringParameterBinder));

            _type = type;
            _stringParameterBinder = stringParameterBinder;
        }

        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (modelType == null)
                throw new ArgumentNullException(nameof(modelType));

            return modelType == _type ? _stringParameterBinder : null;
        }
    }
}