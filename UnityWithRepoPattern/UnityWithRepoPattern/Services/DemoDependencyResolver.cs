using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace UnityWithRepoPattern.Services
{
    public class DemoDependencyResolver : IDependencyResolver         //this class implement interface of IdependencyResolver
    {
        private IUnityContainer _unitcontainer;           //make an object of Iunitycontainer

        public DemoDependencyResolver(IUnityContainer unitcontainer)      //initiazile the object of the unity container
        {
            _unitcontainer = unitcontainer;
        }
        public object GetService(Type serviceType)         //this used to resolve the dependency 
        {
            try
            {
                return _unitcontainer.Resolve(serviceType);

            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) //this used to resolve the dependency of IEnumerable objects
        {
            {
                try
                {
                    return _unitcontainer.ResolveAll(serviceType);

                }
                catch (Exception)
                {
                    return new List<object>();
                }
            }
        }
    }
}