using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Oceanica.Services;
    using Oceanica.Models;

    public class AsistenciaViewModel : BaseViewModel
    {
        #region Services
        private DataService dataService;
        #endregion

        #region Attributes
        private bool isRunning;
        private bool isVisible;
        private bool asistenciaAutoVisible;
        private bool asistenciaHogarVisible;

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

        public bool AsistenciaAutoVisible
        {
            get { return this.asistenciaAutoVisible; }
            set { SetValue(ref this.asistenciaAutoVisible, value); }
        }

        public bool AsistenciaHogarVisible
        {
            get { return this.asistenciaHogarVisible; }
            set { SetValue(ref this.asistenciaHogarVisible, value); }
        }

        #endregion

        #region Constructors
        public AsistenciaViewModel()
        {
            this.dataService = new DataService();
            PerfilLocal oPerfilLocal = this.dataService.First<PerfilLocal>(false);

            AsistenciaHogarVisible = (!String.IsNullOrEmpty(oPerfilLocal.NumPolizaHogar));

            AsistenciaAutoVisible = (!String.IsNullOrEmpty(oPerfilLocal.NumPoliza));
        }
        #endregion

        #region Commands

        public ICommand AsistenciaHogarCommand
        {
            get
            {
                return new RelayCommand(AsistenciaHogar);
            }
        }

        public ICommand AsistenciaAutoCommand
        {
            get
            {
                return new RelayCommand(AsistenciaAuto);
            }
        }

        private async void AsistenciaHogar()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistencia = MainViewModel.eTipoAsistencia.Hogar;
            vMainViewModel.AsistenciaHogar = new AsistenciaHogarViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AsistenciaHogarPage());
            this.IsRunning = false;
        }

        private async void AsistenciaAuto()
        {
            this.IsRunning = true;
            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.TipoAsistencia = MainViewModel.eTipoAsistencia.Auto;
            vMainViewModel.AsistenciaAuto = new AsistenciaAutoViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AsistenciaAutoPage());
            this.IsRunning = false;
        }
        #endregion
    }
}
