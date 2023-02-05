using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    public class Mensaje
    {
        private int numeroInterno;
        private DateTime fechaHoraGenerado;
        private string asunto;
        private string texto;
        private Usuario usuarioEnvia;
        private Usuario usuarioRecibe;

        public Mensaje(int numeroInterno, DateTime fechaHoraGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
        {
            this.numeroInterno = numeroInterno;
            this.fechaHoraGenerado = fechaHoraGenerado;
            this.asunto = asunto;
            this.texto = texto;
            this.usuarioEnvia = usuarioEnvia;
            this.usuarioRecibe = usuarioRecibe;
        }

        public int NumeroInterno
        {
            get { return this.numeroInterno; }
            set { numeroInterno = value; }
        }

        public DateTime FechaHoraGenerado
        {
            get { return this.fechaHoraGenerado; }
            set { this.fechaHoraGenerado = value; }
        }

        public string Asunto
        {
            get { return this.asunto; }
            set { this.asunto = value; }
        }

        public string Texto
        {
            get { return this.texto; }
            set { this.texto = value; }
        }

        public Usuario UsuarioEnvia
        {
            get { return this.usuarioEnvia; }
            set { this.usuarioEnvia = value; }
        }

        public Usuario UsuarioRecibe
        {
            get { return this.usuarioRecibe; }
            set { this.usuarioRecibe = value; }
        }

        public override string ToString()
        {
            return "Numero interno: " + this.numeroInterno + "\nFecha y hora de generado: " + this.fechaHoraGenerado + "\nAsunto: " + this.asunto + "\nTexto: " + this.texto + "\nUsuario que envia: " + this.usuarioEnvia.ToString() + "\nUsuario que recibe: " + this.usuarioRecibe.ToString()+"\n";
        }
    }
}
