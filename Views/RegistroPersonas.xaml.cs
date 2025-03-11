using AppJson.Json;
using AppJson.Models;

namespace AppJson.Views;

public partial class RegistroPersonas : ContentPage
{
	public RegistroPersonas()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var grupos = await GrupoJson.ListaGrupos();
        pickerGrupo.ItemsSource = grupos;
        pickerGrupo.ItemDisplayBinding = new Binding("NombreGrupo");
    }

    private void btnFoto_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        Persona oPersona = new Persona();
        oPersona.IdPersona = new Random().Next(1, 9999);
        oPersona.Nombre = txtNombre.Text;
        oPersona.Descripcion = txtDescripcion.Text;
        oPersona.Celular = txtCelular.Text;
        oPersona.email = txtEmail.Text;
        oPersona.FechaCumple = dateFechaCumple.Date;
        oPersona.Foto = "imagen.png";

        var grupoSelecc = (Grupo)pickerGrupo.SelectedItem;
        oPersona.idGrupo = grupoSelecc.IdGrupo;

        var personas = await PersonaJson.ListaPersonas();
        personas.Add(oPersona);
        await PersonaJson.RegistrarPersona(personas);

        txtNombre.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
        txtCelular.Text = string.Empty;
        txtEmail.Text = string.Empty;
        dateFechaCumple.Date = DateTime.Today;
        pickerGrupo.SelectedIndex = -1;

        await DisplayAlert("Registro", "persona Registrada....", "ok");
    }
}