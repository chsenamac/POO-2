using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    public class Comun:Mensaje
    {
        private TipoMensaje tipoMensaje;

        public Comun(TipoMensaje tipoMensaje, int numeroInterno, DateTime fechaHoraGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
            : base(numeroInterno, fechaHoraGenerado, asunto, texto, usuarioEnvia, usuarioRecibe)
        {
            this.tipoMensaje = tipoMensaje;
        }

        public TipoMensaje TipoDeMensaje
        {
            get { return this.tipoMensaje; }
            set { this.tipoMensaje = value; }
        }

        public override string ToString()
        {
            return " Tipo de mensaje: " + this.tipoMensaje + " - " + base.ToString();
        }
    }
}
