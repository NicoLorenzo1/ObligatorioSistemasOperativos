using System;

namespace Library
{
    public static class Impresion
    {
        public static List<string> processNameQueue = new List<string>();
        public static List<string> processNameBlockedList = new List<string>();
        public static List<string> processNameEjecution = new List<string>();
        public static List<string> processNameFinish = new List<string>();

        public static void ImpresionListas()
        {

            foreach (var proceso in Planificador.Queue)
            {
                if (!processNameQueue.Contains(proceso.Name))
                {
                    processNameQueue.Add(proceso.Name);
                }
                processNameQueue.Remove(Planificador.current.Name);
            }

            foreach (var proceso in Planificador.blockedList)
            {
                if (!processNameBlockedList.Contains(proceso.Name))
                {
                    processNameBlockedList.Add(proceso.Name);
                }
            }

            foreach (var proceso in Planificador.processFinishList)
            {
                if (!processNameFinish.Contains(proceso.Name))
                {
                    processNameFinish.Add(proceso.Name);
                }
            }



            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n Lista de procesos esperando para ejecutar ==> [{String.Join(" - ", processNameQueue)}] \n");

            Console.Write($" Proceso en ejecución ==> [");
            if (Planificador.Queue.Count > 0 && !processNameBlockedList.Contains(Planificador.current.Name) && !processNameFinish.Contains(Planificador.current.Name))
            {
                Console.Write(String.Join(" - ", Planificador.current.Name));
            }
            Console.Write("]");
            Console.WriteLine("\n");

            Console.WriteLine($" Lista de procesos bloqueados ==> [{String.Join(" - ", processNameBlockedList)}] \n");

            Console.WriteLine($" Lista de procesos finalizados ==> [{String.Join(" - ", processNameFinish)}] \n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;


            processNameBlockedList.Clear();
            processNameQueue.Clear();
            processNameEjecution.Clear();
        }
    }
}

