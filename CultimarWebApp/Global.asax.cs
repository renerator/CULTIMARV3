using CultimarWebApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;

namespace CultimarWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MvcApplication));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["Conexion"];
            DataSource.SetParametros(cadenaConexion);

            XmlConfigurator.Configure();
            XmlConfigurator.Configure(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.xml"));
            Log.Info("Log4Net Activado");

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            XmlConfigurator.Configure();
            XmlConfigurator.Configure(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.xml"));
            
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;
            int error = httpException != null ? httpException.GetHttpCode() : 0;

            Log.Info(string.Format("Codigo de Error: {0} | Mensaje de Error: {1}",error.ToString(), exception.Message));

            Server.ClearError();

            Response.RedirectToRoute(new { controller = "Error", action = "Index", error = error });
        }
    }
}
