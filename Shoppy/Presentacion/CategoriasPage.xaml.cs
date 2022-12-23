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

namespace Shoppy
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CategoriasPage : Page
    {
        private GestorProductos gestorDatos;

        public CategoriasPage() 
        {
            this.InitializeComponent();
            gestorDatos = (GestorProductos) MainPage.gestor;
            gridDatosTotales();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is GestorProductos)
            {
                //gestorDatos = (GestorProductos)e.Parameter;
                //gridDatosTotales();
            }
            
            base.OnNavigatedTo(e);
        }

    //Metodos para Etiqueta HOMBRE
    private void tbHombre_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if ((bool)tbHombre.IsChecked)
            {
                tbMujer.IsChecked = false;
                  
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombres();
            }
        }

        private void comprobarCheck()
        {
            if ((!(bool)tbHombre.IsChecked)&& (!(bool)tbMujer.IsChecked) && (!(bool)tbPantalones.IsChecked) && (!(bool)tbCamisas.IsChecked) && (!(bool)tbZapatos.IsChecked) && (!(bool)tbComplementos.IsChecked) )
            {
                gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(-1, -1);
            }
            
        }

        private void tbHombre_Click(object sender, RoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbHombre.IsChecked)
            {
                tbMujer.IsChecked = false;

                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombres();
            }
        }

        //Metodos para Etiqueta MUJER
        private void tbMujer_Click(object sender, RoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbMujer.IsChecked)
            {
                tbHombre.IsChecked = false;

                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujer();
            }
        }

        private void tbMujer_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbMujer.IsChecked)
            {
                tbHombre.IsChecked = false;

                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujer();
            }
        }

        //Metodos para cada categoria CAMISAS
        private void tbCamisas_Click(object sender, RoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbCamisas.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombresCamisas();

            }
            else if ((bool)tbCamisas.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujerCamisas();
            }
            else if ((bool)tbCamisas.IsChecked)
            {
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosCamisas();
            }
        }

        private void tbCamisas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbCamisas.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombresCamisas();

            }
            else if ((bool)tbCamisas.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujerCamisas();
            }
            else if ((bool)tbCamisas.IsChecked)
            {
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosCamisas();
            }
        }

        //Metodos para cada categoria PANTALONES
        private void tbPantalones_Click(object sender, RoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbPantalones.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombresPantalones();

            }
            else if ((bool)tbPantalones.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujerPantalones();
            }
            else if ((bool)tbPantalones.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosPantalones();
            }
        }

        private void tbPantalones_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbPantalones.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombresPantalones();

            }
            else if ((bool)tbPantalones.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujerPantalones();
            }
            else if ((bool)tbPantalones.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbZapatos.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosPantalones();
            }
        }

        //Metodos para cada categoria ZAPATOS
        private void tbZapatos_Click(object sender, RoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbZapatos.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombresZapatos();

            }
            else if ((bool)tbZapatos.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujerZapatos();
            }
            else if ((bool)tbZapatos.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosZapatos();
            }
        }

        private void tbZapatos_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbZapatos.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosHombresZapatos();

            }
            else if ((bool)tbZapatos.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosMujerZapatos();
            }
            else if ((bool)tbZapatos.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbComplementos.IsChecked = false;

                gridDatosZapatos();
            }
        }

        //Metodos para cada categoria COMPLEMENTOS
        private void tbComplementos_Click(object sender, RoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbComplementos.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;

                gridDatosHombresComplementos();

            }
            else if ((bool)tbComplementos.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;

                gridDatosMujerComplementos();
            }
            else if ((bool)tbComplementos.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;

                gridDatosComplementos();
            }
        }

        private void tbComplementos_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            comprobarCheck();
            if ((bool)tbComplementos.IsChecked && (bool)tbHombre.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;

                gridDatosHombresComplementos();

            }
            else if ((bool)tbComplementos.IsChecked && (bool)tbMujer.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;

                gridDatosMujerComplementos();
            }
            else if ((bool)tbComplementos.IsChecked)
            {
                tbCamisas.IsChecked = false;
                tbPantalones.IsChecked = false;
                tbZapatos.IsChecked = false;

                gridDatosComplementos();
            }
        }

        //METODOS PARA RECAGAR DATOS GRID
        public void gridDatosTotales()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(-1,-1);
        }

        public void gridDatosHombres()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(-1,1);
        }

        public void gridDatosMujer()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(-1, 0);
        }

        public void gridDatosHombresCamisas()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(0, 1);
        }

        public void gridDatosHombresPantalones()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(1, 1);
        }

        public void gridDatosHombresZapatos()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(2, 1);
        }

        public void gridDatosHombresComplementos()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(3, 1);
        }

        public void gridDatosMujerCamisas()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(0, 0);
        }

        public void gridDatosMujerPantalones()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(1, 0);
        }

        public void gridDatosMujerZapatos()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(2, 0);
        }

        public void gridDatosMujerComplementos()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(3, 0);
        }

        public void gridDatosCamisas()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(0, -1);
        }

        public void gridDatosPantalones()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(1, -1);
        }

        public void gridDatosZapatos()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(2, -1);
        }

        public void gridDatosComplementos()
        {
            gridViewCategorias.ItemsSource = MainPage.gestor.getPorCategoriayGenero(3, -1);
        }
    }
}
