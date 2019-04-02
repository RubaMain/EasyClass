using EasyClass.Common.Models;
using EasyClass.Services;
using EasyClass.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

public class RubricsViewModel : BaseViewModel
{
    //Variables e Instancias.
    private ApiService apiService;

    private bool isRefreshing;

    private ObservableCollection<Rubric> rubrics;

    //Colección de Rúbricas.
    public ObservableCollection<Rubric> Rubrics
    {
        get { return this.rubrics; }
        set { this.SetValue(ref this.rubrics, value); }
    }

    //To Refresh the RubricListView in the Application.
    public bool IsRefreshing
    {
        get { return this.isRefreshing; }
        set { this.SetValue(ref this.isRefreshing, value); }
    }


    public RubricsViewModel()
    {
        this.apiService = new ApiService();
        this.LoadRubrics();
    }

    //To show The title and the description of the rubric
    public void HideOrShowRubric(Rubric rubric)
    {
        rubric.IsVisible = true;
    }

    //Method async to refresh a query of
    //a list of rubrics from the application without leaving it.
    private async void LoadRubrics()
    {
        this.IsRefreshing = true;
        var response = await this.apiService.GetList<Rubric>("https://easyclassapi.azurewebsites.net", "/api", "/Rubrics");
        if (!response.IsSuccess)
        {
            this.IsRefreshing = false;
            await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            return;
        }

        var list = (List<Rubric>)response.Result;
        this.Rubrics = new ObservableCollection<Rubric>(list);
        this.IsRefreshing = false;
    }

    //Comando usado para ejecutar nuevamente el método que carga la lista de rúbricas en la aplicación.
    public ICommand RefreshCommand
    {
        get
        {
            return new RelayCommand(LoadRubrics);
        }
    }
}
