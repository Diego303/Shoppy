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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Shoppy.Presentacion
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class InformacionProductoPage : Page
    {
        Producto producto;

        public InformacionProductoPage()
        {
            this.InitializeComponent();
        }

        private void btnAñadirCesta_Click(object sender, RoutedEventArgs e)
        {
            MainPage.gestor.anadirCarrito(producto);
            ibCorrecto.IsOpen = true;
        }

        private void btnAñadirCesta_PointerReleased(object sender, PointerRoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Producto)
            {
                producto = (Producto) e.Parameter;
                tbNombrePrenda.Text = producto.nombre;
                tbDescripccionPrenda.Text = producto.descripcion;
                imProducto.Source = new BitmapImage(producto.imagen);
                tbPrecio.Text = "PRECIO: " + producto.precio;
                //greeting.Text = $"Hi, {e.Parameter.ToString()}";
            }

            base.OnNavigatedTo(e);
        }
    }
}
