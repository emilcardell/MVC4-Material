using System.Web.Http;
using System.Web.Mvc;
using Store_Front_Base.DependencyResolution;
using StructureMap;
using StructureMap.ServiceLocatorAdapter;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Store_Front_Base.App_Start.StructuremapMvc), "Start")]

namespace Store_Front_Base.App_Start {
    public static class StructuremapMvc {
        public static void Start() {
            var container = (IContainer) IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
			// this override is needed because WebAPI is not using DependencyResolver to build controllers 
        }
    }
}