using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class SuministroCombustibleViewModel : BaseViewModel
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
        public SuministroCombustibleViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand RegularCommand
        {
            get
            {
                return new RelayCommand(Regular);
            }
        }

        public ICommand SuperCommand
        {
            get
            {
                return new RelayCommand(Super);
            }
        }

        public ICommand DieselCommand
        {
            get
            {
                return new RelayCommand(Diesel);
            }
        }

        private async void Super()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAutoAuxilioCombustible = MainViewModel.eTipoAsistenciaAutoAuxilioCombustible.Super;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }

        private async void Diesel()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAutoAuxilioCombustible = MainViewModel.eTipoAsistenciaAutoAuxilioCombustible.Diesel;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }
        private async void Regular()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAutoAuxilioCombustible = MainViewModel.eTipoAsistenciaAutoAuxilioCombustible.Regular;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }

        #endregion
    }
}
