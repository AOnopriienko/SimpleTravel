using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnionApp.Domain.Core;
using OnionApp.Domain.Interfaces;
using OnionApp.Infrastructure.Business;
using OnionApp.Infrastructure.Data;
using OnionApp.Services.Interfaces;
using Ninject;
using System.Web.Mvc;

namespace SimpleTravel_API.Util
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IAccommodationRepository>().To<AccommodationRepository>();
            kernel.Bind<IReservation>().To<CacheReservation>();
        }
    }
}