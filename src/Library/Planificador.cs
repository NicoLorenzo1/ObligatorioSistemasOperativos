using System.Linq;
using System.Collections.Generic;
using System;

namespace Library
{
    public class Planificador
    {

        private static List<Proceso> queue = new List<Proceso>();
        public static List<Proceso> blockedList = new List<Proceso>();
        public static List<Proceso> processFinishList = new List<Proceso>();


        public static int priorityCount = 0; //contador de priority
        public static int counter = 1; //contador de e/s

        public static Proceso current;

        public static List<Proceso> Queue
        {
            get
            {
                return queue;
            }
            set
            {
                queue = value;
            }
        }


        public static void SchedulerLogic()
        {

            priorityCount++;

            if (queue.Count > 0)
            {
                current = queue[0];

                Console.WriteLine($">>>> {current.CpuTime} - {current.ioCounter} - {counter}");

                // Si no termino proceso
                if (current.CpuTime > 0)
                {
                    if (current.ioTime + 1 == counter && current.ioTime > 0)
                    { // momento de E/S
                        if (current.owner == true)
                        { // proceso de SO - continuar la ejecucion - Procesar y procesar E/S
                            if (current.ioCounter == 0)
                            { //el primer ciclo decrementa un ciclo de los requeridos por el proceso
                                //current.CpuTime--;
                                //Console.WriteLine($"El proceso de SO {current.Name} se esta ejecutando con prioridad {current.priority}");
                            }
                            if (current.ioRequiredTime > current.ioCounter)
                            { // Falta procesar E/S
                                current.ioCounter++;
                                Console.WriteLine($" # - El proceso de SO {current.Name} espera por E/S.");
                            }
                            else
                            { // se procesaron todas las E/S
                                counter = 1;
                                current.ioCounter = 0;
                                Console.WriteLine($" # - El proceso de SO {current.Name} finaliza la E/S.");
                                SchedulerLogic();
                            }

                            //procesar

                            //manejar E/S
                        }
                        else
                        { // proceso de Usuario - agregar a la lista de bloqueados
                            if (current.ioCounter == 0)
                            { //el primer ciclo decrementa un ciclo de los requeridos por el proceso
                              //Console.WriteLine($"El proceso de Usuario {current.Name} se esta ejecutando con prioridad {current.priority}");
                              //current.CpuTime--;

                            }
                            Console.WriteLine($" # - El proceso {current.Name} se añadió a la lista de bloqueados");
                            counter = 1;
                            queue.Remove(current);
                            blockedList.Add(current);

                            if (queue.Count == 0)
                            {
                                current = null;

                            }
                            //OrderByPriority();
                        }
                    }
                    else
                    { // Procesar 
                        current.CpuTime--;
                        counter++;
                        //Console.WriteLine($"El proceso {current.Name} se esta ejecutando con prioridad {current.priority}");
                        //Console.WriteLine($" # - >>> >>>> {current.CpuTime}");


                    }

                }
                else
                { // Finalizar proceso


                    Console.WriteLine($" # - El proceso {current.Name} finalizó su ejecución");

                    processFinishList.Add(current);
                    queue.Remove(current);
                    counter = 1;
                    OrderByPriority();
                }
            }
            BlockedStatus();


        }


        public static void OrderByPriority()
        {
            //Ordena por prioridad y si dos procesos tienen la misma prioridad toma el que tenga menor tiempo de cpu.
            //Luego asigna el proceso que debe ejecutar a la lista processToEjecuteList

            if (queue.Count > 0)
            {

                queue = queue.OrderByDescending(c => c.priority).ToList();
                Proceso current;

                if (queue.Count > 1 && queue.ElementAt(0).priority == queue.ElementAt(1).priority)
                {
                    queue = queue.OrderBy(c => c.CpuTime).ToList();
                    current = queue[0];
                }
                else
                {
                    current = queue[0];
                }
            }

            if (blockedList.Count == 0 && queue.Count == 0)
            {
                Console.WriteLine(" #No hay procesos para ejecutar");
            }

        }

        //Metodo para sacar proceso de la lista de bloqueo
        public static void BlockedStatus()
        {
            List<Proceso> processToRemove = new List<Proceso>();

            foreach (Proceso process in blockedList)
            {
                process.ioCounter++;
                if (process.ioRequiredTime < process.ioCounter)
                {
                    process.ioCounter = 0;
                    queue.Add(process);
                    processToRemove.Add(process);
                    Console.WriteLine($" # - El proceso {process.Name} fue removido de la lista de bloqueados");
                }
            }
            foreach (var process in processToRemove)
            {
                blockedList.Remove(process);
            }



        }




        public static void PriorityCalculated()
        {
            if (priorityCount == 5)
            {
                foreach (var item in queue.Skip(1))
                {
                    item.TimeWaiting++;
                    item.priority += (item.TimeWaiting + item.CpuTime) / item.CpuTime;
                }
                priorityCount = 0;
            }
        }

    }
}

