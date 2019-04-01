using EasyClass.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyClass
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        //Metodo asincrono que le asigna función al botón "Entrar"
        private async void btnEntrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id_usuario.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una clave ID", "Aceptar");
                id_usuario.Focus();
            }

            else if (string.IsNullOrEmpty(password_usuario.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una contraseña", "Aceptar");
                password_usuario.Focus();
            }

            else
            {
                await ((NavigationPage)this.Parent).PushAsync(new Welcome());
            }
        }
	}
}
