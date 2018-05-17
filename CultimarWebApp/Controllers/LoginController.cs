using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CultimarWebApp.Models;
using CultimarWebApp.Utils;
using CultimarWebApp.Utils.DAO;
using CultimarWebApp.Utils.Objetos;

namespace CultimarWebApp.Controllers
{

    public class LoginController : Controller
    {
        Control login = new Control();
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index(LoginViewModel model, string returnUrl)
        {
            string url = string.Empty;
            try
            {
                var rutUsuario = ValidaRut.DigitoVerificador(model.Rut);


                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                else
                {
                    if (ValidaRut.DigitoVerificador(model.Rut))
                    {
                        Log.Info(string.Format("Ingreso al sistema con los datos del usuario: {0} desde la IP: {1}",model.Rut, Request.UserHostAddress));
                        var resultado = login.Login(model.Rut, HashMd5.GetMD5(model.Password));
                        var datosUsuarios = new ObjetoLogin();
                        if (resultado.Count > 0)
                        {
                            for (var i = 0; i < resultado.Count; i++)
                            {
                                datosUsuarios.IdUsuario = resultado[i].IdUsuario;
                                datosUsuarios.Nombre = resultado[i].Nombre;
                                datosUsuarios.Email = resultado[i].Email;
                                datosUsuarios.Rut = resultado[i].Rut;
                                datosUsuarios.IdPerfil = resultado[i].IdPerfil;
                                datosUsuarios.AutorizaModificacion = resultado[i].AutorizaModificacion;
                                datosUsuarios.Activo = resultado[i].Activo;
                            }
                            url = "~/Home/Index";
                            Session["DatosUsuario"] = datosUsuarios;
                            switch (datosUsuarios.IdPerfil)
                            {
                                case 1:
                                    HttpContext.Session["PermisoUsuario"] = "Administrador";
                                    break;
                                case 2:
                                    HttpContext.Session["PermisoUsuario"] = "Ingreso";
                                    break;
                                case 3:
                                    HttpContext.Session["PermisoUsuario"] = "Lectura";
                                    break;
                            }
                        }
                        else
                        {
                            url = "~/Error/Index?error=901";
                        }
                    }
                    else
                    {
                        url = "~/Login/Index";
                    }
                }
                return Redirect(Url.Content(url));
            }
            catch (Exception ex)
            {
                throw (new CapturaExcepciones(ex));
            }

        }



    }
}