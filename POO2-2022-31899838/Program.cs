using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POO2_2022_31899838
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            Logica logica = new Logica();
            int opcion = 0;
            ConsoleKey tecla = new ConsoleKey();
            bool salirLoop = false;
            bool salirOpciones = false;

            try
            {
                while (!salirLoop)
                {
                    Console.Clear();
                    Console.WriteLine("POO2_2022_31899838-Christiams Sena\n");
                    ui.imprimirIngresosAutomaticos();
                    Console.WriteLine("\n                  MENU PRINCIPAL                   ");
                    Console.WriteLine("1 - Mantenimiento de tipos de mensaje              ");
                    Console.WriteLine("2 - Mantenimiento de usuarios                      ");
                    Console.WriteLine("3 - Agregar mensaje privado                        ");
                    Console.WriteLine("4 - Agregar mensaje comun                          ");
                    Console.WriteLine("5 - Listado completo de mensajes                   ");
                    Console.WriteLine("6 - Listado de mensajes por usuario (envia/recibe) ");
                    Console.WriteLine("7 - Listado de mensajes comunes por tipo de mensaje");
                    Console.Write("8 - Salida                                            > ");
                    opcion = logica.esNumeroEntero(Console.ReadLine());
                    salirLoop = false;
                    salirOpciones = false;

                    switch (opcion)
                    {
                        case 1:
                            try
                            {
                                while (!salirOpciones)
                                {
                                    ui.mantenimientoTiposMensajes();
                                    Console.Write("¿Desea seguir realizando mantenimiento a los tipos de mensaje? \nPresione ENTER para hacerlo o cualquier otra para cancelar. ");
                                    tecla = Console.ReadKey().Key;
                                    if (tecla != ConsoleKey.Enter)
                                    {
                                        salirOpciones = true;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 2:
                            try
                            {
                                while (!salirOpciones)
                                {
                                    ui.mantenimientoUsuario();
                                    Console.Write("¿Desea seguir realizando mantenimiento a los usuarios? \nPresione ENTER para hacerlo o cualquier otra para cancelar. ");
                                    tecla = Console.ReadKey().Key;
                                    if (tecla != ConsoleKey.Enter)
                                    {
                                        salirOpciones = true;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 3:
                            try
                            {
                                while (!salirOpciones)
                                {
                                    ui.agregarMensajePrivado();
                                    Console.Write("¿Desea seguir enviando mensajes privados? \nPresione ENTER para hacerlo o cualquier otra para cancelar. ");
                                    tecla = Console.ReadKey().Key;
                                    if (tecla != ConsoleKey.Enter)
                                    {
                                        salirOpciones = true;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 4:
                            try
                            {
                                while (!salirOpciones)
                                {
                                    ui.agregarMensajeComun();
                                    Console.Write("¿Desea seguir enviando mensajes comunes? \nPresione ENTER para hacerlo o cualquier otra para cancelar. ");
                                    tecla = Console.ReadKey().Key;
                                    if (tecla != ConsoleKey.Enter)
                                    {
                                        salirOpciones = true;
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 5:
                            try
                            {
                                ui.listadoMensajesCompleto();
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 6:
                            try
                            {
                                ui.listadoMensajesUsuarioEnviaRecibe();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 7:
                            try
                            {
                                ui.listadoMensajesComunesPorTipo();

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 8:
                            try
                            {
                                Console.WriteLine("\nPresione ENTER para salir de la aplicacion o cualquier otra tecla para continuar");
                                tecla = Console.ReadKey().Key;
                                if (tecla == ConsoleKey.Enter)
                                {
                                    salirOpciones = true;
                                    salirLoop = true;
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 0:
                            try
                            {
                                Console.WriteLine("Opcion incorrecta - elija un numero entre 1 y 8, gracias.");
                                Console.WriteLine("Presione ENTER para continuar");
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        default:
                            try
                            {
                                Console.WriteLine("DEFAULT: Opcion incorrecta - elija un numero entre 1 y 8, gracias.");
                                Console.WriteLine("Presione ENTER para continuar");
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Console.ReadLine();
        }
    }
}
