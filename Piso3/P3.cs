using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Piso3
{
    public class P3
    {
        public DateTime Tiempo { get; set; }
        public int Piso { get; set; }
        public double Temp1 { get; set; }
        public int Humo1 { get; set; }
        public double Temp2 { get; set; }
        public int Humo2 { get; set; }
    }

    public class MapaPiso
    {
        public Random rnd = new Random();

        public void MostrarSimulacion()
        {
            P3 dato = SimularSensores();
            PlanoCasaP3(dato);
            MostrarEstado(dato);
            VerificarAlarmas(dato);
        }

        public P3 SimularSensores()
        {
            return new P3
            {
                Tiempo = DateTime.Now,
                Piso = 3,
                Temp1 = Math.Round(rnd.NextDouble() * 70 + 20, 1), 
                Humo1 = rnd.Next(10, 50), 
                Temp2 = Math.Round(rnd.NextDouble() * 70 + 20, 1), 
                Humo2 = rnd.Next(10, 50) 
            };
        }

        public void PlanoCasaP3(P3 dato)
        {
            
            Console.Clear();
            Console.WriteLine("                     ╔════════════════════════════════════════════░░░░══════════════════════════░░░░══╗");
            Console.WriteLine("                     ║      ╔══════╗               ▓                           ┌───────────────┐      ║");
            Console.WriteLine("                     ║      ║------║               ▓                           │ Cuarto 2      │      ║");
            Console.WriteLine("                     ║      ║--  --║               ▓                           │ Temp:{0,5}°C  │      ║", dato.Temp2);
            Console.WriteLine("                     ║      ║--  --║               ▓                           │ Humo: {1,3}%  │      ║", dato.Temp2, dato.Humo2);
            Console.WriteLine("                     ║      ║--  --║               ▓                           └───────────────┘      ║");
            Console.WriteLine("                     ║      ║--  --║               ▓                                                  ║");
            Console.WriteLine("                     ║      ║--  --║               ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓       ║");
            Console.WriteLine("                     ║      ╚══════╝                                                                  ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                                                                                ║");
            Console.WriteLine("                     ║                       ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓                  ║");
            Console.WriteLine("                     ║                                                              ▓                 ║");
            Console.WriteLine("                     ║                                                              ▓                 ║");
            Console.WriteLine("                     ║                                                              ▓                 ║");
            Console.WriteLine("                     ║                         ┌───────────────┐                    ▓                 ║");
            Console.WriteLine("                     ║                   ▓     │ Cuarto 1      │                    ▓                 ║");
            Console.WriteLine("                     ║                   ▓     │ Temp: {0,5}°C │                    ▓                 ║", dato.Temp1);
            Console.WriteLine("                     ║                   ▓     │ Humo: {1,3}%    │                    ▓                 ║", dato.Temp1, dato.Humo1);
            Console.WriteLine("                     ║                   ▓     └───────────────┘                    ▓                 ║");
            Console.WriteLine("                     ╚══════░░░░════════════════════════════════════════░░░░══════════════════════════╝");
            
        }


        public void MostrarEstado(P3 dato)
        {
            Console.WriteLine("                                    ════════════════════════════════════════════════");
            Console.WriteLine("                                        ========== ESTADO DEL PISO 3 ==========");
            EscribirCentrado($"Última actualización: {dato.Tiempo}");

            EscribirCentrado($"Cuarto 1 - Temp: {dato.Temp1} °C", NivelRiesgoTemperatura(dato.Temp1));
            EscribirCentrado($"Cuarto 1 - Humo: {dato.Humo1}%", NivelRiesgoHumo(dato.Humo1));
            Console.WriteLine("                                    ════════════════════════════════════════════════");
            EscribirCentrado($"Cuarto 2 - Temp: {dato.Temp2} °C", NivelRiesgoTemperatura(dato.Temp2));
            EscribirCentrado($"Cuarto 2 - Humo: {dato.Humo2}%", NivelRiesgoHumo(dato.Humo2));

            Console.WriteLine("                                    ════════════════════════════════════════════════");
        }
        public void EscribirCentrado(string texto, string nivel)
        {
            int ancho = Console.WindowWidth;
            int margen = Math.Max((ancho - texto.Length) / 2, 0);
            Console.Write(new string(' ', margen));

            switch (nivel)
            {
                case "Estable":
                case "Bajo":
                    break;
                case "Normal":
                case "Moderado":
                    break;
                case "Peligro":
                    break;
            }

            Console.WriteLine(texto);
        }

        public void VerificarAlarmas(P3 dato)
        {
            bool cuarto1Peligro = dato.Temp1 >= 30 || dato.Humo1 >= 45;
            bool cuarto2Peligro = dato.Temp2 >= 30 || dato.Humo2 >= 45;

            if (cuarto1Peligro && cuarto2Peligro)
            {
                EscribirCentrado(" ALARMA CRÍTICA: AMBOS CUARTOS EN PELIGRO");
                ReproducirAlarma1("Alarmas/sonidoPELIGRO.wav");
            }
            else if (cuarto1Peligro || cuarto2Peligro)
            {
                EscribirCentrado(" ALARMA: Un cuarto presenta riesgo de incendio");
                ReproducirAlarma2("Alarmas/sonidoLEVE.wav");
            }
        }
        public void ReproducirAlarma1(string rutaArchivo)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(rutaArchivo);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reproducir sonido crítico: " + ex.Message);
            }
        }
        public void ReproducirAlarma2(string rutaArchivo)
        {
            try
            {
                SoundPlayer soundPlayer = new SoundPlayer(rutaArchivo);
                soundPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reproducir sonido leve: " + ex.Message);
            }
        }

        public string NivelRiesgoTemperatura(double temp)
        {
            if (temp < 28) return "Estable";
            if (temp < 30) return "Normal";
            return "Peligro";
        }

        public string NivelRiesgoHumo(int humo)
        {
            if (humo < 20) return "Bajo";
            if (humo < 35) return "Moderado";
            return "Peligro";
        }

        public void EscribirCentrado(string texto)
        {
            int ancho = Console.WindowWidth;
            int margen = Math.Max((ancho - texto.Length) / 2, 0);
            Console.WriteLine(new string(' ', margen) + texto);
        }
    }
}

