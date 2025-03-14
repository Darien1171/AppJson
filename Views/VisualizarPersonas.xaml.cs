using AppJson.Json;
using AppJson.Models;

namespace AppJson.Views;

public partial class VisualizarPersonas : ContentPage
{
    private List<Persona> _personasList;

    public VisualizarPersonas()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarPersonas();
    }

    private async void CargarPersonas()
    {
        var personas = await PersonaJson.ListaPersonas();
        collectionViewPersonas.ItemsSource = personas;
    }

    private async void btnEliminarPersona_Clicked(object sender, EventArgs e)
    {

        var button = sender as Button;


        var persona = button.BindingContext as Persona;

        if (persona != null)
        {
            
            bool confirmar = await DisplayAlert("Confirmar",
                $"¿Está seguro que desea eliminar a {persona.Nombre}?", "Sí", "No");

            if (confirmar)
            {

                await PersonaJson.EliminarPersona(persona.IdPersona);


                collectionViewPersonas.ItemsSource = await PersonaJson.ListaPersonas();

                await DisplayAlert("Éxito", "Persona eliminada correctamente", "Aceptar");
            }
        }
    }
}