using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyClass.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuRubric : ContentPage
	{
		public MenuRubric ()
		{
			InitializeComponent ();
		}

        private async void btnMis_Rubricas_Clicked(object sender, EventArgs e)
        {
            await ((NavigationPage)this.Parent).PushAsync(new RubricsPage());
        }
	}
}