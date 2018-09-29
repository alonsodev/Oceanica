using GalaSoft.MvvmLight.Command;
using Oceanica.Services;
using Oceanica.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Oceanica.ViewModels
{
    public class MenuEditarPerfilViewModel : BaseViewModel
    {
        #region Services
        private DataService dataService;
        #endregion

        #region Attributes
        private bool isRunning;
        private bool isVisible;

        #endregion

        #region Properties
        public bool FirstValidation
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
        public MenuEditarPerfilViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand EditarPerfilCommand
        {
            get
            {
                return new RelayCommand(EditarPerfil);
            }
        }

        public ICommand EditarPerfilHogarCommand
        {
            get
            {
                return new RelayCommand(EditarPerfilHogar);
            }
        }


        private async void EditarPerfil()
        {
            this.IsRunning = true;

            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.EditarPerfil = new EditarPerfilViewModel();
            vMainViewModel.EditarPerfil.FirstValidation = true;
            await Application.Current.MainPage.Navigation.PushAsync(new EditarPerfilPage());
            this.IsRunning = false;
        }

        private async void EditarPerfilHogar()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.EditarPerfilHogar = new EditarPerfilHogarViewModel();
            vMainViewModel.EditarPerfilHogar.FirstValidation = true;
            await Application.Current.MainPage.Navigation.PushAsync(new EditarPerfilHogarPage());
            this.IsRunning = false;
        }

        #endregion
    }
}
