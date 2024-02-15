
using Newtonsoft.Json;
using RuteroApp.Utilidades;

namespace Inventario.Views;

public partial class PopConfServidor : ContentPage
{
    public PopConfServidor()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        SaveConection();
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        // Código que deseas ejecutar cuando la página aparece
        await ConexionMySql.GetConfig();
        txtBD.Text = MySqlDB.DataBase;
        txtIP.Text = MySqlDB.IP;
        txtPuerto.Text = MySqlDB.Puerto;
    }
    private async void SaveConection()
    {
        var conn = new { DataBase = txtBD.Text, IP = txtIP.Text, PUERTO = txtPuerto.Text };

        string data = JsonConvert.SerializeObject(conn);

        await SecureStorage.SetAsync("conexion.json", data);

        MySqlDB.IP = conn.IP;
        await DisplayAlert("Aviso", "DATOS DE CONEXIÓN GUARDADOS CON ÉXITO", "Aceptar");
    }
    private async void btnTestConection_Clicked(object sender, EventArgs e)
    {
        await this.DisplayAlert("Aviso", await ConexionMySql.TestConexion(), "Aceptar");
    }
}