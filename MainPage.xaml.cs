using AppJson.Json;
using AppJson.Models;

namespace AppJson
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            CargarGrupos();
        }

        private async void CargarGrupos()
        {
            var grupos = await GrupoJson.ListaGrupos();
            collectionViweGrupos.ItemsSource = grupos;
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Grupo oGrupo = new Grupo();
            oGrupo.IdGrupo = new Random().Next(1, 9999);
            oGrupo.NombreGrupo = txtNombre.Text;
            oGrupo.DescripcionGrupo = txtDescripcion.Text;

            var grupos = await GrupoJson.ListaGrupos();
            grupos.Add(oGrupo);
            await GrupoJson.RegistrarGrupo(grupos);

            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;

            await DisplayAlert("Registro Grupo", "Grupo Registrado", "OK");
        }
    }

}
