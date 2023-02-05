using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    public class Privado : Mensaje
    {
        private DateTime fechaCaducidad;

        public Privado(DateTime fechaCaducidad, int numeroInterno, DateTime fechaHoraGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
            : base(numeroInterno, fechaHoraGenerado, asunto, texto, usuarioEnvia, usuarioRecibe)
        {
            this.fechaCaducidad = fechaCaducidad;
        }

        public DateTime FechaCaducidad
        {
            get { return this.fechaCaducidad; }
            set { this.fechaCaducidad = value; }
        }

        public override string ToString()
        {
            return base.ToString() + " - Fecha de caducidad: " + this.fechaCaducidad;
        }
    }
}
