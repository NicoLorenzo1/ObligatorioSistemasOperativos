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




        public Planificador()
        {

        }

        public static void LogicaPlanificador()
        {

            int count = 0;

            if (count > 2)
            {
                count = 0;
            }


            while (queue.Count != 0)
            {

                count = +1;

                if (count == 2)
                {
                    foreach (var item in queue)
                    {
                        item.priority = (2 + item.CpuTime) / item.CpuTime;
                    }

                    Console.WriteLine($"Se actualizó la prioridad de los procesos");
                }

                var orderPriority = queue.OrderBy(x => x.priority);
                var maxPriority = orderPriority.Last();
                //Console.WriteLine($"El proceso de mayor prioridad es {maxPriority.Name}");

                queue.Remove(maxPriority);
                Console.WriteLine($"El proceso {maxPriority.Name} comenzará su ejecución");

                processFinishList.Add(maxPriority);
                Console.WriteLine($"El proceso {maxPriority.Name} finalizó su ejecución");

            }


        }

    }
}
