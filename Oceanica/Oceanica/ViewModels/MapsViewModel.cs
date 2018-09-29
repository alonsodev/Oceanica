using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class MapsViewModel : BaseViewModel
    {
        #region Attributes
        private bool isRunning;
        private bool isVisible;
        private string direccion;

        #endregion

        #region Properties
        public string Direccion
        {
            get { return this.direccion; }
            set { SetValue(ref this.direccion, value); }
        }

        public string Coordenadas
        {
            get;
            set;
        }
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
        public MapsViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand ConfirmarCommand
        {
            get
            {
                return new RelayCommand(Confirmar);
            }
        }

        public ICommand MapPinCommand
        {
            get
            {
                return new RelayCommand(MapPin);
            }
        }
        
        private async void MapPin()
        {
            this.IsRunning = true;
        }

        private async void Confirmar()
        {
            this.IsRunning = true;

            if (!ValidateForm())
            {
                //this.IsBusy = false;
                this.IsRunning = false;
                return;
            }

            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.DireccionAsistencia = Direccion;
            vMainViewModel.CoordenadasAsistencia = Coordenadas;
            vMainViewModel.EnviarInfo = new EnviarInfoViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new EnviarInfoPage());
            this.IsRunning = false;
        }


        #endregion

        #region Methods
        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(this.Direccion))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error",
                     "Tú debes ingresar una ubicación/dirección válida.",
                     "Aceptar");
                return false;
            }

            return true;
        }
        #endregion
    }
}
