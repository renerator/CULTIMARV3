using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CultimarWebApp.Controllers
{
    public class ErrorController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Error
        public ActionResult Index(int error = 0)
        {
            switch (error)
            {
                case 100:
                    ViewBag.Title = "Error de grabación";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Ha ocurrido un error inesperado en la grabación de los datos.";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;
                case 101:
                    ViewBag.Title = "Error de Validación";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Ha ocurrido un error de validación con los datos ingresados.";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;
                case 1001:
                    ViewBag.Title = "Sesión Expirada";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Su sesión ha caducado, debes ingresar al sistema nuevamente.";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;
                case 901:
                    ViewBag.Title = "Inicio de Sesión Incorrecto";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Ha ocurrido un error en el inicio de sesión, intentalo nuevamente, si el problema persiste, ponte en contácto con nosotros.";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;

                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Ha ocurrido un error inesperado de servidor interno, si el problema persiste, ponte en contácto con nosotros.";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;

                case 403:
                    ViewBag.Title = "Acceso Denegado";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "No tienes permiso para acceder a este contenido. ";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;
                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;

                default:
                    ViewBag.Title = "Error: ";
                    ViewBag.MyMessageToUsers = error.ToString();
                    ViewBag.Description = "Esta intentando acceder a una página que por alguna razón el sistema no reconoce, si el problema persiste, ponte en contácto con nosotros.";
                    Log.Info(string.Format("Codigo Error: {0} desde la IP: {1}", error.ToString(), Request.UserHostAddress));
                    break;
            }

            return View("~/Views/Shared/Error.cshtml");
        }
    }
}