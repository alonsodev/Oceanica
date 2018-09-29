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
    public class EditarPerfilHogarViewModel : BaseViewModel
    {
        #region Services
        private DataService dataService;
        #endregion

        #region Attributes
        private bool isRunning = false;
        private bool isBusy = false;
        private string titular;
        private string telefono;
        private string numPoliza;
        private string placa;
        private string chasis;
        private string modelo;
        private string marca;
        private string color;
        private string noCasa;
        private string apartamento;
        private PerfilLocal oPerfilLocal;

        #endregion

        #region Properties
        public bool FirstValidation
        {
            get;
            set;
        }
        public string Titular
        {
            get { return this.titular; }
            set { SetValue(ref this.titular, value); }
        }

        public string Telefono
        {
            get { return this.telefono; }
            set { SetValue(ref this.telefono, value); }
        }
        public string NumPoliza
        {
            get { return this.numPoliza; }
            set { SetValue(ref this.numPoliza, value); }
        }
        public string Placa
        {
            get { return this.placa; }
            set { SetValue(ref this.placa, value); }
        }
        public string Chasis
        {
            get { return this.chasis; }
            set { SetValue(ref this.chasis, value); }
        }
        public string Modelo
        {
            get { return this.modelo; }
            set { SetValue(ref this.modelo, value); }
        }
        public string Marca
        {
            get { return this.marca; }
            set { SetValue(ref this.marca, value); }
        }

        public string Color
        {
            get { return this.color; }
            set { SetValue(ref this.color, value); }
        }
        public string NoCasa
        {
            get { return this.noCasa; }
            set { SetValue(ref this.noCasa, value); }
        }
        public string Apartamento
        {
            get { return this.apartamento; }
            set { SetValue(ref this.apartamento, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsBusy
        {
            get { return this.isBusy; }
            set { SetValue(ref this.isBusy, value); }
        }
        #endregion

        #region Constructors
        public EditarPerfilHogarViewModel()
        {
            this.dataService = new DataService();
            oPerfilLocal = this.dataService.First<PerfilLocal>(false);
            if (oPerfilLocal != null)
            {
                this.Apartamento = oPerfilLocal.Apartamento;
                this.NoCasa = oPerfilLocal.NoCasa;
                this.NumPoliza = oPerfilLocal.NumPolizaHogar;
                this.Telefono = oPerfilLocal.TelefonoHogar;
                this.Titular = oPerfilLocal.TitularHogar;
            }
        }
        #endregion

        #region Commands
        public ICommand GuardarCommand
        {
            get
            {
                return new RelayCommand(Guardar);
            }
        }




        private async void Guardar()
        {
            this.IsRunning = true;
            this.IsBusy = true;

            if (!ValidateForm())
            {
                this.IsBusy = false;
                this.IsRunning = false;
                return;
            }

            if (oPerfilLocal == null) oPerfilLocal = new PerfilLocal();
            oPerfilLocal.Apartamento = this.Apartamento;
            oPerfilLocal.NoCasa = this.NoCasa;
            oPerfilLocal.NumPolizaHogar = this.NumPoliza;
            oPerfilLocal.TelefonoHogar = this.Telefono;
            oPerfilLocal.TitularHogar = this.Titular;
            this.dataService.InsertOrUpdate<PerfilLocal>(oPerfilLocal);

            this.IsBusy = false;
            this.IsRunning = false;

            var vMainViewModel = MainViewModel.GetInstance();
            vMainViewModel.MainMenu = new MainMenuViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
        }

        #endregion

        #region Methods
        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(this.Titular))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error",
                     "Tú debes ingresar el titular de la póliza.",
                     "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(this.Telefono))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error",
                     "Tú debes ingresar el teléfono de contacto.",
                     "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(this.NumPoliza))
            {
                Application.Current.MainPage.DisplayAlert(
                     "Error",
                     "Tú debes ingresar el número de póliza.",
                     "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(this.NoCasa))
            {
                Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Tú debes ingresar el No. de casa.",
                        "Aceptar");
                return false;
            }

            if (string.IsNullOrEmpty(this.Apartamento))
            {
                Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Tú debes ingresar el apartamento.",
                        "Aceptar");
                return false;
            }

            return true;
        }
        #endregion
    }
}
