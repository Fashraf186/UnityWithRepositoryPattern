using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using UnityWithRepoPattern.Interface;
using UnityWithRepoPattern.Models;
using UnityWithRepoPattern.Repository;

namespace UnityWithRepoPattern
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<_IGenericRepo<Course>, GenericRepo<Course>>();
            container.RegisterType<_IGenericRepo<Student>, GenericRepo<Student>>();
            container.RegisterType<_IGenericRepo<Enrollment>, GenericRepo<Enrollment>>();
           

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

           
        }
    }
}