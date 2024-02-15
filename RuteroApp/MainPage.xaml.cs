using Inventario.Views;
using RuteroApp.Models;
using RuteroApp.Utilidades;

namespace RuteroApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly ConexionDb _dbContex;
        public MainPage(ConexionDb dbContex)
        {
            _dbContex = dbContex;
            InitializeComponent();
            //lvEmpleados.ItemsSource = _dbContex.Empleados.ToList();
        }
        private async void btnTestConexion_Clicked(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            //{
            //    // En el código donde quieras mostrar el MessageBox
            //    await Application.Current.MainPage.DisplayAlert("Aviso", "Debe ingresar nombre y correo", "Aceptar");
            //    return;
            //}

            //_dbContex.Empleados.Add(new Models.Empleado
            //{
            //    IdEmpleado = Guid.NewGuid().ToString("N"),
            //    Nombre =  txtNombre.Text,
            //    Correo = txtCorreo.Text
            //});

            //_dbContex.SaveChanges();

            //lvEmpleados.ItemsSource = _dbContex.Empleados.ToList();
        }
        private void Otros()
        {
            // Nombre del empleado o parte del nombre que deseas buscar
            string nombreEmpleado = "Juan";

            // Recuperar la lista de empleados que coinciden con el criterio de búsqueda
            List<Empleado> empleados = _dbContex.Empleados.Where(e => e.Nombre.Contains(nombreEmpleado)).ToList();

            // Nombre del empleado que deseas buscar
            string nombreEmpleado2 = "Juan";

            // Recuperar el empleado por nombre utilizando FirstOrDefault o SingleOrDefault
            Empleado empleado = _dbContex.Empleados.FirstOrDefault(e => e.Nombre == nombreEmpleado2);
        }
        private async void btnConexion_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new PopConfServidor());
            }
            catch (Exception ex)
            {
                await DisplayAlert("Aviso", ex.Message, "Aceptar");
                Console.WriteLine($"Error al navegar a PopConfServidor: {ex.Message}");
            }
        }
    }

}
