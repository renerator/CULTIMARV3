using CultimarWebApp.Models;
using CultimarWebApp.Models.Filters;
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
    public class HomeController : Controller
    {
        Control _control = new Control();
        public ActionResult Index()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                return View();
            }
            catch (Exception ex)
            {             
                throw (new CapturaExcepciones(ex));
            }
        }
        [SessionFilter]
        public ActionResult Mantenedores()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoOrigen> parametrosOrigen = _control.ListadoParametrosOrigen();
                IEnumerable<ObjetoDestino> parametrosDestino = _control.ListadoParametrosDestino();
                ViewBag.ParametrosOrigen = parametrosOrigen;
                
                ViewBag.ParametrosDestino = parametrosDestino;
                IEnumerable<ObjetoEspecies> parametrosEspecies = _control.ListadoParametrosEspecies();
                ViewBag.ParametrosEspecies = parametrosEspecies;
                IEnumerable<ObjetoTipoContenedor> parametrosTipoContenedor = _control.ListadoTipoContenedor();
                ViewBag.ParametrosTipoContenedor = parametrosTipoContenedor;
                IEnumerable<ObjetoTipoIdentificacion> parametrosTipoIdentificacion = _control.ListadoTipoIdentificacion();
                ViewBag.ParametrosTipoIdentificacion = parametrosTipoIdentificacion;
                IEnumerable<ObjetoTipoMortalidad> parametrosTipoMortalidad = _control.ListadoTipoMortalidad();
                ViewBag.ParametrosTipoMortalidad = parametrosTipoMortalidad;
                IEnumerable<ObjetoTipoSistema> parametrosTipoSistema = _control.ListadoTipoSistema();
                ViewBag.ParametrosTipoSistema = parametrosTipoSistema;
                //IEnumerable<ObjetoAlimentos> parametrosTipoAlimentos = _control.ListadoTipoAlimentos();
                //ViewBag.ParametrosTipoAlimentos = parametrosTipoAlimentos;
                //IEnumerable<ObjetoAlimentos> parametrosAlimentos = _control.ListadoAlimentos();
                //ViewBag.ParametrosAlimentos = parametrosAlimentos;
                IEnumerable<ObjetoCalibre> parametroCalibre = _control.ListadoCalibre();
                ViewBag.ParametroCalibre = parametroCalibre;

                IEnumerable<ObjetoUbicacionOceanica> parametrosUbicacionOceanica = _control.ListadoUbicacionOceanica();
                ViewBag.ParametroUbicacionOceanica = parametrosUbicacionOceanica;

                IEnumerable<ObjetoDestinoDespacho> paranetrosDestinoDespacho = _control.ListadoDestinoDespacho();
                ViewBag.ParametroDestinoDespacho = paranetrosDestinoDespacho;




                //IEnumerable<SelectListItem> selectTipoAlimento = _control.ListadoTipoAlimentos().Select(c => new SelectListItem()
                //{
                //    Text = c.NombreTipoAlimento,
                //    Value = c.IdTipoAlimento.ToString()
                //}).ToList();
                //ViewBag.SelectTipoAlimento = selectTipoAlimento;

                ////var list = _control.ListadoTipoMortalidad();
                ////ViewBag.MultiSelector = new MultiSelectList(list, "IdMortalidad", "NombreMortalidad");



                return View();
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        [SessionFilter]
        public ActionResult FactoresMedicion()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoFactoresMedicion> model = _control.ListaFactoresMedicion();


                IEnumerable<SelectListItem> selectTipoCalibre = _control.ListadoCalibre().Select(c => new SelectListItem()
                {
                    Text = c.NombreCalibre,
                    Value = c.IdCalibre.ToString()
                }).ToList();
                ViewBag.SelectCalibre = selectTipoCalibre;


                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }

        public JsonResult GrabaFactoresMedicion(int idFactor, string nombreFactor, string ultimoTamizado, int idCalibre, string ploidia, string volumen)
        {
            var validador = 0;
            var factorMedicion = new ObjetoFactoresMedicion() {
                IdFactor = idFactor,
                NombreFactor = nombreFactor,
                UltimoTamizado = Convert.ToDateTime(ultimoTamizado),
                IdCalibre = idCalibre,
                Ploidia = ploidia,
                Volumen = volumen
            };

            if (_control.SetGrabaFactoresMedicion(factorMedicion))
            {
                validador = 1;
            }
            else
            {
                validador = 2;
            }

            return (Json(validador));
        }

        public JsonResult GrabaDestinoDespacho(int idDestinoDespacho, string nombreDestinoDespacho)
        {
            var validador = 0;
            var datosDestinoDespacho = new ObjetoDestinoDespacho()
            {
                IdDestinoDespacho = idDestinoDespacho,
                NombreDestinoDespacho = nombreDestinoDespacho
            };

            if (_control.SetGrabaDestinoDespacho(datosDestinoDespacho))
            {
                validador = 1;
            }
            else
            {
                validador = 2;
            }

            return (Json(validador));
        }


        [SessionFilter]
        public ActionResult Usuarios()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoUsuarios> model = _control.ListadoUsuarios();
                IEnumerable<SelectListItem> items = _control.ListadoPerfiles().Select(c => new SelectListItem() {
                                                                            Text = c.NombrePerfil,
                                                                            Value = c.IdPerfil.ToString()
                                                }).ToList();
                ViewBag.Perfil = items;


                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }
        }
        [SessionFilter]
        public ActionResult Perfiles()
        {
            try
            {
                var datosUsuario = new ObjetoLogin();
                datosUsuario = (ObjetoLogin)Session["DatosUsuario"];
                ViewBag.Message = "Bienvenido: " + datosUsuario.Nombre;
                IEnumerable<ObjetoPerfil> model = _control.ListadoPerfiles();
                return View(model);
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                return ErrorPage(1001);
                throw;
            }

        }
        public JsonResult GrabaDatos(string rut, string pass, string nombreUsuario, string apellidoUsuario, int idPerfil, string email)
        {
            var usuario = new ObjetoUsuarios();
            var validador = 0;
            if (!string.IsNullOrEmpty(rut))
            {
                if (ValidaRut.DigitoVerificador(rut))
                {
                    usuario.RutUsuario = rut;
                    usuario.Pass = HashMd5.GetMD5(pass);
                    usuario.NombreUsuario = string.Concat(nombreUsuario, " ", apellidoUsuario);
                    usuario.IdPerfil = idPerfil;
                    usuario.Email = email;
                    if (_control.GetVerificaUsuario(rut))
                    {
                        validador = 2;
                    }
                    else
                    {
                        if (_control.SetGrabaUsuario(usuario))
                        {
                            validador = 1;
                        }
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            else
            {
                validador = 4;
            }
            //, JsonRequestBehavior.AllowGet --- solo si se usa metodo GET
            return (Json(validador));
        }

        public JsonResult AutorizaUsuario(int idUsuario)
        {

            var validador = 0;

            
            
            if (_control.SetAutorizaUsuario(idUsuario))
            {
                validador = 1;
                var datos = _control.DatosPersona(idUsuario);
                var correo = new EnvioMail();
                correo.SendCorreoAutorizaQuita(correo.QuitaoAutorizaPersona(datos[0].Nombre, "autoriza"), datos[0].Email, "Autoriza Permiso");

            }

            return (Json(validador));
        }

        public JsonResult QuitapermisoUsuarios(int idUsuario)
        {

            var validador = 0;

            if (_control.SetQuitaPermisoUsuario(idUsuario))
            {
                validador = 1;
                var datos = _control.DatosPersona(idUsuario);
                var correo = new EnvioMail();
                correo.SendCorreoAutorizaQuita(correo.QuitaoAutorizaPersona(datos[0].Nombre, "quita"), datos[0].Email, "Quita Permiso");
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroOrigen(int idOrigen, string nombreOrigen)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreOrigen))
                {
                    var origen = new ObjetoOrigen()
                    {
                        IdOrigen = idOrigen,
                        NombreOrigen = nombreOrigen
                    };
                    if (_control.SetGrabaParametroOrigen(origen))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }
            
            return (Json(validador));
        }

        public JsonResult GrabaParametrosDestino(int idDestino, string nombreDestino)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreDestino))
                {
                    var destino = new ObjetoDestino()
                    {
                        IdDestino = idDestino,
                        NombreDestino = nombreDestino
                    };
                    if (_control.SetGrabaParametroDestino(destino))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroEspecie(int idEspecie, string nombreEspecie)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreEspecie))
                {
                    var especies = new ObjetoEspecies()
                    {
                        IdEspecies = idEspecie,
                        NombreEspecies = nombreEspecie
                    };
                    if (_control.SetGrabaParametroEspecies(especies))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
                
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroTipoSistema(int idTipoSistema, string nombreSistema)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreSistema))
                {
                    var tipoSistema = new ObjetoTipoSistema()
                    {
                        IdTipoSistema = idTipoSistema,
                        NombreSistema = nombreSistema
                    };
                    if (_control.SetGrabaParametrosTipoSistema(tipoSistema))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));

        }
        public JsonResult GrabaParametroTipoMortalidad(int idTipoMortalidad, string nombreMortalidad)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreMortalidad))
                {
                    var tipoMortalidad = new ObjetoTipoMortalidad()
                    {
                        IdMortalidad = idTipoMortalidad,
                        NombreMortalidad = nombreMortalidad
                    };
                    if (_control.SetGrabaParametrosTipoMortalidad(tipoMortalidad))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }
        public JsonResult GrabaParametroTipoIdentificacion(int idTipoIdentificacion, string nombreIdentificacion)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreIdentificacion))
                {
                    var tipoIdentificacion = new ObjetoTipoIdentificacion()
                    {
                        IdIdentificacion = idTipoIdentificacion,
                        NombreIdentificacion = nombreIdentificacion
                    };
                    if (_control.SetGrabaParametrosTipoIdentificacion(tipoIdentificacion))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }
        public JsonResult GrabaParametroTipoContenedor(int idContenedor, string nombreContenedor, string tipoContenedor)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreContenedor) && !string.IsNullOrEmpty(tipoContenedor))
                {
                    var PtipoContenedor = new ObjetoTipoContenedor()
                    {
                        IdContenedor = idContenedor,
                        NombreContenedor = nombreContenedor,
                        TipoContenedor = tipoContenedor
                    };
                    if (_control.SetGrabaParametrosTipoContenedor(PtipoContenedor))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroTipoAlimento(int idTipoAlimento, string nombreTipoAlimento, string descripcionTipoAlimento)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreTipoAlimento) && !string.IsNullOrEmpty(descripcionTipoAlimento))
                {
                    var pTipoAlimento = new ObjetoAlimentos()
                    {
                        IdTipoAlimento = idTipoAlimento,
                        NombreTipoAlimento = nombreTipoAlimento,
                        DescripcionTipoAlimento = descripcionTipoAlimento

                    };
                    if (_control.SetGrabaParametroTipoAlimento(pTipoAlimento))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }
        public JsonResult GrabaParametroAlimento(int idAlimento, string nombreAlimento)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombreAlimento))
                {
                    var pAlimento = new ObjetoUbicacionOceanica()
                    {
                        IdUbicacion = idAlimento,
                        NombreUbicacion = nombreAlimento

                    };
                    if (_control.SetGrabaParametroUbicacion(pAlimento))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }

        public JsonResult GrabaParametroCalibre(int idCalibre, string nombrecalibre, string descripcionCalibre)
        {
            var validador = 0;
            try
            {
                if (!string.IsNullOrEmpty(nombrecalibre))
                {
                    var pCalibre = new ObjetoCalibre()
                    {
                        IdCalibre = idCalibre,
                        NombreCalibre = nombrecalibre,
                        DescripcionCalibre = descripcionCalibre

                    };
                    if (_control.SetGrabaParametroCalibre(pCalibre))
                    {
                        validador = 1;
                    }
                    else
                    {
                        validador = 2;
                    }
                }
                else
                {
                    validador = 3;
                }
            }
            catch (Exception ex)
            {
                new CapturaExcepciones(ex);
                validador = -1;
                throw;
            }

            return (Json(validador));
        }


        public ActionResult ErrorPage(int error)
        {
            return Redirect(Url.Content("~/Error/Index?error=" + error));
        }



    }
}