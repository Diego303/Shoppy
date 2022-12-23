using Shoppy.Modelo;
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

// La plantilla de elemento del cuadro de diálogo de contenido está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Shoppy.Presentacion
{
    public sealed partial class RegistroCD : ContentDialog
    {
        internal Usuario Usuario { get; set; }
        public RegistroCD()
        {
            this.InitializeComponent();
            Usuario = new Usuario(0, "Juan", "Fernandez Castaño", "Calle falsa, 123", "622 34 69 96", "juan@ejemplo.com", "123456");
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (txtContrasena.Password == "" || txtCorreo.Text == "" || txtNombre.Text == "" || txtApellidos.Text == "" || txtDireccion.Text == "" || txtTelefono.Text == "")
            {
                ibCamposObligatorios.IsOpen = true;
            }
            else
            {
                Usuario = new Usuario(0, txtNombre.Text, txtApellidos.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, txtContrasena.Password);
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            // no hace nada
        }
    }
}
