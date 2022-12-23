using Microsoft.Toolkit.Uwp.Notifications;
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
    public sealed partial class CarritoPage : Page
    {
        private GestorProductos gestor;

        public CarritoPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is GestorProductos)
            {
                gestor = (GestorProductos)e.Parameter;
            }
            
            base.OnNavigatedTo(e);

            gvCarrito.ItemsSource = MainPage.gestor.carrito;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.gestor.carrito.Count>0)new ToastContentBuilder().AddArgument("action", "MainPage").AddText("Tramitando Pedido...").AddText("Tu pedido con "+MainPage.gestor.carrito.Count+" producto(s) esta siendo tramitado").Schedule(DateTime.Now.AddSeconds(5));//lanza una notificacion
            MainPage.gestor.carrito.Clear();
        }

        private void btnLimpiarCesta_Click(object sender, RoutedEventArgs e)
        {
            MainPage.gestor.carrito.Clear();
        }
    }
}
