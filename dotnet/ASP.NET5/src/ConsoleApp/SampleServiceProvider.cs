using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConsoleApp {

    public class SampleServiceProvider : IServiceProvider {

        private IDictionary<string, object> services
            = new ConcurrentDictionary<string, object>();

        public void AddService(object service) {
            var key = service.GetType().AssemblyQualifiedName;
            services[key] = service;
        }
        
        public object GetService(Type serviceType) {
            var key = serviceType.AssemblyQualifiedName;
            if (services.ContainsKey(key)) {
                return services[key];
            }
            return null;
        }
    }

}