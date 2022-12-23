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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Shoppy
{
    public sealed partial class UC_Ropa : UserControl
    {
        public UC_Ropa()
        {
            this.InitializeComponent();
        }

        public Producto Datos
        {
            get { return (Producto)GetValue(ProjectSourceProperty); }
            set { SetValue(ProjectSourceProperty, value); }
        }

        public static readonly DependencyProperty ProjectSourceProperty =
            DependencyProperty.Register("Datos", typeof(Producto), typeof(UC_Ropa), new PropertyMetadata(0, new PropertyChangedCallback(CallBack)));

        private static void CallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as UC_Ropa;
            if (e.NewValue != e.OldValue)
            {
                current.tbNombre.Text = (e.NewValue as Producto).nombre;
            }
        }
    }
}
