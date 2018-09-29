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

    public class EditarPerfilViewModel : BaseViewModel
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
        public EditarPerfilViewModel()
        {
            this.dataService = new DataService();
            oPerfilLocal = this.dataService.First<PerfilLocal>(false);
            if(oPerfilLocal != null)
            {
                //this.Apartamento = oPerfilLocal.Apartamento;
                this.Chasis = oPerfilLocal.Chasis;
                this.Color = oPerfilLocal.Color;
                this.Modelo = oPerfilLocal.Modelo;
                this.Marca = oPerfilLocal.Marca;
                //this.NoCasa = oPerfilLocal.NoCasa;
                this.NumPoliza = oPerfilLocal.NumPoliza;
                this.Placa = oPerfilLocal.Placa;
                this.Telefono = oPerfilLocal.Telefono;
                this.Titular = oPerfilLocal.Titular;
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
            oPerfilLocal.Chasis = this.Chasis;
            oPerfilLocal.Color = this.Color;
            oPerfilLocal.Modelo = this.Modelo;
            oPerfilLocal.Marca = this.Marca;
            oPerfilLocal.NoCasa = this.NoCasa;
            oPerfilLocal.NumPoliza = this.NumPoliza;
            oPerfilLocal.Placa = this.Placa;
            oPerfilLocal.Telefono = this.Telefono;
            oPerfilLocal.Titular = this.Titular;
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
            //número de poliza debe ser por cada uno? es decir, uno para auto y otro para casa?
            if (!string.IsNullOrEmpty(this.NumPoliza) || !string.IsNullOrEmpty(this.Placa) ||
                !string.IsNullOrEmpty(this.Chasis) || !string.IsNullOrEmpty(this.Marca) ||
                !string.IsNullOrEmpty(this.Modelo) || !string.IsNullOrEmpty(this.Color))
            {
                if (string.IsNullOrEmpty(this.NumPoliza))
                {
                    Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Tú debes ingresar el número de póliza.",
                         "Aceptar");
                    return false;
                }

                if (string.IsNullOrEmpty(this.Placa))
                {
                    Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Tú debes ingresar las placas o identificación.",
                         "Aceptar");
                    return false;
                }

                if (string.IsNullOrEmpty(this.Chasis))
                {
                    Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Tú debes ingresar el chasís.",
                         "Aceptar");
                    return false;
                }

                if (string.IsNullOrEmpty(this.Marca))
                {
                    Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Tú debes ingresar la marca.",
                         "Aceptar");
                    return false;
                }

                if (string.IsNullOrEmpty(this.Modelo))
                {
                    Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Tú debes ingresar el modelo.",
                         "Aceptar");
                    return false;
                }

                if (string.IsNullOrEmpty(this.Color))
                {
                    Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Tú debes ingresar el color.",
                         "Aceptar");
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(this.NoCasa) || !string.IsNullOrEmpty(this.Apartamento))
            {
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
            }

            return true;
        }
        #endregion
    }
}
