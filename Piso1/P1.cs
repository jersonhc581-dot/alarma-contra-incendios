using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Piso1
{
    public class P1
    {
        public double HumoPorcentaje { get; private set; } = 0.0;
        public double Temperatura { get; private set; } = 25.0;
        private Random random = new Random();

        public void MostrarPrimerPiso()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║   ┌────────────┐      ║                ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("║   │            │      ╗                ║   ║   ║   ║E S C A L E R A║   ║   ║   ║");
            Console.WriteLine("║   └────────────┘      ║                ║   ║   ║   ║   ║   ║   ║   ║   ║   ║   ║");
            Console.WriteLine("║╔═╗    ╔═╗    ╔═╗      ╝                ╚═══════════════════════════════════════║");
            Console.WriteLine("║║ ║    ║ ║ A  ║ ║      ║                                                        ║");
            Console.WriteLine("║║ ║    ║ ║    ║ ║      ║                                                        ║");
            Console.WriteLine("║║ ║    ║ ║ L  ║ ║      ║          ╔═   ╔═   ╔═      ┌──────┐                    ║");
            Console.WriteLine("║║ ║    ║ ║    ║ ║      ║          ╚═   ╚═   ╚═      │      │        ══╔╦═  V ═══║");
            Console.WriteLine("║╚═╝    ╚═╝ M  ╚═╝      ║          ╔═   ╔═   ╔═      │      │          ║║   E    ║");
            Console.WriteLine("║╔═╗    ╔═╗    ╔═╗      ║          ╚═   ╚═   ╚═      │      │          ║║   N    ║");
            Console.WriteLine("║║ ║    ║ ║ A  ║ ║      ║          ╔═   ╔═   ╔═      │      │        ══║║   T    ║");
            Console.WriteLine("║║ ║    ║ ║    ║ ║      ║          ╚═   ╚═   ╚═      │      │          ║║   A    ║");
            Console.WriteLine("║║ ║    ║ ║ C  ║ ║      ║          ╔═   ╔═   ╔═      │      │          ║║   N    ║");
            Console.WriteLine("║║ ║    ║ ║    ║ ║      ║          ╚═   ╚═   ╚═      │      │        ══║║   I    ║");
            Console.WriteLine("║║ ║    ║ ║ É  ║ ║      ║                            └──────┘          ║║   L    ║");
            Console.WriteLine("║║ ║    ║ ║    ║ ║      ║                                            ══╚╩══ L ═══║");
            Console.WriteLine("║╚═╝    ╚═╝ N  ╚═╝      ║                                                   A    ║");
            Console.WriteLine("║                       ║      ╚╦╝╚╦╝╚╦╝╚╦╝╚╦╝╚╦╝╚╦╝                             ║");
            Console.WriteLine("║════════╠      ╣═══════╩════════════════╦══════════════╠         ╣══════════════║");
            Console.WriteLine("║                                        ║                                       ║");
            Console.WriteLine("║                                        ║                                       ║");
            Console.WriteLine("║                                        ║                                       ║");
            Console.WriteLine("║                                        ║                                       ║");
            Console.WriteLine("║                                        ║                                       ║");
            Console.WriteLine("║             ╔             ╗            ║            ╔             ╗            ║");
            Console.WriteLine("║               S A L I D A              ║              S A L I D A              ║");
            Console.WriteLine("║             ╚             ╝            ║            ╚             ╝            ║");
            Console.WriteLine("║               ═══════════              ║              ═══════════              ║");
            Console.WriteLine("╚═══════════════╚═════════╝══════════════╩══════════════╚═════════╝══════════════╝");
        }
        public void Actualizar()
        {
            SimularSensores();
            MostrarDatos();
            MostrarPrimerPiso();
            VerificarAlarmas();
        }

        private void SimularSensores()
        {
            double cambioMaximoTemp = 5.0;
            double cambioAleatorioTemp = (random.NextDouble() * 2 - 1) * cambioMaximoTemp;

            Temperatura += cambioAleatorioTemp;

            if (Temperatura < 20) Temperatura = 20;
            if (Temperatura > 100) Temperatura = 100;

            if (Temperatura > 40)
            {
                double tempSobre80 = Temperatura - 80;
                HumoPorcentaje = (tempSobre80 / 20.0) * 50.0;

                if (HumoPorcentaje > 50)
                    HumoPorcentaje = 50;
                if (HumoPorcentaje < 0)
                    HumoPorcentaje = 0;
            }
            else
            {
                HumoPorcentaje = 0;
            }
        }

        private void MostrarDatos()
        {
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine($"║ Piso 1                             ║");
            Console.WriteLine($"║ Temperatura: {Temperatura:F2}°     ║");
            Console.WriteLine($"║ Humo: {HumoPorcentaje:F0}%         ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
        }

        private void VerificarAlarmas()
        {
            if (Temperatura >= 60 || HumoPorcentaje >= 40)
            {
                Console.WriteLine(" ALERTA CRÍTICA PISO 1");
                Reproducir("Alarmas/sonidoPELIGRO.wav");
            }
            else if (Temperatura >= 40 || HumoPorcentaje >= 25)
            {           
                Console.WriteLine(" ADVERTENCIA PISO 1");
                Reproducir("Alarmas/sonidoLEVE.wav");
            }
        }

        private void Reproducir(string ruta)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer(ruta);
                sp.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sonido: " + ex.Message);
            }
        }
    }
}