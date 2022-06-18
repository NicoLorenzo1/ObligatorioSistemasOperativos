using System.Linq;
using System.Collections.Generic;
using System;

namespace Library
{
    public class Planificador
    {
        //public static List<Proceso> processList = Proceso.processList;
        public static List<Proceso> processFinishList = new List<Proceso>();

        public static List<Proceso> queue = new List<Proceso>();

        //public static List<Proceso> ejecution = new List<Proceso>();
        public static List<Proceso> blokedList = new List<Proceso>();

        //public static int processCount = 0; //contador de ciclos de procesos
        public static int priorityCount = 0; //contador de priority
        public static int blockingCount = 0; //contador de e/s

        //public static List<Proceso> processToEjecuteList = new List<Proceso>();

        public static void PlanificatorLogic(bool activeLog)
        {
            Proceso procesoListo = queue[0];
            Console.WriteLine($">>>>{procesoListo.Name} - {procesoListo.CpuTime} - {procesoListo.blokingOnTime} - {blockingCount}");

            //Console.WriteLine($"cputime>>>> {procesoListo.CpuTime}");
            //Console.WriteLine($"blokingOnTime>>>> {procesoListo.blokingOnTime}");
            //Console.WriteLine($"BlockingCount>>>> {blockingCount}");

            //Verificamos si el proceso aun tiene CpuTime para correr
            if (procesoListo.CpuTime >= 0)
            {
                //blockingCount++;
                //verifica si el tiempo contador es igual al tiempo en que tiene que llegar la E/S del proceso
                if (blockingCount == procesoListo.waitingEs && procesoListo.waitingEs != 0)
                {
                    if (procesoListo.owner == true)
                    {
                        //+1 bloking on time
                        if (procesoListo.blokingOnTime < procesoListo.waitingInEs)
                        {
                            Impresion.Log($"El proceso {procesoListo.Name} espera por E/S.", activeLog);
                            procesoListo.blokingOnTime++;
                        }
                        else
                        {
                            //procesoListo.CpuTime--;
                            procesoListo.blokingOnTime = 0;
                            blockingCount = 0;
                            //procesoListo.CpuTime--;
                        }
                    }
                    else
                    {
                        Impresion.Log($"El proceso {procesoListo.Name} se añadió a la lista de bloqueados", activeLog);
                        //se setean en 0 para que no siga contando para los demas procesos que comenzarán a ejecutar
                        ////procesoListo.blokingOnTime = 0;
                        blockingCount = 0;
                        queue.Remove(procesoListo);
                        blokedList.Add(procesoListo);
                        OrderByPriority();
                    }
                }
                else
                {
                    if (procesoListo.CpuTime == 0)
                    {
                        // blockingCount++;
                        procesoListo.CpuTime--;
                        processFinishList.Add(procesoListo);
                        queue.Remove(procesoListo);



                    }
                    else
                    {
                        blockingCount++;
                        procesoListo.CpuTime--;
                        //blokingOnTime = 0;
                        //Console.WriteLine(procesoListo.CpuTime);
                        Impresion.Log($"El proceso {procesoListo.Name} se esta ejecutando con prioridad {procesoListo.priority}", activeLog);
                    }
                }

            }
            else
            {
                Impresion.Log($"El proceso {procesoListo.Name} finalizó su ejecución", activeLog);
                processFinishList.Add(procesoListo);
                queue.Remove(procesoListo);
                blockingCount = 0;
                // blokingOnTime = 0;
                OrderByPriority();
            }
            BlokedStatus();

        }




        public static void OrderByPriority()
        {
            //Ordena por prioridad y si dos procesos tienen la misma prioridad toma el que tenga menor tiempo de cpu.
            //Luego asigna el proceso que debe ejecutar a la lista processToEjecuteList

            if (queue.Count > 0)
            {

                queue = queue.OrderByDescending(c => c.priority).ToList();
                Proceso procesoListo;

                if (queue.Count > 1 && queue.ElementAt(0).priority == queue.ElementAt(1).priority)
                {
                    queue = queue.OrderBy(c => c.CpuTime).ToList();
                    procesoListo = queue[0];
                }
                else
                {
                    procesoListo = queue[0];
                }
            }

            if (blokedList.Count > 0 && queue.Count == 0)
            {
                BlokedStatus();
            }


        }

        //Metodo para sacar proceso de la lista de bloqueo
        public static void BlokedStatus()
        {
            if (blokedList.Count > 0)
            {
                //List<Proceso> blockedListCopy = blokedList;
                foreach (Proceso process in blokedList)
                {
                    process.blokingOnTime++;
                    if (process.waitingInEs + 1 == process.blokingOnTime)
                    {
                        process.blokingOnTime = 0;
                        blokedList.Remove(process);
                        queue.Add(process);

                        if (queue[0].owner == false)
                        {
                            Console.WriteLine($"se removio el proceso {process.Name} de la lista de bloqueados");
                            OrderByPriority();
                        }
                    }
                }
                if (blokedList.Count > 0 && queue.Count == 0)
                {
                    // Console.WriteLine("El proceso esta bloqueado y no hay nada para ejecutar.");
                    BlokedStatus();
                }

            }

        }



        public static void PriorityCalculated()
        {
            if (priorityCount == 5)
            {
                foreach (var item in queue)
                {
                    item.TimeWaiting++;
                    item.priority += (item.TimeWaiting + item.CpuTime) / item.CpuTime;
                }
                priorityCount = 0;
            }
        }


    }
}
