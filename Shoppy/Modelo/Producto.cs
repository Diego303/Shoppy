using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Shoppy.Modelo
{
    public class Producto
    {
        public Producto(int codigo, string nombre, double precio, Uri imagen, string descripcion, int categoria, bool hombre, bool masvendido, bool nuevacoleccion)
        {
            this.codigo = codigo; this.nombre = nombre; this.precio = precio; this.imagen = imagen; this.descripcion = descripcion; this.categoria = categoria; this.hombre = hombre; this.masvendido = masvendido; this.nuevacoleccion = nuevacoleccion;
            this.favorito = false;
            this.cantidad = 0;
        }

        public int codigo
        {
            get;
            set;
        }
        public string nombre
        {
            get;
            set;
        }

        public double precio
        {
            get;
            set;
        }

        public Uri imagen
        {
            get;
            set;
        }

        public string descripcion
        {
            get;
            set;
        }

        public int categoria
        {
            get;
            set;
        }

        public bool hombre
        {
            get;
            set;
        }

        public bool masvendido
        {
            get;
            set;
        }
        public bool nuevacoleccion
        {
            get;
            set;
        }

        public bool favorito
        {
            get;
            set;
        }
        public int cantidad { get; set; }
    }
}
