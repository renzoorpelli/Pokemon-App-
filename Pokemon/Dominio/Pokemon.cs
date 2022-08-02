using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon
    {
        private int id;
        private int numero;
        private string nombre;
        private string descripcion;
        private string urlImagen;
        private Elemento tipo;
        private Elemento debilidad;
        private bool activo;

        public Pokemon()
        {

        }
        public Pokemon(int numero, string nombre, string descripcion, string urlImagen, bool activo)
        {
            this.numero = numero;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.urlImagen = urlImagen;
            this.activo = activo;
        }

        public int Id { get => this.id;  set => this.id = value;  }
        [DisplayName("Número")]
        public int Numero { get => this.numero; set => this.numero = value; }
        public string Nombre { get => this.nombre; set=> this.nombre = value; }
        [DisplayName("Descripción")]
        public string Descripcion { get=> this.descripcion; set=>this.descripcion = value; }
        public string UrlImagen { get=> this.urlImagen; set => this.urlImagen = value; }
        public Elemento Tipo { get => this.tipo; set=> this.tipo = value; }
        public Elemento Debilidad { get => this.debilidad; set=> this.debilidad =value; }
        public bool Activo { get => this.activo; set => this.activo = value; }


        public override string ToString()
        {
            return this.Nombre;
        }

    }
}
