using System.Linq;
using System.Collections.Generic;
using System;

namespace Library
{
    public class Planificador
    {
        //public static List<Proceso> processList = Proceso.processList;
        public static List<Proceso> processFinishList = new List<Proceso>();

        public static List<Proceso> queue = Proceso.processList;

        public static List<Proceso> ejecution = new List<Proceso>();


        public static int processCount = 0; //contador de ciclos de procesos
        public static int priorityCount = 0; //contador de priority
        public static int blockingCount = 0; //contador de e/s
        public static int blockingTime = 0; //tiempo de duracón del bloqueo



        public Planificador()
        {

        }

        //Ordena la lista queue por priority y cpuTime, luego la asigna a listaOrdenada.
        public static void OrderByPriority()
        {
            var listaOrdenada = queue.OrderBy(c => c.priority).ThenBy(c => c.CpuTime).ToList();

            Proceso procesoListo = listaOrdenada[0];
            Planificador.ejecution.Add(procesoListo);


            if (processCount <= procesoListo.CpuTime)
            {
                if (blockingCount == procesoListo.waitingEs)
                {
                    //Se resta contador de ciclos para que no se siga incrementando mientras esta en una E/S.
                    processCount--;

                    if (blockingTime < procesoListo.waitingInEs)
                    {
                        //Se resta contador de llegada de la E/S mientras dure la misma.
                        blockingCount--;

                        //Se incrementa un ciclo la duración del bloqueo.
                        blockingTime++;
                        Console.WriteLine($"se esta ejecutando una entrada salida del proceso {procesoListo.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"El proceso {procesoListo.Name} se esta ejecutando con prioridad {procesoListo.priority}");
                }
            }
            else
            {
                Console.WriteLine($"El proceso {procesoListo.Name} finalizó su ejecución");
                Planificador.processFinishList.Add(procesoListo);
                queue.Remove(procesoListo);
                processCount = 0;
            }
            return;
        }


        public static void PriorityCalculated()
        {
            if (priorityCount == 5)
            {
                foreach (var item in queue)
                {
                    if (!ejecution.Contains(item))
                    {
                        item.TimeWaiting++;
                        item.priority += (item.TimeWaiting + item.CpuTime) / item.CpuTime;
                    }
                }
                priorityCount = 0;

            }
        }

    }
}
