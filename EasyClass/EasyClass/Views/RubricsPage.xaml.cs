using EasyClass.Common.Models;
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
    public partial class RubricsPage : ContentPage
    {
        public RubricsPage()
        {
            InitializeComponent();

        }

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vm = BindingContext as RubricsViewModel;

            var rubrics = e.Item as Rubric;

            vm.HideOrShowRubric(rubrics);
        }
    }
}