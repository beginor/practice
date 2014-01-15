using System;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using Microsoft.Practices.Unity.Configuration;

namespace MvcTest {

    public class UnityDependencyResolver : IDependencyResolver {

        IUnityContainer container;

        public UnityDependencyResolver() {
            container = ConfigContainer();
        }

        IUnityContainer ConfigContainer() {
            IUnityContainer container = new UnityContainer();
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "unity.config");
            try {
                container.LoadConfiguration();
            }
            catch (Exception ex) {
                Console.WriteLine("Cannot config unity container from file {0}", filePath);
                Console.WriteLine(ex);
            }
            return container;
        }

        #region IDependencyResolver implementation

        object IDependencyResolver.GetService(Type serviceType) {
            object service = null;
            try {
                service = container.Resolve(serviceType);
            }
            catch (Exception ex) {
                Console.WriteLine("Can not resolve service of type: {0}", serviceType);
                Console.WriteLine(ex);
            }
            return service;
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType) {
            IEnumerable<object> services = null;
            try {
                services = container.ResolveAll(serviceType);
            }
            catch (Exception ex) {
                Console.WriteLine("Can not resolve all service of type: {0}", serviceType);
                Console.WriteLine(ex);
            }
            return services;
        }

        #endregion

    }
}

