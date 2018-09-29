using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Oceanica.Services;
    using Oceanica.Models;

    public class MainMenuViewModel : BaseViewModel
    {
        #region Services
        private DataService dataService;
        #endregion

        #region Attributes
        private bool isRunning;
        private bool isVisible;

        #endregion

        #region Properties
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetValue(ref this.isVisible, value); }
        }
        #endregion

        #region Constructors
        public MainMenuViewModel()
        {
            //this.dataService = new DataService();
            ValidateDataPerfil();
        }

        private async void ValidateDataPerfil()
        {
            //PerfilLocal oPerfilLocal = this.dataService.First<PerfilLocal>(false);
            /*if (oPerfilLocal == null)
            {
                EditarPerfil();
            }*/
        }
        #endregion

        #region Commands
        public ICommand SolicitarAsistenciaCommand
        {
            get
            {
                return new RelayCommand(SolicitarAsistencia);
            }
        }

        public ICommand AuxilioCommand
        {
            get
            {
                return new RelayCommand(Auxilio);
            }
        }

        public ICommand EditarPerfilCommand
        {
            get
            {
                return new RelayCommand(EditarPerfil);
            }
        }

        public ICommand LlamadaEmergenciaCommand
        {
            get
            {
                return new RelayCommand(LlamadaEmergencia);
            }
        }

        public ICommand PuntosInteresCommand
        {
            get
            {
                return new RelayCommand(PuntosInteres);
            }
        }
        private async void PuntosInteres()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().PuntosInteres = new PuntosInteresViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PuntosInteresPage());
            this.IsRunning = false;
        }

        private async void LlamadaEmergencia()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().LlamadaEmergencia = new LlamadaEmergenciaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LlamadaEmergenciaPage());
            this.IsRunning = false;
        }

        private async void SolicitarAsistencia()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().Asistencia = new AsistenciaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AsistenciaPage());
            this.IsRunning = false;
        }

        private async void Auxilio()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().Auxilio = new AuxilioViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AuxilioPage());
            this.IsRunning = false;
        }

        private async void EditarPerfil()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().MenuEditarPerfil = new MenuEditarPerfilViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MenuEditarPerfilPage());
            this.IsRunning = false;
        }

        #endregion
    }
}
