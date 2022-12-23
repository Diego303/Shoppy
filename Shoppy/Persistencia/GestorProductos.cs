using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Shoppy.Modelo;

namespace Shoppy.Persistencia
{
    public class GestorProductos
    {

        private List<Producto> todos;

        public ObservableCollection<Producto> carrito;

        public GestorProductos()
        {
            this.todos = new List<Producto>();
            //estructura producto: codigo, nombre, precio, foto, descripcion, categoria, hombre, masvendido, nuevacoleccion
            //categorias de 0 a 3: camisas, pantalones, zapatos, complementos
            todos.Add(new Producto(1, "Bolso marron",49.99, new Uri("ms-appx:///Assets/Imagenes/bolsomarronmujer.jfif"),"Bolso Marron para mujer en cuero de alta calidad",3, false, true, false));
            todos.Add(new Producto(2, "Camisa azul", 19.99, new Uri("ms-appx:///Assets/Imagenes/camisahombreazul.jpg"), "Camisa para hombre de color azul cielo fabricada en lino", 0, true, true, true));
            todos.Add(new Producto(3, "Camisa estilo leñador", 69.99, new Uri("ms-appx:///Assets/Imagenes/camisahombrelenador.jpg"), "Camisa estilo leñador fabricada en tela 100% algodon con la calidad de la mejor fabrica española", 0, true, true, false));
            todos.Add(new Producto(4, "Camisa lino rosa", 99.99, new Uri("ms-appx:///Assets/Imagenes/camisahombrerosa.jpg"), "Camisa de lino rosa para hombre con acabado sedoso", 0, true, false, false));
            todos.Add(new Producto(5, "Camisa ligera azul", 23.00, new Uri("ms-appx:///Assets/Imagenes/camisamujerazul.jpg"), "Camisa azul marino para mujer intermedia fabricada en tela mixta con algodón y sintético", 0, false, false, true));
            todos.Add(new Producto(6, "Camisa a cuadros", 19.99, new Uri("ms-appx:///Assets/Imagenes/camisamujercuadros.jfif"), "Camisa a cuadros para mujer con textura lisa", 0, false, true, true));
            todos.Add(new Producto(7, "Camisa rosa", 19.99, new Uri("ms-appx:///Assets/Imagenes/camisamujerrosa.jpg"), "Camisa rosa para mujer en tela 100% algodon con la calidad de la mejor fabrica española", 0, false, true, true));
            todos.Add(new Producto(8, "Cartera negra", 9.99, new Uri("ms-appx:///Assets/Imagenes/carterahombre.jfif"), "Cartera para hombre fabricada en cuero, con monedero, billetera y tarjetero", 3, true, true, true));
            todos.Add(new Producto(9, "Collar negro", 10.50, new Uri("ms-appx:///Assets/Imagenes/collarhombre.jfif"), "Collar negro para hombre con forma de diamante, correa de tela negra etc", 3, true, false, true));
            todos.Add(new Producto(10, "Diadema colorida", 19.99, new Uri("ms-appx:///Assets/Imagenes/diademamujer.jfif"), "Diadema colorida para mujer, diametro 35cm, tacto suave y espumado", 3, false, true, false));
            todos.Add(new Producto(11, "Pantalon vaquero azul", 19.99, new Uri("ms-appx:///Assets/Imagenes/pantalonhombreazul.jpeg"), "Pantalon vaquero azul fabricado en tela 100% de calidad de la mejor fabrica española", 1, true, false, true));
            todos.Add(new Producto(12, "Pantalon marron", 19.99, new Uri("ms-appx:///Assets/Imagenes/pantalonhombremarron.jpg"), "Pantalon marron fabricado en tela 100% algodon con la calidad de la mejor fabrica española", 1, true, false, true));
            todos.Add(new Producto(13, "Pantalon vaquero negro", 19.99, new Uri("ms-appx:///Assets/Imagenes/pantalonhombrenegro.jpeg"), "Pantalon negro fabricado en tela 100% algodon con la calidad de la mejor fabrica española", 1, true, true, true));
            todos.Add(new Producto(14, "Pantalon vaquero azul", 17.75, new Uri("ms-appx:///Assets/Imagenes/pantalonmujerazul.jpg"), "Pantalon vaquero azul ajuste perfecto para mujer fabricado en tela 100% algodon con la calidad de la mejor fabrica española", 1, false, true, true));
            todos.Add(new Producto(15, "Pantalon negro", 19.99, new Uri("ms-appx:///Assets/Imagenes/pantalonmujernegro.jpg"), "Pantalon negro skinny para mujer fabricado en tela 100% algodon con la calidad de la mejor fabrica española", 1, false, false, true));
            todos.Add(new Producto(16, "Pantalon azul", 19.99, new Uri("ms-appx:///Assets/Imagenes/pantalonmujerverde.jpg"), "Pantalon ancho azul fabricado en tela 100% algodon con la calidad de la mejor fabrica española", 1, false, false, false));
            todos.Add(new Producto(17, "Pendientes flor", 19.99, new Uri("ms-appx:///Assets/Imagenes/pendientesmujer.jfif"), "Pendientes para mujer en forma de flor, necesario agujero de 1mm", 3, false, false, true));
            todos.Add(new Producto(18, "Pulsera negra", 19.99, new Uri("ms-appx:///Assets/Imagenes/pulserahombrenegra.jfif"), "Pulsera negra para hombre", 3, true, true, true));
            todos.Add(new Producto(19, "Zapato azul", 19.99, new Uri("ms-appx:///Assets/Imagenes/zapatohombreazul.jfif"), "Zapato azul en cuero para hombre de estilo clasico", 2, true, false, true));
            todos.Add(new Producto(20, "Zapatos marrones", 19.99, new Uri("ms-appx:///Assets/Imagenes/zapatohombremarron.jpg"), "Zapatos marrones para hombre estilo clasico en cuero español", 2, true, false, true));
            todos.Add(new Producto(21, "Zapatos negros", 19.99, new Uri("ms-appx:///Assets/Imagenes/zapatohombrenegro.jpg"), "Zapatos negros para traje de hombre, con tacon de 2cm y fabricados en cuero de la mejor calidad", 2, true, false, true));
            todos.Add(new Producto(22, "Tacones blancos", 19.99, new Uri("ms-appx:///Assets/Imagenes/zapatomujerblanco.jpg"), "Zapatos de tacon blancos para mujer con altura de 12cm", 2, false, true, false));
            todos.Add(new Producto(23, "Botas de plataforma negras", 19.99, new Uri("ms-appx:///Assets/Imagenes/zapatomujernegro.jpg"), "Botas con plataforma de 10cm para mujer, en color negro, fabricacion en terciopelo", 2, false, true, false));
            todos.Add(new Producto(24, "Tacon rosa", 19.99, new Uri("ms-appx:///Assets/Imagenes/zapatomujerrosa.jpg"), "Zapatos de tacón rosa fabricados en tejido sintetico, altura 18cm", 2, false, true, false));
            carrito = new ObservableCollection<Producto>();
        }

        public void eliminarCarrito(Producto datos)
        {
            for (int i = 0; i < carrito.Count; i++)
            {
                if (carrito[i].codigo == datos.codigo) carrito.RemoveAt(i);
            }
        }

        

        public List<Producto> getMasVendidos()
        {
            List<Producto> tmp = new List<Producto>();
            foreach (Producto p in todos) 
            {
                if (p.masvendido) tmp.Add(p);
            }
            return tmp;
        }

        public void anadirCarrito (Producto p)
        {
            bool encontrado = false;
            for (int i = 0; i < carrito.Count; i++)
            {
                if (p.codigo == carrito[i].codigo)
                {
                    encontrado = true;
                    carrito[i].cantidad += 1;
                }
            }
            if (!encontrado)
            {
                p.cantidad += 1;
                carrito.Add(p);
            }
        }

        public void quitarCarrito(Producto p)
        {
            
            for (int i = 0; i < carrito.Count; i++)
            {
                if (p.codigo == carrito[i].codigo)
                {
                    if (carrito[i].cantidad > 1)
                        carrito[i].cantidad -= 1;
                    else if (carrito[i].cantidad == 1)
                    {
                        carrito[i].cantidad = 0;
                        carrito.RemoveAt(i);
                    }
                }
            }
            
        }

        public void vaciarCarrito()
        {
            foreach (Producto p in carrito)
            {
                p.cantidad = 0;
            }
            carrito.Clear();
            
        }

        public List<Producto> getNuevacoleccion()
        {
            List<Producto> tmp = new List<Producto>();
            foreach (Producto p in todos)
            {
                if (p.nuevacoleccion) tmp.Add(p);
            }
            return tmp;
        }
        /// <summary>
        /// Obtiene los productos por categoria y genero (hmbre o mujer), hemos definido que siempre que entres en categorias tenga una u otra
        /// </summary>
        /// <param name="categoria">codigo de la categoria, si pones -1 sin filtro</param>
        /// <param name="hombre">0 para mujer, 1 para hombre, -1 sin filtro</param>
        /// <returns></returns>
        public List<Producto> getPorCategoriayGenero (int categoria, int hombre)
        {
            //las categorias empiezan a contar desde 0 y son camisas, pantalones, zapatos y complementos
            List<Producto> tmp = new List<Producto>();
            foreach (Producto p in todos)
            {
                if (hombre == -1)
                {
                    if (categoria == -1) tmp.Add(p);
                    else if (categoria == p.categoria) tmp.Add(p);
                } else if (hombre == 1)
                {
                    if (p.hombre && (categoria==-1 || categoria==p.categoria)) tmp.Add(p);
                }
                else if (hombre == 0)
                {
                    if (!p.hombre && (categoria == -1 || categoria == p.categoria)) tmp.Add(p);
                }
            }
            return tmp;
        }

        public List<Producto> getOutlet()
        {
            // aqui iria codigo para filtrar por outlet ya sea porque este en la base de datos o porque en nuestro objeto lo tengamos marcado
            //con una variable pero por falta de tiempo esta sin implementar asi que devuelve todos los productos
            return todos;
        }

        public List<Producto> getBusqueda (string busqueda)
        {
            List<Producto> tmp = new List<Producto>();
            foreach (Producto p in todos)
            {
                if (p.nombre.ToLower().Contains(busqueda.ToLower()) || p.descripcion.ToLower().Contains(busqueda.ToLower())) tmp.Add(p);
                //se podria mejorar para que esto produzca una filtracion por categoria o genero anadiendo que quite hombre o mujer del string de busqueda
                //y cogiendo la lista de hombre o mujer
            }
            return tmp;
        }

        public List<Producto> getFavoritos()
        {
            List<Producto> tmp = new List<Producto>();
            foreach (Producto p in todos)
            {
                if (p.favorito) tmp.Add(p);
            }
            return tmp;
        }

        public void setFavoritos(int codigo, bool estado)
        {
            foreach (Producto p in todos)
            {
                if (p.codigo == codigo) p.favorito = estado;
            }
        }
        /// <summary>
        /// Intercambia el estado de favorito de un producto
        /// </summary>
        /// <param name="codigo">codigo del producto a cambiar el favorito</param>
        public void toggleFavorito (int codigo)
        {
            foreach (Producto p in todos)
            {
                if (p.codigo == codigo) p.favorito = !p.favorito;
            }
        }
    }
}
