using System;
using System.Collections.Generic;
using System.Web.Http.Services;
using GDEIC.AppFx.Unity;

namespace HttpWebApp {

	public class UnityDependencyResolver : IDependencyResolver {

		private readonly IObjectContainer _container;

		public UnityDependencyResolver(IObjectContainer container) {
			this._container = container;
		}

		public object GetService(Type serviceType) {
			return this._container.Resolve(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType) {
			return this._container.ResolveAll(serviceType);
		}

	}

}