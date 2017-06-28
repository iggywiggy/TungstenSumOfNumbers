using System.Web.Http;
using System.Web.Http.ModelBinding;
using SumOfNumbers.Infastructure;

namespace SumOfNumbers
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.BindParameter(typeof(string), new StringParameterBinder());
            var provider = new StringParameterBinderProvider(new StringParameterBinder(), typeof(string));

            config.Services.Insert(typeof(ModelBinderProvider), 0, provider);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}