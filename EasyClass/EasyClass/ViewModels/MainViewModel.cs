namespace EasyClass.ViewModels
{ 
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class MainViewModel
    {
        public RubricsViewModel Rubrics { get; set; }

        public MainViewModel()
        {
            this.Rubrics = new RubricsViewModel();
        }


    }
}
