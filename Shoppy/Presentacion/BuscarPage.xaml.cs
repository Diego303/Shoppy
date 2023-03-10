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
    public sealed partial class BuscarPage : Page
    {
        private GestorProductos gestor;

        public BuscarPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is GestorProductos)
            {
                gestor = (GestorProductos)e.Parameter;

            }
            
            base.OnNavigatedTo(e);
            gridDatos.ItemsSource = MainPage.gestor.getPorCategoriayGenero(-1, -1);
        }

        private void tbFavoritos_Checked(object sender, RoutedEventArgs e)
        {

            gridDatos.ItemsSource = MainPage.gestor.getFavoritos();
            tbBusqueda.Text = "";

        }

        private void tbBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbFavoritos.IsChecked = false;
            gridDatos.ItemsSource = MainPage.gestor.getBusqueda(tbBusqueda.Text);
        }

        private void tbFavoritos_Unchecked(object sender, RoutedEventArgs e)
        {
            gridDatos.ItemsSource = MainPage.gestor.getPorCategoriayGenero(-1, -1);
        }
    }
}
