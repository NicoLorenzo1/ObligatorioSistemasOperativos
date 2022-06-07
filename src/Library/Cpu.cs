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

        public static int n = 0;
        public static int espera = 0;


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
            espera++;
            n++;
            OrderByPriority();
        }

        public void OrderByPriority()
        {
            var listaOrdenada = queue.OrderByDescending(x => x.priority).ToList();
            Proceso procesoListo = listaOrdenada[0];
            Planificador.ejecution.Add(procesoListo);

            if (n <= procesoListo.CpuTime)
            {
                Console.WriteLine($"El proceso {procesoListo.Name} se esta ejecutando..");
            }
            else
            {
                Planificador.processFinishList.Add(procesoListo);
                queue.Remove(procesoListo);
                n = 0;
            }
            return;
        }

        
                public void PriorityCalculated()
                {
                    foreach (var item in queue)
                    {
                        item.priority = (espera + item.CpuTime) / item.CpuTime;
                    }
                }
        

    }
}



