using EasyClass.Common.Models;
using EasyClass.Services;
using EasyClass.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

public class RubricsViewModel : BaseViewModel
{
    //Variables e Instancias.
    private ApiService apiService;

    private ObservableCollection<Rubric> rubrics;

    //Colección de Rúbricas.
    public ObservableCollection<Rubric> Rubrics
    {
        get { return this.rubrics; }
        set { this.SetValue(ref this.rubrics, value); }
    }


    public RubricsViewModel()
    {
        this.apiService = new ApiService();
        this.LoadRubrics();
    }

    public void HideOrShowRubric(Rubric rubric)
    {
        rubric.IsVisible = true;
    }

    //Metodo asincrono para refrescar la consulta de
    //una lista de rúbricas desde la app sin salir de ella.
    private async void LoadRubrics()
    {
        var response = await this.apiService.GetList<Rubric>("https://easyclassapi.azurewebsites.net", "/api", "/Rubrics");
        if (!response.IsSuccess)
        {
            await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            return;
        }

        var list = (List<Rubric>)response.Result;
        this.Rubrics = new ObservableCollection<Rubric>(list);
    }

    //Comando usado para ejecutar nuevamente el método que carga la lista de rúbricas en la aplicación.
    /*public ICommand RefreshCommand
    {
        get
        {
            return new RelayCommand(LoadRubrics);
        }
    }*/
}
