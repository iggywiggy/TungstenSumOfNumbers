﻿using System;
using Ninject;
using SumOfNumbers.Classes;
using SumOfNumbers.Interfaces;

namespace SumOfNumbers
{
    public class NinjectConfigurator
    {
        public void Configure(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            AddBindings(container);
        }

        private static void AddBindings(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            ConfigureProcessors(container);
        }

        private static void ConfigureProcessors(IKernel container)
        {
            if (container == null)
                throw new ArgumentNullException(nameof(container));

            container.Bind<IAddProcessor>().To<AddProcess>();
        }
    }
}