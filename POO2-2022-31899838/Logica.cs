using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    public class Logica
    {
        private List<Usuario> datosUsuarios;
        private List<TipoMensaje> datosTipoMensaje;
        private List<Privado> datosMensajesPrivado;
        private List<Comun> datosMensajesComun;

        public Logica()
        {
            datosUsuarios = agregarUsuariosAlSistemaEnFormaAutomatica();
            datosTipoMensaje = AgregarTiposDeMensajeAlSistemaEnFormaAutomatica();
            datosMensajesPrivado = new List<Privado>();
            datosMensajesComun = new List<Comun>();
        }

        public List<Usuario> DatosUsuarios
        {
            get { return this.datosUsuarios; }
            set { datosUsuarios = value; }
        }

        public List<TipoMensaje> DatosTiposMensaje
        {
            get { return this.datosTipoMensaje; }
            set { datosTipoMensaje = value; }
        }

        public List<Privado> DatosMensajesPrivado
        {
            get { return datosMensajesPrivado; }
            set { datosMensajesPrivado = value; }
        }

        public List<Comun> DatosMensajesComun
        {
            get { return datosMensajesComun; }
            set { datosMensajesComun = value; }
        }

        public TipoMensaje buscarTiposMensaje(string codigoInterno)
        {
            TipoMensaje res = null;
            try
            {
                for (int i = 0; i < datosTipoMensaje.Count; i++)
                {
                    if (datosTipoMensaje[i].CodigoInterno == codigoInterno)
                    {
                        res = datosTipoMensaje[i];
                    }
                }
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Usuario buscarUsuario(String nombreUsuario)
        {
            Usuario res = null;
            try
            {
                for (int i = 0; i < datosUsuarios.Count; i++)
                {
                    if (datosUsuarios[i].NombreUsuario == nombreUsuario)
                    {
                        res = datosUsuarios[i];
                    }
                }

                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int agregarMensajePrivado(DateTime fechaGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
        {
            Privado mensajePrivado;
            DateTime fechaCaducidad = DateTime.Now.AddDays(2.0);

            try
            {
                mensajePrivado = new Privado(fechaCaducidad, generarNumeroInternoMensajesPrivado(), fechaGenerado, asunto, texto, usuarioEnvia, usuarioRecibe);
                return 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int agregarMensajeComun(TipoMensaje tipoMensaje, DateTime fechaGenerado, string asunto, string texto, Usuario usuarioEnvia, Usuario usuarioRecibe)
        {
            Comun mensajeComun;
            try
            {
                mensajeComun = new Comun(tipoMensaje, generarNumeroInternoMensajesComun(), fechaGenerado, asunto, texto, usuarioEnvia, usuarioRecibe);
                return 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<string> listadoMensajesCompletos()
        {
            try
            {
                List<string> resultado = new List<string>();
                string cadenaResultante = "";
                List<Mensaje> lista = new List<Mensaje>();

                for (int i = 0; i < datosMensajesComun.Count; i++)
                {
                    lista.Add(datosMensajesComun[i]);
                }

                for (int i = 0; i < datosMensajesPrivado.Count; i++)
                {
                    if (datosMensajesPrivado[i].FechaCaducidad >= DateTime.Now.AddDays(-2.0))
                    {
                        lista.Add(datosMensajesPrivado[i]);
                    }
                }

                ordenadoRapidoMensaje(lista, 0, lista.Count - 1);

                for (int i = 0; i < lista.Count; i++)
                {
                    cadenaResultante = "Tipo de mensaje: " + lista[i].GetType() + ", fecha y hora: " + lista[i].FechaHoraGenerado + ", usuario que envia: " + lista[i].UsuarioEnvia.NombreCompleto + ", usuario que recibe: " + lista[i].UsuarioRecibe.NombreCompleto + ". ";
                    resultado.Add(cadenaResultante);
                }
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Mensaje> listadoMensajesUsuarioEnviaRecibe(int opcion, Usuario usuario)
        {
            try
            {
                List<Mensaje> lista = new List<Mensaje>();

                if (opcion == 1)
                {
                    for (int i = 0; i < datosMensajesComun.Count; i++)
                    {
                        if (datosMensajesComun[i].UsuarioEnvia.NombreUsuario == usuario.NombreUsuario)
                        {
                            lista.Add(datosMensajesComun[i]);
                        }
                    }
                    for (int i = 0; i < datosMensajesPrivado.Count; i++)
                    {
                        if (datosMensajesPrivado[i].UsuarioEnvia.NombreUsuario == usuario.NombreUsuario)
                        {
                            lista.Add(datosMensajesPrivado[i]);
                        }
                    }
                }
                else if (opcion == 2)
                {
                    for (int i = 0; i < datosMensajesComun.Count; i++)
                    {
                        if (datosMensajesComun[i].UsuarioRecibe.NombreUsuario == usuario.NombreUsuario)
                        {
                            lista.Add(datosMensajesComun[i]);
                        }
                    }
                    for (int i = 0; i < datosMensajesPrivado.Count; i++)
                    {
                        if (datosMensajesPrivado[i].UsuarioRecibe.NombreUsuario == usuario.NombreUsuario)
                        {
                            lista.Add(datosMensajesPrivado[i]);
                        }
                    }
                }

                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Comun> listadoMensajesComunesPorTipo(TipoMensaje tipoMensaje)
        {
            try
            {
                List<Comun> lista = new List<Comun>();

                for (int i = 0; i < datosMensajesComun.Count; i++)
                {
                    if (datosMensajesComun[i].TipoDeMensaje.CodigoInterno == tipoMensaje.CodigoInterno)
                    {
                        lista.Add(datosMensajesComun[i]);
                    }
                }

                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Usuario> agregarUsuariosAlSistemaEnFormaAutomatica()
        {
            try
            {
                List<Usuario> lista = new List<Usuario>();

                lista.Add(new Usuario(31899838, "Christiams Sena", "@csenamac"));
                lista.Add(new Usuario(55597016, "Son Goku", "@kakaroto"));
                lista.Add(new Usuario(49855585, "María Eugenia Vaz Ferreira", "@maruvaz"));
                lista.Add(new Usuario(51586140, "Cristina Peri Rossi", "@crisperi"));

                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoMensaje> AgregarTiposDeMensajeAlSistemaEnFormaAutomatica()
        {
            try
            {
                List<TipoMensaje> lista = new List<TipoMensaje>();

                lista.Add(new TipoMensaje("URG", "Urgente"));
                lista.Add(new TipoMensaje("ITC", "Invitacion"));
                lista.Add(new TipoMensaje("EVT", "Evento"));

                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int generarNumeroInternoMensajesComun()
        {
            int res = 0;
            int numeroGenerado = datosMensajesComun.Count;

            try
            {
                for (int i = 0; i < datosMensajesComun.Count; i++)
                {
                    if (datosMensajesComun[i].NumeroInterno != numeroGenerado)
                    {
                        res = numeroGenerado;
                    }
                }

                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public int generarNumeroInternoMensajesPrivado()
        {
            int res = 0;
            int numeroGenerado = datosMensajesPrivado.Count;

            try
            {
                for (int i = 0; i < datosMensajesPrivado.Count; i++)
                {
                    if (datosMensajesComun[i].NumeroInterno != numeroGenerado)
                    {
                        res = numeroGenerado;
                    }
                }

                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private void ordenadoRapidoMensaje(List<Mensaje> datosMensajes, int cotaInf, int cotaSup)
        {
            try
            {
                if (cotaInf < cotaSup)
                {
                    int indPart = particionMensaje(datosMensajes, cotaInf, cotaSup);
                    ordenadoRapidoMensaje(datosMensajes, cotaInf, indPart);
                    ordenadoRapidoMensaje(datosMensajes, indPart + 1, cotaSup);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private int particionMensaje(List<Mensaje> datosMensajes, int cotaInf, int cotaSup)
        {
            Mensaje pivot = datosMensajes[cotaInf];

            try
            {
                while (true)
                {
                    while (datosMensajes[cotaInf].FechaHoraGenerado < pivot.FechaHoraGenerado)
                    {
                        cotaInf++;
                    }

                    while (datosMensajes[cotaSup].FechaHoraGenerado > pivot.FechaHoraGenerado)
                    {
                        cotaSup--;
                    }
                    if (cotaInf >= cotaSup)
                    {
                        return cotaSup;
                    }
                    else
                    {
                        Mensaje temporal = datosMensajes[cotaInf];
                        datosMensajes[cotaInf] = datosMensajes[cotaSup];
                        datosMensajes[cotaSup] = temporal;
                        cotaSup--; cotaInf++;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Usuario modificarUsuario(Usuario usuario)
        {
            int cedula;
            string nombreCompleto;
            string nombreUsuario;

            try
            {
                Console.WriteLine("MODIFICAR USUARIO: " + usuario.NombreUsuario);
                Console.WriteLine("Ingrese la cedula: ");
                cedula = esNumeroEntero(Console.ReadLine());
                while (true)
                {
                    if (cedula != 0)
                    {
                        Console.WriteLine("Ingrese el nombre completo: ");
                        nombreCompleto = Console.ReadLine();
                        Console.WriteLine("Ingrese el nombre de usuario: ");
                        nombreUsuario = Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una cedula valida: ");
                        cedula = esNumeroEntero(Console.ReadLine());
                    }
                }

                usuario.Cedula = cedula;
                usuario.NombreCompleto = nombreCompleto;
                usuario.NombreUsuario = nombreUsuario;

                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int eliminarUsuario(Usuario usuario)
        {
            int res = 0;

            try
            {
                for (int i = 0; i < datosMensajesComun.Count; i++)
                {
                    if (datosMensajesComun[i].UsuarioEnvia.NombreUsuario == usuario.NombreUsuario || datosMensajesPrivado[i].UsuarioRecibe.NombreUsuario == usuario.NombreUsuario)
                    {
                        res = 1;
                        break;
                    }
                }

                for (int i = 0; i < datosMensajesPrivado.Count; i++)
                {
                    if (datosMensajesPrivado[i].UsuarioEnvia.NombreUsuario == usuario.NombreUsuario || datosMensajesPrivado[i].UsuarioRecibe.NombreUsuario == usuario.NombreUsuario)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    for (int i = 0; i < datosUsuarios.Count; i++)
                    {
                        if (datosUsuarios[i].NombreUsuario == usuario.NombreUsuario)
                        {
                            datosUsuarios.RemoveAt(i);
                        }
                    }
                }

                return res;

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int altaUsuario(Usuario usuario)
        {
            try
            {
                datosUsuarios.Add(usuario);
                return 1;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoMensaje modificarTipoMensaje(TipoMensaje tipoMensaje)
        {
            string codigoInterno;
            string nombre;

            try
            {
                Console.WriteLine("MODIFICAR TIPO DE MENSAJE: " + tipoMensaje);
                Console.WriteLine("Ingrese el  codigo interno: ");
                codigoInterno = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre completo: ");
                nombre = Console.ReadLine();

                tipoMensaje.CodigoInterno = codigoInterno;
                tipoMensaje.Nombre = nombre;

                return tipoMensaje;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int eliminarTipoMensaje(TipoMensaje tipoMensaje)
        {
            int res = 0;

            try
            {
                for (int i = 0; i < datosMensajesComun.Count; i++)
                {
                    if (datosMensajesComun[i].TipoDeMensaje.CodigoInterno == tipoMensaje.CodigoInterno)
                    {
                        res = 1;
                        break;
                    }
                }

                if (res == 0)
                {
                    for (int i = 0; i < datosMensajesComun.Count; i++)
                    {
                        if (datosMensajesComun[i].TipoDeMensaje.CodigoInterno == tipoMensaje.CodigoInterno)
                        {
                            datosMensajesComun.RemoveAt(i);
                        }
                    }
                }

                return res;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int altaTipoMensaje(TipoMensaje tipoMensaje)
        {
            try
            {
                datosTipoMensaje.Add(tipoMensaje);
                return 1;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public int esNumeroEntero(string numeroIngresado)
        {
            int res = 0;
            bool prueba = false;

            for (int i = 0; i < numeroIngresado.Length; i++)
            {
                prueba = char.IsNumber(numeroIngresado[i]);
                if (prueba == false)
                {
                    break;
                }
            }

            if (prueba)
            {
                res = Convert.ToInt32(numeroIngresado);
            }

            return res;
        }
    }
}
