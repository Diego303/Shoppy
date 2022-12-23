using Shoppy.Modelo;
using Shoppy.Persistencia;
using Shoppy.Presentacion;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Shoppy
{
    public sealed partial class UC_Producto : UserControl
    {
        private GestorProductos gestor;

        public String nombrePrenda
        {
            get { return tbNombrePrenda.Text; }
            set { tbNombrePrenda.Text = value; }
        }

        public String precioPrenda
        {
            get { return tbPrecioPrenda.Text; }
            set { tbPrecioPrenda.Text = value; }
        }

        public ImageSource imagen
        {
            get { return imProducto.Source; }
            set { imProducto.Source = value; }
        }

        public static bool favoritos;
        public static int codigoPrenda;

        public UC_Producto()
        {
            this.InitializeComponent();
            gestor = MainPage.gestor;

            cargarFavoritos();

        }

        private void corazon_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (favoritos)
            {
                Storyboard sbFav = (Storyboard)this.Resources["descolorearCorazon"];
                sbFav.Begin();

                MainPage.gestor.setFavoritos(codigoPrenda, false);
                favoritos = false;
            }
            else
            {
                Storyboard sbFav = (Storyboard)this.Resources["colorearCorazon"];
                sbFav.Begin();

                MainPage.gestor.setFavoritos(codigoPrenda, true);
                favoritos = true;
            }
        }

        public void cargarFavoritos()
        {
            if (favoritos)
            {
                Storyboard sbFav = (Storyboard) this.Resources["colorearCorazon"];
                sbFav.Begin();
            }
            else
            {
                Storyboard sbFav = (Storyboard) this.Resources["descolorearCorazon"];
                sbFav.Begin();
            }
        }

        public Producto Datos
        {
            get { return (Producto)GetValue(ProjectSourceProperty); }
            set { SetValue(ProjectSourceProperty, value); }
        }

        public static readonly DependencyProperty ProjectSourceProperty =
            DependencyProperty.Register("Datos", typeof(Producto), typeof(UC_Producto), new PropertyMetadata(0, new PropertyChangedCallback(CallBack)));

        private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as UC_Producto;
            if (e.NewValue != e.OldValue)
            {
                if ((e.NewValue as Producto) != null)
                {
                    current.tbNombrePrenda.Text = (e.NewValue as Producto).nombre;
                    current.tbPrecioPrenda.Text = (e.NewValue as Producto).precio.ToString();
                    current.imProducto.Source = new BitmapImage((e.NewValue as Producto).imagen);

                    favoritos = (e.NewValue as Producto).favorito;
                    codigoPrenda = (e.NewValue as Producto).codigo;
                } 
                
            }
        }

        //Abrir FRAME de informacion
        private void imProducto_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            List<Producto> tmp = gestor.getBusqueda(tbNombrePrenda.Text);
            Producto ptmp = tmp.ElementAt(0);
            MainPage.Current.fmPrincipal.Navigate(typeof(InformacionProductoPage), ptmp);
        }

        private void tbNombrePrenda_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            List<Producto> tmp = gestor.getBusqueda(tbNombrePrenda.Text);
            Producto ptmp = tmp.ElementAt(0);
            MainPage.Current.fmPrincipal.Navigate(typeof(InformacionProductoPage), ptmp);
        }

        private void tbPrecioPrenda_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            List<Producto> tmp = gestor.getBusqueda(tbNombrePrenda.Text);
            Producto ptmp = tmp.ElementAt(0);
            MainPage.Current.fmPrincipal.Navigate(typeof(InformacionProductoPage), ptmp);
        }
    }
}
