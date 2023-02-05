using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    public class UI
    {
        Logica logica;
        string opcion;

        public UI()
        {
            this.logica = new Logica();
            opcion = "";
        }
        public void mantenimientoTiposMensajes()
        {
            string codigoInterno;
            string nombre;
            TipoMensaje tipoMensaje = null;
            try
            {
                Console.Clear();
                Console.WriteLine("MANTENIMIENTO DE TIPOS DE MENSAJE");
                Console.Write("Ingrese el codigo de tipo de mensaje: ");
                codigoInterno = Console.ReadLine().ToUpper();

                if (logica.buscarTiposMensaje(codigoInterno) == null)
                {
                    Console.Write("El codigo interno: " + codigoInterno + " esta disponible, ¿desea darlo de alta? S/N > ");
                    opcion = Console.ReadLine().ToUpper();

                    if (opcion == "S")
                    {
                        while (true)
                        {
                            Console.Write("Ingrese el nombre del nuevo tipo de mensaje: ");
                            nombre = Console.ReadLine();
                            tipoMensaje = new TipoMensaje(codigoInterno, nombre);
                            Console.WriteLine("Codigo interno: " + codigoInterno + " agregado.");
                            logica.DatosTiposMensaje.Add(tipoMensaje);
                            break;
                        }
                    }
                    else if (opcion == "N")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Elija una opcion correcta.");
                    }
                }
                else
                {
                    Console.Write("El codigo interno: " + codigoInterno + " esta en uso, ¿desea modificar el tipo de mensaje? S/N > ");
                    opcion = Console.ReadLine().ToUpper();

                    if (opcion == "S")
                    {
                        while (true)
                        {
                            Console.Write("Ingrese el nombre del tipo de mensaje a actualizar: ");
                            nombre = Console.ReadLine();
                            tipoMensaje = new TipoMensaje(codigoInterno, nombre);
                            Console.WriteLine("Codigo interno: " + codigoInterno + " actualizado.");
                            logica.DatosTiposMensaje.Add(tipoMensaje);
                            break;
                        }
                    }
                    else if (opcion == "N")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Elija una opcion correcta.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void mantenimientoUsuario()
        {
            string nombreUsuario;
            int cedula;
            string nombreCompleto;
            Usuario usuario = null;
            try
            {
                Console.Clear();
                Console.WriteLine("MANTENIMIENTO DE USUARIO");
                Console.Write("Ingrese el nombre de usuario: ");
                nombreUsuario = Console.ReadLine();

                if (logica.buscarUsuario(nombreUsuario) == null)
                {
                    Console.Write("El nombre de usuario: " + nombreUsuario + " esta disponible, ¿desea darlo de alta? S/N > ");
                    opcion = Console.ReadLine().ToUpper();

                    if (opcion == "S")
                    {
                        Console.Write("Ingrese un numero de cedula: ");
                        cedula = logica.esNumeroEntero(Console.ReadLine());

                        while (true)
                        {
                            if (cedula != 0)
                            {
                                Console.Write("Ingrese el nombre completo: ");
                                nombreCompleto = Console.ReadLine();
                                usuario = new Usuario(cedula, nombreCompleto, nombreUsuario);
                                Console.WriteLine("Usuario: " + nombreUsuario + " agregado.");
                                logica.DatosUsuarios.Add(usuario);
                                break;
                            }
                            else
                            {
                                Console.Write("Ingrese un numero de cedula valido: ");
                                cedula = logica.esNumeroEntero(Console.ReadLine());
                            }
                        }
                    }
                    else if (opcion == "N")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Elija una opcion correcta.");
                    }
                }
                else
                {
                    Console.Write("El nombre de usuario: " + nombreUsuario + " esta en uso, ¿desea modificar el usuario? S/N > ");
                    opcion = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (opcion == "S")
                        {
                            Console.Write("Ingrese un numero de cedula: ");
                            cedula = logica.esNumeroEntero(Console.ReadLine());

                            if (cedula != 0)
                            {
                                Console.Write("Ingrese el nombre completo: ");
                                nombreCompleto = Console.ReadLine();
                                //Console.Write("Ingrese el nombre de usuario: ");
                                //nombreUsuario = Console.ReadLine();
                                usuario = new Usuario(cedula, nombreCompleto, nombreUsuario);
                                logica.DatosUsuarios.Add(usuario);
                                Console.WriteLine("Usuario: " + nombreUsuario + " modificado.");
                                break;
                            }
                            else
                            {
                                Console.Write("Ingrese un numero de cedula valido: ");
                                cedula = logica.esNumeroEntero(Console.ReadLine());
                            }
                        }
                        else if (opcion == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Elija una opcion correcta.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void agregarMensajePrivado()
        {
            Privado mensaje = null;
            Usuario usuarioEnvia = null;
            Usuario usuarioRecibe = null;
            string nombreUsuarioEnvia = "";
            string nombreUsuarioRecibe = "";
            DateTime fechaHoraGenerado = DateTime.Now;
            string asunto;
            string texto;

            try
            {
                Console.Clear();
                Console.WriteLine("AGREGAR MENSAJE PRIVADO");
                Console.Write("Ingrese el nombre de usuario de quien envia el mensaje: ");
                nombreUsuarioEnvia = Console.ReadLine();
                usuarioEnvia = logica.buscarUsuario(nombreUsuarioEnvia);

                while (true)
                {
                    if (usuarioEnvia != null)
                    {

                        Console.Write("Usuario: " + nombreUsuarioEnvia + " encontrado, ingrese el nombre de usuario de quien recibe el mensaje: ");
                        nombreUsuarioRecibe = Console.ReadLine();
                        usuarioRecibe = logica.buscarUsuario(nombreUsuarioRecibe);

                        if (usuarioRecibe != null)
                        {
                            #region
                            fechaHoraGenerado = DateTime.Now;
                            Console.Write("Ingrese el asunto (se tomaran en cuenta solo los primeros 50 caracteres): ");
                            asunto = Console.ReadLine();
                            Console.Write("Ingrese el texto a enviar (se tomaran en cuenta solo los primeros 200 caracteres): ");
                            texto = Console.ReadLine();

                            if (asunto.Length > 50)
                            {
                                asunto = asunto.Substring(0, 50);
                            }

                            if (texto.Length > 200)
                            {
                                texto = texto.Substring(0, 200);
                            }

                            mensaje = new Privado(fechaHoraGenerado.AddDays(2.0), logica.generarNumeroInternoMensajesPrivado(), fechaHoraGenerado, asunto, texto, usuarioEnvia, usuarioRecibe);

                            logica.DatosMensajesPrivado.Add(mensaje);
                            Console.WriteLine("Mensaje privado enviado");
                            break;
                            #endregion
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el usuario: " + nombreUsuarioRecibe + ". ");
                            nombreUsuarioRecibe = "";
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontro el usuario: " + nombreUsuarioEnvia + ". ");
                        Console.Write("Ingrese el nombre de usuario de quien envia el mensaje: ");
                        nombreUsuarioEnvia = Console.ReadLine();
                        usuarioEnvia = logica.buscarUsuario(nombreUsuarioEnvia);
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void agregarMensajeComun()
        {
            {
                Comun mensaje = null;
                Usuario usuarioEnvia = null;
                Usuario usuarioRecibe = null;
                TipoMensaje tipoMensaje = null;
                DateTime fechaHoraGenerado;
                string nombreUsuarioEnvia = "";
                string nombreUsuarioRecibe = "";
                string asunto;
                string texto;
                string codigoTipoMensaje = "";

                try
                {
                    Console.Clear();
                    Console.WriteLine("AGREGAR MENSAJE COMUN");
                    Console.Write("Ingrese el nombre de usuario de quien envia el mensaje: ");
                    nombreUsuarioEnvia = Console.ReadLine();
                    usuarioEnvia = logica.buscarUsuario(nombreUsuarioEnvia);

                    while (true)
                    {
                        if (usuarioEnvia != null)
                        {
                            Console.Write("Usuario: " + nombreUsuarioEnvia + " encontrado, ingrese el nombre de usuario de quien recibe el mensaje: ");
                            nombreUsuarioRecibe = Console.ReadLine();
                            usuarioRecibe = logica.buscarUsuario(nombreUsuarioRecibe);

                            if (usuarioRecibe != null)
                            {
                                Console.Write("Ingrese el codigo del tipo de mensaje: ");
                                codigoTipoMensaje = Console.ReadLine();
                                tipoMensaje = logica.buscarTiposMensaje(codigoTipoMensaje);
                                if (tipoMensaje != null)
                                {
                                    fechaHoraGenerado = DateTime.Now;
                                    Console.Write("Ingrese el asunto (se tomaran en cuenta solo los primeros 50 caracteres): ");
                                    asunto = Console.ReadLine();
                                    Console.Write("Ingrese el texto a enviar (se tomaran en cuenta solo los primeros 200 caracteres): ");
                                    texto = Console.ReadLine();

                                    if (asunto.Length > 50)
                                    {
                                        asunto = asunto.Substring(0, 50);
                                    }

                                    if (texto.Length > 200)
                                    {
                                        texto = texto.Substring(0, 200);
                                    }

                                    mensaje = new Comun(tipoMensaje, logica.generarNumeroInternoMensajesComun(), fechaHoraGenerado, asunto, texto, usuarioEnvia, usuarioRecibe);

                                    logica.DatosMensajesComun.Add(mensaje);
                                    Console.WriteLine("Mensaje comun enviado");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("No se ha encontrado el tipo de mensaje: " + codigoTipoMensaje);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se encontro el usuario: " + nombreUsuarioRecibe + ". ");
                                nombreUsuarioRecibe = "";
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el usuario: " + nombreUsuarioEnvia + ". ");
                            Console.Write("Ingrese el nombre de usuario de quien envia el mensaje: ");
                            nombreUsuarioEnvia = Console.ReadLine();
                            usuarioEnvia = logica.buscarUsuario(nombreUsuarioEnvia);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
        public void listadoMensajesCompleto()
        {
            try
            {
                Console.WriteLine("LISTADOS COMPLETO DE MENSAJES");
                if (logica.listadoMensajesCompletos().Count == 0)
                {
                    Console.WriteLine("No se han encontrado mensajes.");
                }
                else
                {
                    for (int i = 0; i < logica.listadoMensajesCompletos().Count; i++)
                    {
                        Console.WriteLine(logica.listadoMensajesCompletos()[i]);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void listadoMensajesUsuarioEnviaRecibe()
        {
            string nombreUsuario;
            Usuario usuario = null;
            List<Mensaje> lista = null;
            try
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE MENSAJES POR USUARIO ENVIA/RECIBE");
                Console.WriteLine("Seleccione lo que desea mostrar");
                Console.WriteLine("1 - Mensajes enviados.         ");
                Console.WriteLine("2 - Mensajes recibidos.        ");

                try
                {
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Ingrese el nombre de usuario sobre el que desea informacion: ");
                    nombreUsuario = Console.ReadLine();
                    usuario = logica.buscarUsuario(nombreUsuario);
                    if (usuario != null)
                    {
                        #region SWITCH AQUI
                        switch (opcion)
                        {
                            case 1:
                                lista = logica.listadoMensajesUsuarioEnviaRecibe(1, usuario);
                                if (lista.Count == 0)
                                {
                                    Console.WriteLine("No se han encontrado mensajes enviados para el usuario " + usuario.NombreUsuario);
                                }
                                else
                                {
                                    for (int i = 0; i < lista.Count; i++)
                                    {
                                        Console.WriteLine(lista[i]);
                                    }
                                }
                                Console.WriteLine("Presione ENTER para continuar");
                                Console.ReadLine();
                                break;

                            case 2:
                                lista = logica.listadoMensajesUsuarioEnviaRecibe(2, usuario);
                                if (lista.Count == 0)
                                {
                                    Console.WriteLine("No se han encontrado mensajes recibidos para el usuario " + usuario.NombreUsuario);
                                }
                                else
                                {
                                    for (int i = 0; i < lista.Count; i++)
                                    {
                                        Console.WriteLine(lista[i]);
                                    }
                                }
                                Console.WriteLine("Presione ENTER para continuar");
                                Console.ReadLine();
                                break;

                            default:
                                Console.WriteLine("Selecciona una opcion entre 1 y 2");
                                Console.WriteLine("\n\nPresione ENTER para continuar");
                                Console.ReadLine();

                                break;
                        }
                        #endregion
                    }
                    else
                    {
                        Console.WriteLine("No se han encontrado mensajes. el usuario: " + nombreUsuario + " no esta registrado.");
                        Console.WriteLine("Presione ENTER para continuar");
                        Console.ReadLine();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void listadoMensajesComunesPorTipo()
        {
            string codigoTipoMensaje = "";
            TipoMensaje tipoMensaje = null;
            try
            {
                Console.Clear();
                Console.WriteLine("LISTADO DE MENSAJES COMUNES POR TIPO");
                Console.WriteLine("Ingrese el codigo de un tipo de mensaje: ");
                codigoTipoMensaje = Console.ReadLine();
                tipoMensaje = logica.buscarTiposMensaje(codigoTipoMensaje);
                if (tipoMensaje != null)
                {
                    for (int i = 0; i < logica.listadoMensajesComunesPorTipo(tipoMensaje).Count; i++)
                    {
                        Console.WriteLine(logica.listadoMensajesComunesPorTipo(tipoMensaje)[i]);
                    }
                }
                else
                {
                    Console.WriteLine("Mensajes con este codigo: " + codigoTipoMensaje + " no encontrados. El codigo: " + codigoTipoMensaje + " no existe.");
                }
                Console.WriteLine("Presione ENTER para continuar.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void imprimirIngresosAutomaticos()
        {
            try
            {
                Console.WriteLine("Usarios almacenados actualmente.");
                for (int i = 0; i < logica.DatosUsuarios.Count; i++)
                {
                    Console.WriteLine(logica.DatosUsuarios[i]);
                }
                Console.WriteLine("\nTipos de mensaje almacenados actualmente.");
                for (int i = 0; i < logica.DatosTiposMensaje.Count; i++)
                {
                    Console.WriteLine(logica.DatosTiposMensaje[i]);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
