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
        public static List<Proceso> blokedList = new List<Proceso>();

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
            ejecution.Add(procesoListo);


            //if (processCount <= procesoListo.CpuTime)
            if (procesoListo.CpuTime > 0)
            {

                if (blockingCount == procesoListo.waitingEs + 1)
                {

                    //Se resta contador de ciclos para que no se siga incrementando mientras esta en una E/S.
                    processCount--;

                    if (blockingTime < procesoListo.waitingInEs)
                    {

                        //Se resta contador de llegada de la E/S mientras dure la misma.
                        blockingCount--;

                        //Se incrementa un ciclo la duración del bloqueo.
                        blockingTime++;

                        if (procesoListo.owner == true)
                        {
                            Console.WriteLine($"El proceso {procesoListo.Name} espera por E/S.");
                        }
                        else
                        {
                            Console.WriteLine($"El proceso {procesoListo.Name} se añadió a la lista de bloqueados");
                            blockingTime--;
                            ejecution.Remove(procesoListo);
                            queue.Remove(procesoListo);
                            blokedList.Add(procesoListo);
                            
                            //Console.WriteLine($"cantidad de procesos bloqueados {blokedList.Count}");
                        }
                    }
                    else
                    {
                        blockingCount = 0;
                        blockingTime = 0;
                    }
                }
                else
                {
                    procesoListo.CpuTime--;
                    Console.WriteLine($"El proceso {procesoListo.Name} se esta ejecutando con prioridad {procesoListo.priority}");
                }
            }
            else
            {
                Console.WriteLine($"El proceso {procesoListo.Name} finalizó su ejecución");
                Planificador.processFinishList.Add(procesoListo);
                queue.Remove(procesoListo);
                processCount = 0;
                blockingCount = 0;
                blockingTime = 0;
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

        public static void BlokedStatus()
        {
            foreach (Proceso process in blokedList)
            {
                process.count++;

                if (process.waitingInEs +1 == process.count)
                {
                    process.count = 0;
                    blokedList.Remove(process);
                    //blockingCount = 0;

                    //process.CpuTime++;
                    Console.WriteLine($"se removio el proceso {process.Name} de la lista de bloqueados");
                    //Console.WriteLine($"hay {blokedList.Count} procesos bloqueados");
                    queue.Add(process);
                }

            }
        }

    }
}
