using Shoppy.Modelo;
using Shoppy.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Shoppy.Presentacion
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MiCuentaPage : Page
    {

        private Usuario usuario;

        public MiCuentaPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

        }

        private void btnCerrarAplicacion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Usuario)
            {
                usuario = (Usuario)e.Parameter;
                tbApellidos.Text = usuario.apellidos;
                tbNombre.Text = usuario.nombre;
                tbDireccion.Text = usuario.direccion;
                tbTelefono.Text = usuario.telefono;
                tbEmail.Text = usuario.correo;

            }

            base.OnNavigatedTo(e);
        }

        private void btnGuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            usuario.apellidos = tbApellidos.Text;
            usuario.nombre = tbNombre.Text;
            usuario.direccion = tbDireccion.Text;
            usuario.telefono = tbTelefono.Text;
            usuario.correo = tbEmail.Text;

            ibCorrecto.IsOpen = true;
        }
    }
}
