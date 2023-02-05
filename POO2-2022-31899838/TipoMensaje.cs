using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    public class TipoMensaje
    {
        private string codigoInterno;
        private string nombre;

        public TipoMensaje(string codigoInterno, string nombre)
        {
            this.codigoInterno = codigoInterno;
            this.nombre = nombre;
        }

        public string CodigoInterno
        {
            get { return this.codigoInterno; }
            set { this.codigoInterno = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public override string ToString()
        {
            return "Codigo interno: " + this.codigoInterno + " - Nombre: " + this.nombre;
        }
    }
}
