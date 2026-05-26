using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Piso2
{
    public class P2
    {
        public void SegunPis()
        {
            Console.Clear();
            Random Temp = new Random();
            int temperatura = 25;
            string luzestroboscopica;
            int humo;
            
        
            Console.WriteLine("                                                  SEGUNDO PISO                               ");
            Console.WriteLine("                      ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            Console.WriteLine("                      █                                               ║ ║E║S║C║A║L║E║R║A║S║ █");
            Console.WriteLine("                      █   |-----|         |¯¯¯¯|        |¯¯¯¯|        ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ ║ █");
            Console.WriteLine("                      █   |-----|       | |  - |      | |  - |        ═════════════════════ █");
            Console.WriteLine("                      █   |-----|         |____|        |____|                              █");
            Console.WriteLine("                      █   |-----|                                                           █");
            Console.WriteLine("                      █                                                                     █");
            Console.WriteLine("                      █            C O C I N A                                              █");
            Console.WriteLine("                      █                                                                     █");
            Console.WriteLine("                      █                                                                     █");
            Console.WriteLine("                      █   |-----│         │¯¯¯¯│        |¯¯¯¯|          |¯¯¯¯|             .█");
            Console.WriteLine("                      █   |-----│       | │  - │      | |  - |        | |  - |          .   █");
            Console.WriteLine("                      █   |-----│         │____│        |____|          |____|        .     █");
            Console.WriteLine("                      █   |-----│                                                    .      █");
            Console.WriteLine("                      █                                                              ═══════█");
            Console.WriteLine("                      █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
            Console.WriteLine("                      █    _            ---   ---   ---  ---                         ═══════█");
            Console.WriteLine("                      █   | |        /¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯\\                 .        █");
            Console.WriteLine("                      █   | |       |                             |                  .      █");
            Console.WriteLine("                      █   | |     | |                             | |                  .    █");
            Console.WriteLine("                      █   | |     | |                             | |                     . █");
            Console.WriteLine("                      █   | |       |                             |                         █");
            Console.WriteLine("                      █   ||        \\                           /                          █");
            Console.WriteLine("                      █                --------------------------                           █");
            Console.WriteLine("                      █                                                                     █");
            Console.WriteLine("                      █ .      ║¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯|              █");
            Console.WriteLine("                      █    .   ║   ╔══╗        ╔══╗        ╔══╗        ╔══╗  |              █");
            Console.WriteLine("                      █       .║  |║  ║|      |║  ║|      |║  ║|      |║  ║| |              █");
            Console.WriteLine("                      █            ╚══╝        ╚══╝        ╚══╝        ╚══╝  |              █");
            Console.WriteLine("                      █                                                      |              █");
            Console.WriteLine("                      █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
            int comando;
            do
            {
                if (Console.WindowHeight < 33)
                {
                    Console.WindowHeight = 40;
                }
                Console.SetCursorPosition(2, 32);
                Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
                Console.Write("Comando ■ 1.INICIAR 2.[D]Refrigerar 3.Salir]:");

                if (!int.TryParse(Console.ReadLine(), out comando))
                {
                    comando = 0;
                }

                if (comando == 2)
                {
                    do
                    {
                        temperatura -= Temp.Next(1, 5);
                        if (temperatura < 25) temperatura = 25;
                        if (temperatura > 100) temperatura = 100;

                        MostrarEstado(temperatura, out humo, out luzestroboscopica);
                        Thread.Sleep(500);

                    } while (temperatura > 40);
                }
                else if (comando == 1)
                {
                    Console.SetCursorPosition(2, 33);
                    Console.WriteLine("Presiona [D] para detener...          ");
                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.D)
                                break;
                        }
                        int cambio = Temp.Next(-2, 7);
                        temperatura += cambio;
                        if (temperatura < 25) temperatura = 25;
                        if (temperatura > 100) temperatura = 100;

                        MostrarEstado(temperatura, out humo, out luzestroboscopica);
                        Thread.Sleep(500);
                    }
                }

            } while (comando != 3);
            Console.WriteLine("\nSaliendo");
            Console.ReadKey();
        }
        void MostrarEstado(int temperatura, out int humo, out string luzestroboscopica)
        {
            Random h = new Random();
            if (temperatura <= 40)        
            {
                humo = h.Next(0, 10);
                luzestroboscopica = "Normalidad";
            }
            else if (temperatura < 70)     
            {
                humo = h.Next(20, 30);
                luzestroboscopica = "Alerta";
            }
            else if (temperatura < 90)      
            {
                humo = h.Next(30, 40);
                luzestroboscopica = "Peligro";
                try
                {
                    SoundPlayer sp = new SoundPlayer("Alarmas/sonidoLEVE.wav");
                    sp.Play();
                }
                catch { }
            }
            else                            
            {
                humo = h.Next(40, 50);
                luzestroboscopica = "Evacue";
                try
                {
                    SoundPlayer sp = new SoundPlayer("Alarmas/sonidoPELIGRO.wav");
                    sp.Play();
                }
                catch { }
            }

            Console.SetCursorPosition(26, 4);
            Console.Write($"Temperatura: {temperatura} °C       ");
            Console.SetCursorPosition(62, 4);
            Console.Write($"Nivel de Humo: % {humo}       ");
            Console.SetCursorPosition(50, 25);
            Console.Write($"Acción: {luzestroboscopica}       ");
        }



    }
    
}
