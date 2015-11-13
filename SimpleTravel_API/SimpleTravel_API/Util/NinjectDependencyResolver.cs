using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleTravel.Infrastructure;
using Ninject;
using System.Web.Mvc;
using Ninject.Web.WebApi;
using Ninject.Syntax;
using Ninject.Parameters;
using System.Web.Http.Dependencies;
using Ninject.Activation;
using SimpleTravel.Infrastructure.Repositories.Implementation;

namespace SimpleTravel_API.Util
{
    public class NinjectResolver : NinjectScope, System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            NinjectScope ns = new NinjectScope(_kernel.BeginBlock());
            return (IDependencyScope)ns;
        }
    }

    public class NinjectScope : System.Web.Http.Dependencies.IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;
        public NinjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }
        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }
        public void Dispose()
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }
    }

    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
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
            kernel.Bind<IRepository<Apartment>>().To<ApartmentRepository>();
            kernel.Bind<IRepository<Trip>>().To<TripRepository>();
            //kernel.Bind<IReservation>().To<CacheReservation>();
            //kernel.Bind<IReservation>().To<CreditReservation>().Named("Values");
        }
    }
}