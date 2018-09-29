using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class LlamadaEmergenciaViewModel : BaseViewModel
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
        public LlamadaEmergenciaViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand LlamarCommand
        {
            get
            {
                return new RelayCommand(Llamar);
            }
        }




        private async void Llamar()
        {
            string cNummer = "tel:8002894546";
            Device.OpenUri(new Uri(cNummer));

   
        }


        #endregion
    }
}
