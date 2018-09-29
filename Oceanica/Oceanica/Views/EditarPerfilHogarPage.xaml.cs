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
	public partial class EditarPerfilHogarPage : ContentPage
	{
		public EditarPerfilHogarPage ()
		{ 
			InitializeComponent ();
            var vm = (MainViewModel)BindingContext;
            /*if (vm.EditarPerfilHogar.FirstValidation)
            {
                //NavigationPage.SetHasNavigationBar(this, false);
                NavigationPage.SetHasBackButton(this, false);
            }*/
        }
	}
}