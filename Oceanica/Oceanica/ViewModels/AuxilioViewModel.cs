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

        private async void SuministroCombustible()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().SuministroCombustible = new SuministroCombustibleViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SuministroCombustiblePage());
            this.IsRunning = false;
        }

        #endregion
    }
}
