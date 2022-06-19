using System;
using System.Timers;
using System.Linq;
using System.Collections.Generic;

namespace Library
{
    public class Cpu
    {
        public int count = 0;
        static bool activeLog = false;
        System.Timers.Timer timerCounter = new System.Timers.Timer(1000);
        // public static List<Proceso> queue = Proceso.processList;
        public void TimerCounter(bool activeLog)
        {
            Cpu.activeLog = activeLog;
            timerCounter.Elapsed += timerCounter_Elapsed;
            timerCounter.Start();
            timerCounter.Enabled = true;
            timerCounter.AutoReset = true;
            Console.ReadKey();

        }

        // else
        // {
        //     Console.WriteLine("No hay procesos para ejecutar.");
        //     timerCounter.Stop();
        //     return;
        // }
        //}

        private static void timerCounter_Elapsed(Object source, ElapsedEventArgs e)
        {
            Planificador.priorityCount++;

            //Planificador.processCount++;
            //Planificador.blockingCount++;
            //Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            Planificador.PlanificatorLogic(activeLog);
            Planificador.PriorityCalculated();
            Planificador.setCount();
            //Planificador.blockingCount++;
            Planificador.BlokedStatus();

            //Console.WriteLine(Planificador.processFinishList.Count);
            //Console.Clear();

            Impresion.ImpresionListas(activeLog);
        }

    }

}




