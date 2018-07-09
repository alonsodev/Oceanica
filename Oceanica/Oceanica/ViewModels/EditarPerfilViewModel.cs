using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class EditarPerfilViewModel : BaseViewModel
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
        public EditarPerfilViewModel()
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




        private async void SolicitarAsistencia()
        {
            this.IsRunning = true;

            this.IsRunning = false;
        }



        #endregion
    }
}
