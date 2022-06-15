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

        //public static int processCount = 0; //contador de ciclos de procesos
        public static int priorityCount = 0; //contador de priority
        public static int blockingCount = 0; //contador de e/s
        public static int blokingOnTime = 0; //tiempo de duracón del bloqueo

        public static List<Proceso> processToEjecuteList = new List<Proceso>();


        public static Proceso OrderByPriority()
        {
            processToEjecuteList.Clear();
            List<Proceso> listaOrdenada = queue.OrderBy(c => c.priority).ThenBy(c => c.CpuTime).ToList();
            Proceso procesoListo = listaOrdenada[0];

            processToEjecuteList.Add(procesoListo);

            return procesoListo;
        }

        //Ordena la lista queue por priority y cpuTime, luego la asigna a listaOrdenada.
        public static void PlanificatorLogic()
        {
            Proceso procesoListo = processToEjecuteList[0];
            ejecution.Clear();
            ejecution.Add(procesoListo);

            //Verificamos si el proceso aun tiene CpuTime para correr
            if (procesoListo.CpuTime > 0)
            {
                blockingCount++;
                //verifica si el tiempo contador es igual al tiempo en que tiene que llegar la E/S del proceso
                if (blockingCount == procesoListo.waitingEs + 1)
                {
                    //Verifica si el tiempo que debe durar la E/S del bloqueo ya transcurrio o esta en curso
                    if (blokingOnTime < procesoListo.waitingInEs)
                    {
                        //Se resta el blocking count mientras no haya terminado de hacer la E/S sino lo realiza una sola vez.
                        blockingCount--;
                        //Se incrementa un ciclo la duración del bloqueo.
                        blokingOnTime++;

                        //Verifica si el proceso es de SO o de usuario
                        if (procesoListo.owner == true)
                        {
                            Console.WriteLine($"El proceso {procesoListo.Name} espera por E/S.");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"El proceso {procesoListo.Name} se añadió a la lista de bloqueados");
                            //se setean en 0 para que no siga contando para los demas procesos que comenzarán a ejecutar
                            blokingOnTime = 0;

                            ejecution.Remove(procesoListo);
                            queue.Remove(procesoListo);
                            blokedList.Add(procesoListo);
                            processToEjecuteList.Clear();
                            OrderByPriority();
                        }

                    }
                    //Después de realizar E/S se setea en 0
                    blockingCount = 0;
                }
                else
                {
                    procesoListo.CpuTime--;
                    blokingOnTime = 0;
                    Console.WriteLine($"El proceso {procesoListo.Name} se esta ejecutando con prioridad {procesoListo.priority}");
                }
            }
            else
            {
                Console.WriteLine($"El proceso {procesoListo.Name} finalizó su ejecución");
                Planificador.processFinishList.Add(procesoListo);
                queue.Remove(procesoListo);
                blockingCount = 0;
                blokingOnTime = 0;
                OrderByPriority();




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

        //Metodo para sacar proceso de la lista de bloqueo
        public static void BlokedStatus()
        {
            foreach (Proceso process in blokedList)
            {
                process.count++;

                if (process.waitingInEs + 1 == process.count)
                {
                    process.count = 0;
                    blokedList.Remove(process);

                    if (ejecution.ElementAt(0).owner == false)
                    {
                        //Console.WriteLine(blockingCount);
                        //Console.WriteLine(ejecution.ElementAt(0).owner);
                        //Console.WriteLine(ejecution.Count);
                        //Console.WriteLine($"se removio el proceso {process.Name} de la lista de bloqueados");
                        queue.Add(process);
                    }
                    else
                    {
                        queue.Add(process);
                    }
                }
            }
        }
    }
}
