using System.Web;
using System.Web.Http;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();

            if (exception == null)
                return;

            var log = WebContainerManager.Get<ILogManager>().GetLog(typeof(WebApiApplication));
            log.Error("Unhandled exception.", exception);
        }
    }
}