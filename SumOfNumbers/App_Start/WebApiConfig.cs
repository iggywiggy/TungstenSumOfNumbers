using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using SumOfNumbers.Infastructure.Logging;
using SumOfNumbers.Interfaces;
using ExceptionLogger = SumOfNumbers.Infastructure.Logging.ExceptionLogger;

namespace SumOfNumbers
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(ITraceWriter), new LogWriter(WebContainerManager.Get<ILogManager>()));
            config.Services.Add(typeof(IExceptionLogger), new ExceptionLogger(WebContainerManager.Get<ILogManager>()));
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}