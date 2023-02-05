using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    public class Usuario
    {
        private int cedula;
        private string nombreCompleto;
        private string nombreUsuario;

        public Usuario(int cedula, string nombreCompleto, string nombreUsuario)
        {
            this.cedula = cedula;
            this.nombreCompleto = nombreCompleto;
            this.nombreUsuario = nombreUsuario;
        }

        public int Cedula
        {
            get { return this.cedula; }
            set { this.cedula = value; }
        }

        public string NombreCompleto
        {
            get { return this.nombreCompleto; }
            set { this.nombreCompleto= value; }
        }
        
        public string NombreUsuario
        {
            get { return this.nombreUsuario; }
            set { this.nombreUsuario= value; }
        }

        public override string ToString()
        {
            return "Cedula: " + this.cedula + " - Nombre usuario: " + this.nombreUsuario + " - Nombre completo: " + this.nombreCompleto ;
        }
    }
}
