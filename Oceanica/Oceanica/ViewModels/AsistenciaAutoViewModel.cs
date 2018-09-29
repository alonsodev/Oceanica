using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class AsistenciaAutoViewModel : BaseViewModel
    {
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
        public AsistenciaAutoViewModel()
        {

        }
        #endregion

        #region Commands

        public ICommand AuxilioCommand
        {
            get
            {
                return new RelayCommand(Auxilio);
            }
        }

        public ICommand AveriaCommand
        {
            get
            {
                return new RelayCommand(Averia);
            }
        }

        public ICommand AccidenteHeridosCommand
        {
            get
            {
                return new RelayCommand(AccidenteHeridos);
            }
        }

        public ICommand LlamadaEmergenciaCommand
        {
            get
            {
                return new RelayCommand(LlamadaEmergencia);
            }
        }

        public ICommand OtrosCommand
        {
            get
            {
                return new RelayCommand(Otros);
            }
        }
        private async void Otros()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAuto = MainViewModel.eTipoAsistenciaAuto.Otros;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }

        private async void LlamadaEmergencia()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAuto = MainViewModel.eTipoAsistenciaAuto.Ambulancia;
            vMainViewModel.LlamadaEmergencia = new LlamadaEmergenciaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LlamadaEmergenciaPage());
            this.IsRunning = false;
        }

        private async void AccidenteHeridos()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAuto = MainViewModel.eTipoAsistenciaAuto.Accidente;
            vMainViewModel.AccidenteHeridos = new AccidenteHeridosViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AccidenteHeridosPage());
            this.IsRunning = false;
        }

        private async void Averia()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAuto = MainViewModel.eTipoAsistenciaAuto.Averia;
            vMainViewModel.AveriaMovilizar = new AveriaMovilizarViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AveriaMovilizarPage());
            this.IsRunning = false;
        }


        private async void Auxilio()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAuto = MainViewModel.eTipoAsistenciaAuto.Auxilio;
            vMainViewModel.Auxilio = new AuxilioViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AuxilioPage());
            this.IsRunning = false;
        }



        #endregion

    }
}
