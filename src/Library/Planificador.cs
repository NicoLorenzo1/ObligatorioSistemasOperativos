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
            Console.WriteLine($">>>> {procesoListo.CpuTime} - {procesoListo.blokingOnTime} - {blockingCount}");

            //Verificamos si el proceso aun tiene CpuTime para correr

            if (procesoListo.owner == true)
            {
                if (procesoListo.CpuTime + 1 > 0)
                {
                    if (blockingCount < procesoListo.waitingEs && procesoListo.CpuTime > 0)
                    {
                        blockingCount++;
                        Console.WriteLine("Se Ejecuta");
                        Impresion.Log($"El proceso {procesoListo.Name} se esta ejecutando con prioridad {procesoListo.priority}", activeLog);
                        procesoListo.CpuTime--;
                    }
                    else
                    {
                        if (blockingCount == procesoListo.waitingEs)
                        {
                            if (procesoListo.blokingOnTime < procesoListo.waitingInEs)
                            {
                                Console.WriteLine("Prueba llegada E/S");
                                procesoListo.blokingOnTime++;
                                Impresion.Log($"El proceso {procesoListo.Name} espera por E/S.", activeLog);
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
                    }

                    //Si el proceso no es de SO
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

                /*
                else
                {
                    Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                    if (blockingCount < procesoListo.waitingEs)
                    {
                        blockingCount++;
                        Impresion.Log($"El proceso {procesoListo.Name} se esta ejecutando con prioridad {procesoListo.priority}", activeLog);
                    }

                }*/

            }




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
            else
            {
                Console.WriteLine("No hay procesos para ejecutar.");
            }
        }

        //Metodo para sacar proceso de la lista de bloqueo
        public static void BlokedStatus()
        {

            foreach (Proceso process in blokedList)
            {
                Console.WriteLine(blokedList.Count);
                process.blokingOnTime++;

                if (process.waitingInEs == process.blokingOnTime)
                {
                    process.blokingOnTime = 0;
                    blokedList.Remove(process);
                    queue.Add(process);
                    Console.WriteLine($"se removio el proceso {process.Name} de la lista de bloqueados");

                    if (queue[0].owner == false)
                    {
                        OrderByPriority();
                    }
                }

            }
            if (queue.Count == 0 && blokedList.Count > 0)
            {
                BlokedStatus();
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

        public static void setCount()
        {
            if (queue[0].blokingOnTime == queue[0].waitingInEs)
            {
                blockingCount = 0;
                queue[0].blokingOnTime = 0;
            }
        }


    }
}