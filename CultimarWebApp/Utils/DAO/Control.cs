using CultimarWebApp.Utils.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CultimarWebApp.Utils.DAO
{
    /// <summary>
    /// Clase de Control para acceso a DAO de Factory (nivel intermedio de acceso)
    /// </summary>
    public class Control
    {
        private Factory _dtFac = new Factory();
        private FactorySeguimientoLarval _dtSegLarval = new FactorySeguimientoLarval();
        private FactorySeguimientosSemillas _dtFacSeguimientoSemilla = new FactorySeguimientosSemillas();
        private FactoryRegistroInicialSemilla _dtFactRegistroInicialSemilla = new FactoryRegistroInicialSemilla();
        private FactoryTipoContenedor _dtFactoryTipoContenedor = new FactoryTipoContenedor();
        private FactoryRegistroProduccion _dtFactoryRegistroProduccion = new FactoryRegistroProduccion();
        private FactoryMicroAlgas _dtMicroAlgas = new FactoryMicroAlgas();
        private FactorySeguimientoFijacion _dtFijacion = new FactorySeguimientoFijacion();
        private FactoryRegistroInicialMar _dtMar = new FactoryRegistroInicialMar();
        private FactoryPreparadoDespacho _preparado = new FactoryPreparadoDespacho();
        private FactorySeguimientoMar _dtFactSeguimientoMar = new FactorySeguimientoMar();


        public List<ObjetoPreparadoDespacho> ListadoPreparadoDespachado(int id)
        {
            return _preparado.ListadoPreparadoDespechao(id);
        }

        public bool SetGrabaPreparacionDespacho(int idUsuario, ObjetoPreparadoDespacho pdespach)
        {
            return _preparado.SetGrabaPreparadoDespachl(idUsuario, pdespach);
        }

        public bool SetGrabaRegistroInicialSemilla(int idUsuario, ObjetoSeguimientoSemilla registro)
        {
            return _dtFactRegistroInicialSemilla.SetGrabaRegistroInicialSemilla(idUsuario, registro);
        }


        public List<ObjetoRegistroInicialMar> ListadoRegistroInicialMar(int idRegistro)
        {
            return _dtMar.ListadoRegistroInicialMar(idRegistro);
        }
        //

        public List<ObjetoUbicacionOceanica> ListadoUbicacionOceanica()
        {
            return _dtFac.ListadoUbicacionOceanica();
        }

        public List<ObjetoDestinoDespacho> ListadoDestinoDespacho()
        {
            return _dtFac.ListadoDestinosDespacho();
        }



        public List<ObjetoSeguimientoMar> ListadoSeguimientoMar(int idRegistro)
        {
            return _dtFactSeguimientoMar.ListadoSeguimientoMar(idRegistro);
        }

        public bool SetGrabaRegistroInicialMar(int idUsuario, ObjetoRegistroInicialMar registroMar)
        {
            return _dtMar.SetGrabaRegistroInicialMar(idUsuario, registroMar);
        }

        public bool SetGrabaSeguimientoMar(int idUsuario, ObjetoSeguimientoMar registroMar)
        {
            return _dtFactSeguimientoMar.SetGrabaSeguimientoMar(idUsuario, registroMar);
        }

        public List<ObjetoSeguimientoLarval> ListadoSeguimientoLarval(int id)
        {
            return _dtSegLarval.ListadoSeguimientoLarval(id);
        }

        public List<ObjetoFactoresMedicion> ListadoFactorMedicion()
        {
            return _dtFac.ListadoFactoresMedicion();
        }


        public bool SetGrabaSeguimientoLarval(int idUsuario, ObjetoSeguimientoLarval larval)
        {
            return _dtSegLarval.SetGrabaSegimientoLarval(idUsuario, larval);
        } 

        public List<ObjetoSeguimientoSemilla> ListadoSeguimientoSemilla(int id)
        {
            return _dtFacSeguimientoSemilla.SeguimientoSemilla(id);
        }


        public List<ObjetoSeguimientoFijacion> ListadoSeguimientoFijacion(int id)
        {
            return _dtFijacion.ListadoFijacion(id);
        }



        public bool SetGrabaSeguimientoFijacion(int idUsuario, ObjetoSeguimientoFijacion fijacion)
        {
            return _dtFijacion.SetGrabasegimientoFijacion(idUsuario, fijacion);
        }


        public List<ObjetoRegistroProduccion> ListadoRegistroProduccion(int id)
        {
            return _dtFactoryRegistroProduccion.listadoRegistroProduccion(id);
        }

        public List<ObjetoSeguimientoSemilla> ListadoRegistroInicialSemillas(int id)
        {
            return _dtFactRegistroInicialSemilla.ListadoRegistroInicial(id);
        }

        public List<ObjetoMenu> MenuUsuario(int idUsuario)
        {
            return _dtFac.MenuUsuario(idUsuario);
        }

        public List<ObjetoLogin> Login(string rut, string pass)
        {
            return _dtFac.LoginUsuario(rut, pass);
        }
        public List<ObjetoLogin> DatosPersona(int idPersona)
        {
            return _dtFac.DatosPersona(idPersona);
        }
        public List<ObjetoPerfil> ListadoPerfiles()
        {
            return _dtFac.ListadoPerfiles();
        }

        public List<ObjetoUsuarios> ListadoUsuarios()
        {
            return _dtFac.ListadoUsuarios();
        }

        public List<ObjetoOrigen> ListadoParametrosOrigen()
        {
            return _dtFac.ListadoParametrosOrigen();
        }

        public List<ObjetoDestino> ListadoParametrosDestino()
        {
            return _dtFac.ListadoParametrosDestino();
        }

        public List<ObjetoEspecies> ListadoParametrosEspecies()
        {
            return _dtFac.ListadoParametrosEspecies();
        }

        public List<ObjetoTipoContenedor> ListadoTipoContenedor()
        {
            return _dtFac.ListadoTipoContenedor();
        }
        public List<ObjetoTipoContenedor> ListadoTipoContenedorOrigen()
        {
            //return _dtFactoryTipoContenedor.ListadoContenedorOrigen();
            return _dtFac.ListadoTipoContenedor();
        }

        public List<ObjetoTipoContenedor> ListadoTipoContenedorDestino()
        {
            //return _dtFactoryTipoContenedor.ListadoContenedorDestino();
            return _dtFac.ListadoTipoContenedor();
        }

        public List<ObjetoTipoIdentificacion> ListadoTipoIdentificacion()
        {
            return _dtFac.ListadoTipoIdentificacion();
        }

        public List<ObjetoTipoMortalidad> ListadoTipoMortalidad()
        {
            return _dtFac.ListadoTipoMortalidad();
        }

        public List<ObjetoTipoSistema> ListadoTipoSistema()
        {
            return _dtFac.ListadoTipoSistema();
        }

        public List<ObjetoAlimentos> ListadoTipoAlimentos()
        {
            return _dtFac.ListadoTipoAlimentos();
        }

        public List<ObjetoAlimentos> ListadoAlimentos()
        {
            return _dtFac.ListadoAlimentos();
        }
        public List<ObjetoCalibre> ListadoCalibre()
        {
            return _dtFac.ListadoCalibre();
        }

        public List<ObjetoFactoresMedicion> ListaFactoresMedicion()
        {
            return _dtFac.ListadoFactoresMedicion();
        }

        public List<ObjetoMicroAlga> ListadoMicroAlgas(int id)
        {
            return _dtMicroAlgas.ListadoMicroAlgas(id);
        }

        public List<ObjetoMicroAlga> ListadoSeguimientoMicroAlgas(int id)
        {
            return _dtMicroAlgas.ListadoSeguimientoMicroAlgas(id);
        }


        public List<ObjetoPloidia> ListadoPloidia()
        {
            return _dtFac.ListadoPloidia();
        }

        public bool SetGrabaUsuario(ObjetoUsuarios usuario)
        {
            return _dtFac.setGrabaUsuario(usuario);
        }
        public bool SetGrabaSeguimientoSemilla(int idUsuario, ObjetoSeguimientoSemilla semilla)
        {
            return _dtFacSeguimientoSemilla.SetGrabaSeuimientoSemillla(idUsuario, semilla);
        }

        public bool SetGrabaRegistroProduccion(int idUsuario, ObjetoRegistroProduccion produccion)
        {
            return _dtFactoryRegistroProduccion.SetGrabaRegistroProduccion(idUsuario, produccion);
        }
        public bool GetVerificaUsuario(string rutUsuario)
        {
            return _dtFac.getVerificaUsuario(rutUsuario);
        }

        public bool SetAutorizaUsuario(int idUsuario)
        {
            return _dtFac.setAutorizaUsuario(idUsuario);
        }

        public bool SetQuitaPermisoUsuario(int idUsuario)
        {
            return _dtFac.setQuitaPermisoUsuario(idUsuario);
        }

        public bool SetGrabaParametroOrigen(ObjetoOrigen origen)
        {
            return _dtFac.setGrabaParametroOrigen(origen);
        }
        public bool SetGrabaParametroDestino(ObjetoDestino destino)
        {
            return _dtFac.setGrabaParametroDestino(destino);
        }

        public bool SetGrabaParametroEspecies(ObjetoEspecies especies)
        {
            return _dtFac.setGrabaParametrosEspecies(especies);
        }
        public bool SetGrabaParametrosTipoContenedor(ObjetoTipoContenedor tipoContenedor)
        {
            return _dtFac.SetGrabaParametrosTipoContenedor(tipoContenedor);
        }

        public bool SetGrabaParametroTipoAlimento(ObjetoAlimentos tipoAlimento)
        {
            return _dtFac.SetGrabaParametrosTipoAlimento(tipoAlimento);
        }

        public bool SetGrabaParametroAlimento(ObjetoAlimentos alimento)
        {
            return _dtFac.SetGrabaParametrosAlimento(alimento);
        }
        public bool SetGrabaParametroUbicacion(ObjetoUbicacionOceanica ubicacion)
        {
            return _dtFac.SetGrabaParametrosUbicacion(ubicacion);
        }

        public bool SetGrabaParametroCalibre(ObjetoCalibre calibre)
        {
            return _dtFac.SetGrabaParametrosCalibre(calibre);
        }
        public bool SetGrabaParametrosTipoIdentificacion(ObjetoTipoIdentificacion tipoIdentificacion)
        {
            return _dtFac.SetGrabaParametrosTipoIdentificacion(tipoIdentificacion);
        }

        public bool SetGrabaParametrosTipoMortalidad(ObjetoTipoMortalidad tipoMortalidad)
        {
            return _dtFac.setGrabaParametrosTipoMortalidad(tipoMortalidad);
        }
        public bool SetGrabaParametrosTipoSistema(ObjetoTipoSistema tipoSistema)
        {
            return _dtFac.setGrabaParametrosTipoSistema(tipoSistema);
        }

        public bool SetGrabaMicroAlga(int idUsuario, ObjetoMicroAlga microAlga)
        {
            return _dtMicroAlgas.SetGrabaMicroAlga(idUsuario, microAlga);
        }
        
        public bool SetGrabaSeguimientoMicroAlga(int idUsuario, ObjetoMicroAlga microAlga)
        {
            return _dtMicroAlgas.SetGrabaSeguimientoMicroAlga(idUsuario, microAlga);
        }

        public bool SetGrabaFactoresMedicion(ObjetoFactoresMedicion factorMedicion)
        {
            return _dtFac.SetGrabaFactoresMedicion(factorMedicion);
        }

        public bool SetGrabaDestinoDespacho(ObjetoDestinoDespacho destinoDespacho)
        {
            return _dtFac.SetGrabaDestinoDespacho(destinoDespacho);
        }

    }
}