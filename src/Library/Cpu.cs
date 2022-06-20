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
        private static System.Timers.Timer timerCounter = new System.Timers.Timer(1000);

        public void TimerCounter(bool activeLog)
        {
            Cpu.activeLog = activeLog;
            timerCounter.Elapsed += timerCounter_Elapsed;
            timerCounter.Start();
            timerCounter.Enabled = true;
            timerCounter.AutoReset = true;
            Console.ReadKey();

        }

        private static void timerCounter_Elapsed(Object source, ElapsedEventArgs e)
        {

            Planificador.priorityCount++;

            //Console.Clear();

            Planificador.SchedulerLogic();
            Impresion.ImpresionListas(activeLog);

            Planificador.PriorityCalculated();


            if (Planificador.Queue.Count == 0 && Planificador.blockedList.Count == 0)
            {
                timerCounter.Close();
            }

        }

    }

}




