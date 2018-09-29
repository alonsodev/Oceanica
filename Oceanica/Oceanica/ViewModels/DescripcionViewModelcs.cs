using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class DescripcionViewModel : BaseViewModel
    {
        #region Attributes
        private bool isRunning;
        private bool isVisible;
        private string descripcion;

        #endregion

        #region Properties
        public string Descripcion
        {
            get { return this.descripcion; }
            set { SetValue(ref this.descripcion, value); }
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
        public DescripcionViewModel()
        {

        }
        #endregion

        #region Commands
        public ICommand SiguienteCommand
        {
            get
            {
                return new RelayCommand(Siguiente);
            }
        }

        private async void Siguiente()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.DescripcionAsistencia = Descripcion;
            vMainViewModel.Maps = new MapsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MapsPage());
            this.IsRunning = false;
        }

        #endregion
    }
}
