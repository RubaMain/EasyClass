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
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //var _navigation = Application.Current.MainPage.Navigation;
            //var _lastPage = Navigation.NavigationStack.LastOrDefault();
            //_navigation.RemovePage(_lastPage);
            //_navigation.PushAsync(new MainPage());
            await ((NavigationPage)this.Parent).PushAsync(new MainPage());
        }
    }
}