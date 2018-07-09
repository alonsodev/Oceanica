using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class AsistenciaViewModel : BaseViewModel
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
        public AsistenciaViewModel()
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

        
        

        private async void Auxilio()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().Auxilio = new AuxilioViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AuxilioPage());
            this.IsRunning = false;
        }

        

        #endregion
    }
}
