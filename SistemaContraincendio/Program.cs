using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Piso1;
using Piso2;
using Piso3;
using Piso4;
using Piso5;

namespace SistemaContraincendio
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Sistema de Monitoreo  - EL BOMBERITO";

          
            Console.WriteLine("                               LIMA PERU  - PERÚ 2026                                 ");
            Console.WriteLine("===================================================================================");
            Console.WriteLine("                             H O T E L  C I E L O                                ");
            Console.WriteLine($"                                  {DateTime.Now}                                      ");
            Console.WriteLine("===================================================================================");
            Console.ResetColor();
            Console.WriteLine();

          
            DibujarEdificio();

            MenuPrincipal();
        }

        static void DibujarEdificio()
        {
            Console.WriteLine("¿QUÉ PISO DEL EDIFICIO DESEA MONITOREAR?");
            Console.ResetColor();
            Console.WriteLine("       _______________________________________");
            Console.WriteLine("      //                                     /|");
            Console.WriteLine("     //                                     //|");
            Console.WriteLine("    //                                     // |");
            Console.WriteLine("   //_____________________________________//  |");
            Console.WriteLine("   ||'''''''''''''''''||'''''''''''''''''||   |");
            Console.WriteLine("   ||   ||   ||   ||  ||    ||   ||   || ||   |");
            Console.WriteLine("   ||   ||   ||   ||  PISO 5||   ||   || || / |");
            Console.WriteLine("   ||                 ||                 ||/  |");
            Console.WriteLine("   ||-----------------||-----------------||   |");
            Console.WriteLine("   ||                 ||                 ||   |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||  /|");
            Console.WriteLine("   ||   ||   ||      PISO 4    ||   ||   || / |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||/  |");
            Console.WriteLine("   ||-----------------||-----------------||   |");
            Console.WriteLine("   ||-----------------||-----------------||   |");
            Console.WriteLine("   ||                 ||                 ||   |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||  /|");
            Console.WriteLine("   ||   ||   ||      PISO 3    ||   ||   || / |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||/  |");
            Console.WriteLine("   ||-----------------||-----------------||   |");
            Console.WriteLine("   ||                 ||                 ||   |");
            Console.WriteLine("   ||   ||   ||      PISO 2    ||   ||   ||  /|");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   || / |");
            Console.WriteLine("   ||   ||   ||       ||       ||   ||   ||/  |");
            Console.WriteLine("   ||-----------------||-----------------||   |");
            Console.WriteLine("   ||                 ||                 ||   |");
            Console.WriteLine("   ||      _____    PISO 1    _____      ||   /");
            Console.WriteLine("   ||      |S E|      ||      |S E|      ||  /");
            Console.WriteLine("   ||      |?  |      ||      |?  |      || /");
            Console.WriteLine("   ||||||||||||||||||||||||||||||||||||||||/");
            Console.WriteLine("  _______________________________________\n");
        }

        static void MenuPrincipal()
        {
            Console.WriteLine("MENÚ DE MONITOREO");
            Console.WriteLine("1. Cuartos de Piso 1");
            Console.WriteLine("2. Cuartos de Piso 2");
            Console.WriteLine("3. Cuartos de Piso 3");
            Console.WriteLine("4. Cuartos de Piso 4");
            Console.WriteLine("5. Cuartos de Piso 5"); 
            Console.WriteLine("6. Salir");
            Console.Write("\nSeleccione una opción (1-6): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Clear(); 

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine(" Ingresando al Piso 1...");
                        new P1().Actualizar();
                        break;

                    case 2:                     
                        Console.WriteLine(" Ingresando al Piso 2...");                      
                        new P2().SegunPis();
                        break;

                    case 3:
                      
                        Console.WriteLine(" Ingresando al Piso 3...");                  
                        new P3();
                        new MapaPiso().MostrarSimulacion();
                        break;

                    case 4:                       
                        Console.WriteLine(" Ingresando al Piso 4...");                      
                        new P4().MostrarEstado();
                        break;

                    case 5:                      
                        Console.WriteLine(" Ingresando al Piso 5...");                     
                        new P5().MostrarEstado();
                        break;

                    case 6:                     
                        Console.WriteLine(" Saliendo del sistema ...");                    
                        return;

                    default:                       
                        Console.WriteLine(" Opción no válida. Intente de nuevo.");                    
                        break;
                }
            }
            else
            {               
                Console.WriteLine(" Entrada inválida. Debe ingresar un número del 1 al 6.");             
            }           
            Console.WriteLine("\nPresione cualquier tecla para volver al menú...");          
            Console.ReadKey();
            Console.Clear();
            Main(null); 
        }
    }
}


