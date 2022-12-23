using Shoppy.Modelo;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Shoppy
{
    public sealed partial class UC_ProductoCarrito : UserControl
    {

        public String nombrePrenda
        {
            get { return tbNombreProducto.Text; }
            set { tbNombreProducto.Text = value; }
        }

        public String precioPrenda
        {
            get { return tbPrecio.Text; }
            set { tbPrecio.Text = value; }
        }

        public ImageSource imagen
        {
            get { return imProducto.Source; }
            set { imProducto.Source = value; }
        }

        public int cantidad
        {
            get { return int.Parse(tbCantidad.Text); }
            set { tbCantidad.Text = value.ToString(); }
        }

        public UC_ProductoCarrito()
        {
            this.InitializeComponent();
        }

        public Producto Datos
        {
            get { return (Producto)GetValue(ProjectSourceProperty); }
            set { SetValue(ProjectSourceProperty, value); }
        }

        public static readonly DependencyProperty ProjectSourceProperty =
            DependencyProperty.Register("Datos", typeof(Producto), typeof(UC_ProductoCarrito), new PropertyMetadata(0, new PropertyChangedCallback(CallBack)));

        private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as UC_ProductoCarrito; 
            if (e.NewValue != e.OldValue && !typeof(int).IsInstanceOfType(e.NewValue))
            {
                    current.tbNombreProducto.Text = (e.NewValue as Producto).nombre;
                    current.tbPrecio.Text = (e.NewValue as Producto).precio.ToString();
                    current.imProducto.Source = new BitmapImage((e.NewValue as Producto).imagen);

            }
        }

        private void iconAdd_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            cantidad += 1;
            MainPage.gestor.anadirCarrito(Datos);
        }

        private void iconRemove_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (cantidad == 1)
            {
                //NO baja nunca de 1
            } else
            {
                MainPage.gestor.quitarCarrito(Datos);
                cantidad -= 1;
            }
            
        }

        private void iconBorrar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            MainPage.gestor.eliminarCarrito(Datos);
        }
    }
}
