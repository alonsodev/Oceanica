using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class AuxilioViewModel : BaseViewModel
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
        public AuxilioViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand SuministroCombustibleCommand
        {
            get
            {
                return new RelayCommand(SuministroCombustible);
            }
        }

        public ICommand CambioLlantaCommand
        {
            get
            {
                return new RelayCommand(CambioLlanta);
            }
        }

        public ICommand PasoCorrienteCommand
        {
            get
            {
                return new RelayCommand(PasoCorriente);
            }
        }

        private async void PasoCorriente()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAutoAuxilio = MainViewModel.eTipoAsistenciaAutoAuxilio.PasoCorriente;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }


        private async void CambioLlanta()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAutoAuxilio = MainViewModel.eTipoAsistenciaAutoAuxilio.CambioLlanta;
            vMainViewModel.CambioLlanta = new CambioLlantaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new CambioLlantaPage());
            this.IsRunning = false;
        }

        private async void SuministroCombustible()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistenciaAutoAuxilio = MainViewModel.eTipoAsistenciaAutoAuxilio.SuministroCombustible;
            vMainViewModel.SuministroCombustible = new SuministroCombustibleViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SuministroCombustiblePage());
            this.IsRunning = false;
        }

        #endregion
    }
}
