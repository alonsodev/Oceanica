using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    public class MainViewModel
    {
        #region Properties

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
