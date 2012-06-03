using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
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

		public IDependencyScope BeginScope() {
			return new UnityDependencyScope(this._container);
		}

		public void Dispose() {
			this._container.Dispose();
		}
	}

	public class UnityDependencyScope : IDependencyScope {

		private readonly IObjectContainer _container;

		public UnityDependencyScope(IObjectContainer container) {
			this._container = container;
		}

		public void Dispose() {
			//throw new NotImplementedException();
		}

		public object GetService(Type serviceType) {
			return this._container.Resolve(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType) {
			return this._container.ResolveAll(serviceType);
		}
	}
}