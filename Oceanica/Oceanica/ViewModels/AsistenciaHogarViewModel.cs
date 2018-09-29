using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class AsistenciaHogarViewModel : BaseViewModel
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
        public AsistenciaHogarViewModel()
        {

        }
        #endregion

        #region Commands

        public ICommand PlomeriaCommand
        {
            get
            {
                return new RelayCommand(Plomeria);
            }
        }

        public ICommand VidreriaCommand
        {
            get
            {
                return new RelayCommand(Vidreria);
            }
        }
        public ICommand ElectricidadCommand
        {
            get
            {
                return new RelayCommand(Electricidad);
            }
        }
        public ICommand CerrajeriaCommand
        {
            get
            {
                return new RelayCommand(Cerrajeria);
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
            vMainViewModel.TipoAsistenciaHogar = MainViewModel.eTipoAsistenciaHogar.Otros;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }

        private async void Cerrajeria()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaHogar = MainViewModel.eTipoAsistenciaHogar.Cerrajeria;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }
        private async void Electricidad()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaHogar = MainViewModel.eTipoAsistenciaHogar.Electricidad;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }
        private async void Vidreria()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaHogar = MainViewModel.eTipoAsistenciaHogar.Vidreria;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }
        
        private async void Plomeria()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaHogar = MainViewModel.eTipoAsistenciaHogar.Plomeria;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }
        #endregion
    }
}
