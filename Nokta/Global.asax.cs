﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Nokta.Models;
using Raven.Client;
using Raven.Client.Document;

namespace Nokta
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
public static IDocumentStore RavenDBDocumentStore { get; private set; }
  
    private static void CreateRavenDBDocumentStore()
    {
        RavenDBDocumentStore = new DocumentStore
        {
            ConnectionStringName = "ravenDB"
       }.Initialize();
   }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CreateRavenDBDocumentStore();
           Database.SetInitializer<NoktaContext>(new DropCreateDatabaseAlways<NoktaContext>());
        }
    }
}