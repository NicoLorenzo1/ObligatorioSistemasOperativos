using System;
using System.Timers;
using System.Linq;
using System.Collections.Generic;

namespace Library
{
    public class Cpu
    {
        public static int count = 0;

        System.Timers.Timer timerCounter = new System.Timers.Timer(1000);
        public static List<Proceso> queue = Proceso.processList;

        public void TimerCounter()
        {
            if (queue.Count > 0)
            {
            timerCounter.Elapsed += timerCounter_Elapsed;
            timerCounter.Start();
            timerCounter.Enabled = true;
            timerCounter.AutoReset = true;
            Console.ReadKey();
            }

            else
            {
                Console.WriteLine("No hay procesos para ejecutar.");
            }
        }

        private void timerCounter_Elapsed(Object source, ElapsedEventArgs e)
        {
            Planificador.priorityCount++;
            Planificador.processCount++;
            Planificador.blockingCount++;
            Planificador.OrderByPriority();
            Planificador.PriorityCalculated();
            Planificador.BlokedStatus();


        }

       
    }
}



