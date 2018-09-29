using System;
using System.Collections.Generic;
using System.Text;

namespace Oceanica.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    using Plugin.Messaging;
    using Oceanica.Services;
    using Oceanica.Models;

    public class EnviarInfoViewModel : BaseViewModel
    {
        #region Services
        private DataService dataService;
        #endregion

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
        public EnviarInfoViewModel()
        {
            this.dataService = new DataService();
        }
        #endregion

        #region Commands
        public ICommand EnviarCommand
        {
            get
            {
                return new RelayCommand(Enviar);
            }
        }

        private async void Enviar()
        {
            this.IsRunning = true;
            
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            PerfilLocal oPerfilLocal = this.dataService.First<PerfilLocal>(false);
            //_cFormDataModel.DocIdentidad = txtDocIdentidad.Text;
            var vMainViewModel = MainViewModel.GetInstance();

            try
            {
                if (emailMessenger.CanSendEmail)
                {
                    String strCuerpoCorreo = "";
                    if (vMainViewModel.TipoAsistencia == MainViewModel.eTipoAsistencia.Hogar)
                    {
                        strCuerpoCorreo += "Nombre y apellidos de la persona solicitando asistencia:\n" + oPerfilLocal.TitularHogar + "\n\n";
                        strCuerpoCorreo += "Teléfono de contacto:\n" + oPerfilLocal.TelefonoHogar + "\n\n";
                        strCuerpoCorreo += "Número de póliza:\n" + oPerfilLocal.NumPolizaHogar + "\n\n";
                    }
                    else if (vMainViewModel.TipoAsistencia == MainViewModel.eTipoAsistencia.Auto)
                    {
                        strCuerpoCorreo += "Nombre y apellidos de la persona solicitando asistencia:\n" + oPerfilLocal.Titular + "\n\n";
                        strCuerpoCorreo += "Teléfono de contacto:\n" + oPerfilLocal.Telefono + "\n\n";
                        strCuerpoCorreo += "Número de póliza:\n" + oPerfilLocal.NumPoliza + "\n\n";
                    }

                    strCuerpoCorreo += "Dirección exacta (Provincia, Cantón, Distrito y puntos de referencia):\n" + vMainViewModel.DireccionAsistencia + "\n\n";
                    strCuerpoCorreo += "Coordenadas de Geolocalización:\n" + vMainViewModel.CoordenadasAsistencia + "\n\n";
                    strCuerpoCorreo += "Tipo de servicio requerido:\n";
                    if (vMainViewModel.TipoAsistencia == MainViewModel.eTipoAsistencia.Hogar)
                    {
                        strCuerpoCorreo += "Asistencia al Hogar" + "\n\n";

                        strCuerpoCorreo += "No. casa:\n";
                        strCuerpoCorreo += oPerfilLocal.NoCasa + "\n\n";

                        strCuerpoCorreo += "Apartamento o comercial:\n";
                        strCuerpoCorreo += oPerfilLocal.Apartamento + "\n\n";


                        if (vMainViewModel.TipoAsistenciaHogar == MainViewModel.eTipoAsistenciaHogar.Plomeria)
                        {
                            strCuerpoCorreo += "Plomería" + "\n\n";
                        }
                        else if (vMainViewModel.TipoAsistenciaHogar == MainViewModel.eTipoAsistenciaHogar.Vidreria)
                        {
                            strCuerpoCorreo += "Vidreria" + "\n\n";
                        }
                        else if (vMainViewModel.TipoAsistenciaHogar == MainViewModel.eTipoAsistenciaHogar.Electricidad)
                        {
                            strCuerpoCorreo += "Electricidad" + "\n\n";
                        }
                        else if (vMainViewModel.TipoAsistenciaHogar == MainViewModel.eTipoAsistenciaHogar.Cerrajeria)
                        {
                            strCuerpoCorreo += "Cerrajeria" + "\n\n";
                        }
                        else if (vMainViewModel.TipoAsistenciaHogar == MainViewModel.eTipoAsistenciaHogar.Otros)
                        {
                            strCuerpoCorreo += "Otros" + "\n\n";
                        }
                    }
                    else if (vMainViewModel.TipoAsistencia == MainViewModel.eTipoAsistencia.Auto)
                    {
                        strCuerpoCorreo += "Asistencia al Auto" + "\n\n";

                        strCuerpoCorreo += "Placas o identificación:\n";
                        strCuerpoCorreo += oPerfilLocal.Placa + "\n\n";

                        strCuerpoCorreo += "Chasis:\n";
                        strCuerpoCorreo += oPerfilLocal.Chasis + "\n\n";

                        strCuerpoCorreo += "Marca del vehículo:\n";
                        strCuerpoCorreo += oPerfilLocal.Marca + "\n\n";

                        strCuerpoCorreo += "Modelo:\n";
                        strCuerpoCorreo += oPerfilLocal.Modelo + "\n\n";

                        strCuerpoCorreo += "Color:\n";
                        strCuerpoCorreo += oPerfilLocal.Color + "\n\n";

                        if (vMainViewModel.TipoAsistenciaAuto == MainViewModel.eTipoAsistenciaAuto.Averia)
                        {
                            strCuerpoCorreo += "Avería o Grua" + "\n\n";
                            strCuerpoCorreo += "El vehículo se puede movilizar?" + "\n";
                            strCuerpoCorreo += (vMainViewModel.VehiculoMovilizar == MainViewModel.eSiNo.Si ? "Si" : "No") + "\n\n";
                            strCuerpoCorreo += "El vehículo se encuentra dentro de un lugar techado?" + "\n";
                            strCuerpoCorreo += (vMainViewModel.VehiculoLugarTechado == MainViewModel.eSiNo.Si ? "Si" : "No") + "\n\n";
                        }
                        else if (vMainViewModel.TipoAsistenciaAuto == MainViewModel.eTipoAsistenciaAuto.Accidente)
                        {
                            strCuerpoCorreo += "Accidente / Colisión" + "\n\n";
                            strCuerpoCorreo += "Hay heridos?" + "\n";
                            strCuerpoCorreo += (vMainViewModel.AccidenteHayHeridos == MainViewModel.eSiNo.Si ? "Si" : "No") + "\n\n";
                        }
                        else if (vMainViewModel.TipoAsistenciaAuto == MainViewModel.eTipoAsistenciaAuto.Auxilio)
                        {
                            strCuerpoCorreo += "Auxilio" + "\n\n";
                            if (vMainViewModel.TipoAsistenciaAutoAuxilio == MainViewModel.eTipoAsistenciaAutoAuxilio.PasoCorriente)
                            {
                                strCuerpoCorreo += "Paso Corriente" + "\n\n";
                            }
                            else if (vMainViewModel.TipoAsistenciaAutoAuxilio == MainViewModel.eTipoAsistenciaAutoAuxilio.SuministroCombustible)
                            {
                                strCuerpoCorreo += "Suministro de Combustible" + "\n\n";
                                if (vMainViewModel.TipoAsistenciaAutoAuxilioCombustible == MainViewModel.eTipoAsistenciaAutoAuxilioCombustible.Regular)
                                {
                                    strCuerpoCorreo += "Regular" + "\n\n";
                                }
                                else if (vMainViewModel.TipoAsistenciaAutoAuxilioCombustible == MainViewModel.eTipoAsistenciaAutoAuxilioCombustible.Super)
                                {
                                    strCuerpoCorreo += "Super" + "\n\n";
                                }
                                else if (vMainViewModel.TipoAsistenciaAutoAuxilioCombustible == MainViewModel.eTipoAsistenciaAutoAuxilioCombustible.Diesel)
                                {
                                    strCuerpoCorreo += "Diesel" + "\n\n";
                                }
                            }
                            else if (vMainViewModel.TipoAsistenciaAutoAuxilio == MainViewModel.eTipoAsistenciaAutoAuxilio.CambioLlanta)
                            {
                                strCuerpoCorreo += "Cambio de Llanta" + "\n\n";
                                strCuerpoCorreo += "Dispone de todos los elementos necesarios para realizar el cambio de llanta?" + "\n";
                                strCuerpoCorreo += (vMainViewModel.ElementosCambioLlanta == MainViewModel.eSiNo.Si ? "Si" : "No") + "\n\n";
                            }
                        }
                    }

                    strCuerpoCorreo += "Descripción de lo sucedido:\n" + vMainViewModel.DescripcionAsistencia;
                    // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                    try
                    {
                        emailMessenger.SendEmail("solicitudesapp@axa-assistance.com.pa", "Solicitud de asistencia Oceánica de Seguros, APP", strCuerpoCorreo);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Por favor instalar una aplicación para correo eletrónico y volver a ingresar a la aplicación.",
                         "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                         "Error",
                         "Por favor instalar una aplicación para correo eletrónico y volver a ingresar a la aplicación.",
                         "Aceptar");
            }
            

            vMainViewModel.MainMenu = new MainMenuViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
            this.IsRunning = false;
        }

        #endregion
    }
}
