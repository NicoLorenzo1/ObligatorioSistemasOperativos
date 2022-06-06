using System;
using System.Threading.Tasks;
using System.Timers;

namespace Library
{
    public class Cpu
    {

        public static int count = 0;

        System.Timers.Timer timerCounter = new System.Timers.Timer(1000);
        public static List<Proceso> queue = Proceso.processList;
        public int ProcesosNum;
        public static int n = 0;


        public void FinishTimeGame()
        {
            timerCounter.Elapsed += timerCounter_Elapsed;
            timerCounter.Start();
            timerCounter.Enabled = true;
            timerCounter.AutoReset = true;
            Console.ReadKey();
        }

        private void timerCounter_Elapsed(Object source, ElapsedEventArgs e)
        {
            foreach (var item in queue)
            {
                if (n < item.CpuTime)
                {
                    n++;
                    Console.WriteLine($"El proceso {item.Name} se esta ejecutando");
                }

                else
                {
                    timerCounter.Stop();

                }

            }


        }
    }
}


