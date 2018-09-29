using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class AccidenteHeridosViewModel : BaseViewModel
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
        public AccidenteHeridosViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand SiCommand
        {
            get
            {
                return new RelayCommand(Si);
            }
        }




        private async void Si()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.AccidenteHayHeridos = MainViewModel.eSiNo.Si;
            vMainViewModel.LlamadaEmergencia = new LlamadaEmergenciaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LlamadaEmergenciaPage());
            this.IsRunning = false;
        }

        public ICommand NoCommand
        {
            get
            {
                return new RelayCommand(No);
            }
        }




        private async void No()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.AccidenteHayHeridos = MainViewModel.eSiNo.No;
            vMainViewModel.Descripcion = new DescripcionViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DescripcionPage());
            this.IsRunning = false;
        }

        #endregion
    }
}
