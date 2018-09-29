using Oceanica.Models;
using Oceanica.Services;
using Oceanica.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Oceanica.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuEditarPerfilPage : ContentPage
	{
        #region Services
        private DataService dataService;
        #endregion

        public MenuEditarPerfilPage ()
		{
			InitializeComponent ();
            var vm = (MainViewModel)BindingContext;
            if (vm.MenuEditarPerfil.FirstValidation)
            {
                //NavigationPage.SetHasNavigationBar(this, false);
                NavigationPage.SetHasBackButton(this, false);
            }
        }

    }
}