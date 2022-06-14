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



        public Planificador()
        {

        }

        //Ordena la lista queue por priority y cpuTime, luego la asigna a listaOrdenada.
        public static void OrderByPriority()
        {
            var listaOrdenada = queue.OrderBy(c => c.priority).ThenBy(c => c.CpuTime).ToList();

            Proceso procesoListo = listaOrdenada[0];
            ejecution.Add(procesoListo);


            //Verificamos si el proceso aun tiene CpuTime para correr
            if (procesoListo.CpuTime > 0)
            {

                //verifica si el tiempo contador es igual al tiempo en que tiene que llegar la E/S del proceso
                if (blockingCount == procesoListo.waitingEs + 1)
                {
                    //Verifica si el tiempo que debe durar la E/S del bloqueo ya transcurrio o esta en curso
                    if (blokingOnTime <= procesoListo.waitingInEs)
                    {
                        //Se incrementa un ciclo la duración del bloqueo.
                        blokingOnTime++;

                        //Verifica si el proceso es de SO o de usuario
                        if (procesoListo.owner == true)
                        {
                            Console.WriteLine($"El proceso {procesoListo.Name} espera por E/S.");
                            blockingCount = 0;

                        }
                        else
                        {
                            Console.WriteLine($"El proceso {procesoListo.Name} se añadió a la lista de bloqueados");
                            //se setean en 0 para que no siga contando para los demas procesos que comenzarán a ejecutar
                            blokingOnTime = 0;
                            blockingCount = 0;

                            ejecution.Remove(procesoListo);
                            queue.Remove(procesoListo);
                            blokedList.Add(procesoListo);
                        }
                    }
                }
                else
                {
                    procesoListo.CpuTime--;
                    blokingOnTime = 0;
                    Console.WriteLine($"El proceso {procesoListo.Name} se esta ejecutando con prioridad {procesoListo.priority}");
                    Console.WriteLine(blockingCount);
                    Console.WriteLine(blokingOnTime);
                    Console.WriteLine(procesoListo.waitingInEs);
                }
            }
            else
            {
                Console.WriteLine($"El proceso {procesoListo.Name} finalizó su ejecución");
                Planificador.processFinishList.Add(procesoListo);
                queue.Remove(procesoListo);
                blockingCount = 0;
                blokingOnTime = 0;
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

                if (process.waitingInEs + 1 == process.count)
                {
                    process.count = 0;
                    blokedList.Remove(process);
                    blockingCount--;

                    Console.WriteLine($"se removio el proceso {process.Name} de la lista de bloqueados");
                    queue.Add(process);
                }

            }
        }

    }
}
