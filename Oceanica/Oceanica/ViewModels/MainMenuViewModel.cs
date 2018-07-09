using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class MainMenuViewModel : BaseViewModel
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
        public MainMenuViewModel()
        {
            
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
            MainViewModel.GetInstance().EditarPerfil = new EditarPerfilViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new EditarPerfilPage());
            this.IsRunning = false;
        }

        #endregion
    }
}
