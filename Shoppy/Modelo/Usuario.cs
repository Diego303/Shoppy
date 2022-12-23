using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoppy.Modelo
{
    class Usuario
    {
        public Usuario(int codigo, string nombre, string apellidos, string direccion, string telefono, string correo, string contrasena)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo = correo;
            this.contrasena = contrasena;
        }

        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
    }
}
