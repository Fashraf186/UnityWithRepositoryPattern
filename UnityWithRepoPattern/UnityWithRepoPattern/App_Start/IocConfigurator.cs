using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Unity;
using UnityWithRepoPattern.Interface;
using UnityWithRepoPattern.Models;
using UnityWithRepoPattern.Repository;
using UnityWithRepoPattern.Services;

namespace UnityWithRepoPattern.App_Start
{
    public class IocConfigurator               // For unity framework and dependency Resolver
    {
        public static void ConfigureIocUnityContainer()         
        {
            IUnityContainer container = new UnityContainer();      // Make an object of Iunitycontainer 

            registerServices(container);                 //pass it to registerservices() method.

            DependencyResolver.SetResolver(new DemoDependencyResolver(container)); //it is use to resolve the dependency of the instances 
        }

        private static void registerServices(IUnityContainer container)  //this method is used to register the classes to container of iunity
        {
            container.RegisterType<_IGenericRepo<Course>, GenericRepo<Course>>();
            container.RegisterType<_IGenericRepo<Student>, GenericRepo<Student>>();
            container.RegisterType<_IGenericRepo<Enrollment>, GenericRepo<Enrollment>>();
          
        }

       
    }
}