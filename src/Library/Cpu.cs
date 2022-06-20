using System.Timers;

namespace Library
{
    public class Cpu
    {
        private static System.Timers.Timer timerCounter = new System.Timers.Timer(2000);

        public void TimerCounter()
        {
            timerCounter.Elapsed += timerCounter_Elapsed;
            timerCounter.Start();
            timerCounter.Enabled = true;
            timerCounter.AutoReset = true;
            Console.ReadKey();
        }

        private static void timerCounter_Elapsed(Object source, ElapsedEventArgs e)
        {
            //Console.Clear();

            Planificador.SchedulerLogic();
            Planificador.PriorityCalculated();
            Impresion.ImpresionListas();

            if (Planificador.Queue.Count == 0 && Planificador.blockedList.Count == 0)
            {
                timerCounter.Close();
            }

        }

    }

}




