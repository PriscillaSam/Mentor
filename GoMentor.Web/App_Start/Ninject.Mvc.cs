using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Ninject.Mvc
{
    //  A small Library to configure Ninject (A Dependency Injection Library) with a WebAPI Application. 
    //  To configure, take the following steps.
    // 
    //  1. Install Packages Ninject and Ninject.Web.Common 
    //  2. Remove NinjectWebCommon.cs in your App_Start Directory
    //  3. Add this file to your project  (preferrably in the App_Start Directory)  
    //  4. Add Your Bindings to the Load method of MainModule. 
    //     You can add as many additional modules to keep things organized
    //     simply add them to the Modules property of the NinjectModules class
    //  5. Add the following Line to your Global.asax
    //          NinjectContainer.RegisterModules(NinjectModules.Modules);
    //  5b.To Automatically Register all NinjectModules in the Current Project, You should instead add
    //          NinjectContainer.RegisterAssembly()
    //  You are done. 


    /// <summary>
    /// Resolves Dependencies Using Ninject
    /// </summary>
    public class NinjectResolver : IDependencyResolver
    {
        /// <summary>
        /// Represents the Core Kernel of the IOC Container
        /// </summary>
        public IKernel Kernel { get; private set; }

        /// <summary>
        /// Creates a new Instance of th Ninject Resolver with the modules Supplied
        /// </summary>
        /// <param name="modules">Modules to Load</param>
        public NinjectResolver(params NinjectModule[] modules)
        {
            Kernel = new StandardKernel(modules);
        }

        /// <summary>
        /// Creates a new Instance of th Ninject Resolver by loading Modules
        /// from the Assembly Supplied
        /// </summary>
        /// <param name="assembly">Assembly to Load Modules</param>
        public NinjectResolver(Assembly assembly)
        {
            Kernel = new StandardKernel();
            Kernel.Load(assembly);
        }

        /// <summary>
        /// Creates an Instance of an Object based on the Type information Supplied
        /// </summary>
        /// <param name="serviceType">Type of Object to resolve</param>
        /// <returns>Instance of the Object</returns>
        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Returns all the instance based on the bindings of that type
        /// </summary>
        /// <param name="serviceType">Type to create Instances of</param>
        /// <returns>Instances of the Objects based on the Bindings</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }
    }


    /// <summary>
    /// Its job is to Register Ninject Modules and Resolve Dependencies Manually (If need be)
    /// </summary>
    public class NinjectContainer
    {
        private static NinjectResolver _resolver;

        /// <summary>
        /// Sets up the IOC using the Ninject Modules provided
        /// </summary>
        /// <param name="modules">Modules</param>
        public static void RegisterModules(params NinjectModule[] modules)
        {
            _resolver = new NinjectResolver(modules);
            DependencyResolver.SetResolver(_resolver);
        }

        /// <summary>
        /// Sets up the IOC Container loading modules from the Currently Executing Assembly
        /// </summary>
        public static void RegisterAssembly()
        {
            _resolver = new NinjectResolver(Assembly.GetExecutingAssembly());

            //This is where the actual hookup to the MVC Pipeline is done.
            DependencyResolver.SetResolver(_resolver);
        }

        /// <summary>
        /// Manually Resolve Dependencies 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _resolver.Kernel.Get<T>();
        }
    }
}