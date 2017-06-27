using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace SumOfNumbers
{
    public static class WebContainerManager
    {
        public static IDependencyResolver GetDependencyResolver()
        {
            var dependencyResolber = GlobalConfiguration.Configuration.DependencyResolver;

            if (dependencyResolber != null)
                return dependencyResolber;

            throw new InvalidOperationException("The dependency resolver has not been set");
        }

        public static T Get<T>()
        {
            var service = GetDependencyResolver().GetService(typeof(T));

            if (service == null)
                throw new NullReferenceException($"Requested service type {typeof(T).FullName}, but null was found");

            return (T) service;
        }

        public static IEnumerable<T> GetAll<T>()
        {
            var services = GetDependencyResolver().GetServices(typeof(T)).ToList();

            if (!services.Any())
                throw new NullReferenceException($"Requested services of type {typeof(T).FullName}");

            return services.Cast<T>();
        }

        public static T Get<T>(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var service = GetDependencyResolver().GetService(Type.GetType(name));

            if (service == null)
                throw new NullReferenceException($"Requested service type {typeof(T).FullName}, but null was found");

            return (T) service;
        }
    }
}