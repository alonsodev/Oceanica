using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    public class MainViewModel
    {
        #region Properties
        public enum eSiNo
        {
            Si = 1,
            No = 2
        }
        public enum eTipoAsistencia
        {
            Auto = 1,
            Hogar = 2
        }

        public enum eTipoAsistenciaAuto
        {
            Averia = 1,
            Accidente = 2,
            Auxilio = 3,
            Ambulancia = 4,
            Otros = 5
        }

        public enum eTipoAsistenciaAutoAuxilio
        {
            PasoCorriente = 1,
            SuministroCombustible = 2,
            CambioLlanta = 3
        }

        public enum eTipoAsistenciaAutoAuxilioCombustible
        {
            Regular = 1,
            Super = 2,
            Diesel = 3
        }

        public enum eTipoAsistenciaHogar
        {
            Plomeria = 1,
            Vidreria = 2,
            Electricidad = 3,
            Cerrajeria = 4,
            Otros = 5
        }
        #endregion

        #region Properties
        public eTipoAsistencia TipoAsistencia
        {
            get;
            set;
        }

        public eTipoAsistenciaAuto TipoAsistenciaAuto
        {
            get;
            set;
        }

        public eTipoAsistenciaHogar TipoAsistenciaHogar
        {
            get;
            set;
        }

        public eTipoAsistenciaAutoAuxilio TipoAsistenciaAutoAuxilio
        {
            get;
            set;
        }

        public eTipoAsistenciaAutoAuxilioCombustible TipoAsistenciaAutoAuxilioCombustible
        {
            get;
            set;
        }


        public eSiNo VehiculoMovilizar
        {
            get;
            set;
        }

        public eSiNo VehiculoLugarTechado
        {
            get;
            set;
        }

        public eSiNo AccidenteHayHeridos
        {
            get;
            set;
        }

        public eSiNo ElementosCambioLlanta
        {
            get;
            set;
        }

        public string DescripcionAsistencia
        {
            get;
            set;
        }

        public string CoordenadasAsistencia
        {
            get;
            set;
        }

        public string DireccionAsistencia
        {
            get;
            set;
        }
        #endregion

        #region ViewModels

        public MainMenuViewModel MainMenu
        {
            get;
            set;
        }

        public AsistenciaViewModel Asistencia
        {
            get;
            set;
        }

        public AuxilioViewModel Auxilio
        {
            get;
            set;
        }

        public SuministroCombustibleViewModel SuministroCombustible
        {
            get;
            set;
        }

        public EditarPerfilViewModel EditarPerfil
        {
            get;
            set;
        }
        
        public AveriaMovilizarViewModel AveriaMovilizar
        {
            get;
            set;
        }

        public AveriaTechadoViewModel AveriaTechado
        {
            get;
            set;
        }

        public AccidenteHeridosViewModel AccidenteHeridos
        {
            get;
            set;
        }

        public LlamadaEmergenciaViewModel LlamadaEmergencia
        {
            get;
            set;
        }

        public CambioLlantaViewModel CambioLlanta
        {
            get;
            set;
        }

        public AsistenciaHogarViewModel AsistenciaHogar
        {
            get;
            set;
        }

        public AsistenciaAutoViewModel AsistenciaAuto
        {
            get;
            set;
        }

        public DescripcionViewModel Descripcion
        {
            get;
            set;
        }
        public MapsViewModel Maps
        {
            get;
            set;
        }

        public PuntosInteresViewModel PuntosInteres
        {
            get;
            set;
        }

        public EnviarInfoViewModel EnviarInfo
        {
            get;
            set;
        }

        public MenuEditarPerfilViewModel MenuEditarPerfil
        {
            get;
            set;
        }

        public EditarPerfilHogarViewModel EditarPerfilHogar
        {
            get;
            set;
        }

        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.MainMenu = new MainMenuViewModel();
        }


        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
