using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Ninject;

namespace SumOfNumbers
{
    public sealed class NinjectDependencyResolver : IDependencyResolver
    {
        public NinjectDependencyResolver(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            Container = container;
        }

        public IKernel Container { get; }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            return Container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            return Container.GetAll(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }
    }
}