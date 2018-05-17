using CultimarWebApp.Utils;
using CultimarWebApp.Utils.DAO;
using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CultimarWebApp.Controllers
{
    public class MicroAlgasController : Controller
    {

        Control _control = new Control();
        // GET: MicroAlgas
        public ActionResult IngresoMicroAlgas()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoMicroAlga> model = _control.ListadoMicroAlgas(-1);
                IEnumerable<SelectListItem> items = _control.ListadoParametrosEspecies().Select(c => new SelectListItem()
                {
                    Text = c.NombreEspecies,
                    Value = c.IdEspecies.ToString()
                }).ToList();

                ViewBag.ParametrosEspecies = items;
                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        public ActionResult SeguimientoMicroAlgas()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoMicroAlga> model = _control.ListadoSeguimientoMicroAlgas(-1);


                IEnumerable<SelectListItem> NombreIngresoMicroalga = _control.ListadoMicroAlgas(-1).Select(c => new SelectListItem()
                {
                    Text = c.NombreRegistroMicroAlga,
                    Value = c.IdMicroAlga.ToString()
                }).ToList();
                ViewBag.ParametroNombreIngresoInicial = NombreIngresoMicroalga;

                IEnumerable<SelectListItem> parametrosOrigen = _control.ListadoParametrosOrigen().Select(c => new SelectListItem()
                {
                    Text = c.NombreOrigen,
                    Value = c.IdOrigen.ToString()
                }).ToList();
                ViewBag.ParametrosOrigen = parametrosOrigen;
                IEnumerable<SelectListItem> parametrosDestino = _control.ListadoParametrosDestino().Select(c => new SelectListItem()
                {
                    Text = c.NombreDestino,
                    Value = c.IdDestino.ToString()
                }).ToList();
                ViewBag.ParametrosDestino = parametrosDestino;

                IEnumerable<SelectListItem> parametrosEspecies = _control.ListadoParametrosEspecies().Select(c => new SelectListItem() {
                    Text = c.NombreEspecies,
                    Value = c.IdEspecies.ToString()
                }).ToList();
                ViewBag.ParametrosEspecies = parametrosEspecies;
                
                IEnumerable<SelectListItem> parametrosTipoIdentificacion = _control.ListadoTipoIdentificacion().Select(c => new SelectListItem()
                {
                    Text = c.NombreIdentificacion,
                    Value = c.IdIdentificacion.ToString()
                }).ToList();
                ViewBag.ParametrosTipoIdentificacion = parametrosTipoIdentificacion;

                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        
        public JsonResult GrabaSeguimientoMicroAlga(int IdMicroAlga, int idRegistroInicial, int idEspecie, string fechaRegistro, string fechaSalida, int Origen, int Destino, bool resultadoTCBS, string volumenCosechado, string concentracion,bool estadoSeguimiento, string observaciones, int puntuacion)
        {
            try
            {

                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                var validador = 0;
                switch (datosUsuario.IdPerfil)
                {
                    case 3:
                        validador = 5;
                        break;
                    default:
                        var seguimiento = new ObjetoMicroAlga()
                        {
                            IdSeguimientoMicroAlga = IdMicroAlga,
                            IdMicroAlga = idRegistroInicial,
                            IdEspecie = idEspecie,
                            FechaIngreso = Convert.ToDateTime(fechaRegistro),
                            FechaSalida = Convert.ToDateTime(fechaSalida),
                            IdOrigen = Origen,
                            IdDestino = Destino,
                            ResultadoTCBS = resultadoTCBS,
                            VolumenCosechado = Convert.ToInt32(volumenCosechado),
                            Concentracion = Convert.ToInt32(concentracion),
                            Estado = estadoSeguimiento,
                            Observaciones = observaciones,
                            Puntuacion = puntuacion
                        };
                        if (IdMicroAlga != -1)
                        {
                            if (datosUsuario.AutorizaModificacion)
                            {
                                if (_control.SetGrabaSeguimientoMicroAlga(datosUsuario.IdUsuario, seguimiento))
                                {
                                    validador = 1;
                                }
                                else
                                {
                                    validador = 3;
                                }
                            }
                            else
                            {
                                validador = 4;
                                EnvioMail correo = new EnvioMail();
                                correo.SendCorreoSolitaModificación(correo.ModificaSeguimientoMicroAlgas(IdMicroAlga, datosUsuario.Nombre));
                            }
                        }
                        else
                        {
                            if (_control.SetGrabaSeguimientoMicroAlga(datosUsuario.IdUsuario, seguimiento))
                            {
                                validador = 1;
                            }
                            else
                            {
                                validador = 3;
                            }
                        }
                        break;
                }
                return (Json(validador));
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                ErrorPage(100);
                throw;
            }
        }
        public JsonResult GrabaDatosMicroAlga(int idMicroAlga,int idEspecie, string cantidadVolumen, string numeroBolsa, string fecha, string nombreRegistro, string observaciones)
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                var validador = 0;
                switch (datosUsuario.IdPerfil)
                {
                    case 3:
                        validador = 5;
                        break;
                    default:
                        if (!string.IsNullOrEmpty(cantidadVolumen) && !string.IsNullOrEmpty(numeroBolsa))
                        {
                            var microAlga = new ObjetoMicroAlga()
                            {
                                IdMicroAlga = idMicroAlga,
                                IdEspecie = idEspecie,
                                VolumenSembrado = Convert.ToInt32(cantidadVolumen),
                                NumeroBolsa = Convert.ToInt32(numeroBolsa),
                                FechaRegistro = Convert.ToDateTime(fecha),
                                NombreRegistroMicroAlga = nombreRegistro,
                                Observaciones = observaciones
                            };
                            if (idMicroAlga != -1)
                            {
                                if (datosUsuario.AutorizaModificacion)
                                {
                                    if (_control.SetGrabaMicroAlga(datosUsuario.IdUsuario, microAlga))
                                    {
                                        validador = 1;
                                    }
                                    else
                                    {
                                        validador = 3;
                                    }
                                }
                                else
                                {
                                    validador = 4;
                                    EnvioMail correo = new EnvioMail();
                                    correo.SendCorreoSolitaModificación(correo.ModificaMicroAlgas(idMicroAlga,datosUsuario.Nombre));
                                }
                            }
                            else
                            {
                                if (_control.SetGrabaMicroAlga(datosUsuario.IdUsuario, microAlga))
                                {
                                    validador = 1;
                                }
                                else
                                {
                                    validador = 3;
                                }
                            }
                        }
                        else
                        {
                            validador = 2;
                        }
                        break;
                }
                return (Json(validador));
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                ErrorPage(100);
                throw;
            }
        }

        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }
    }
}