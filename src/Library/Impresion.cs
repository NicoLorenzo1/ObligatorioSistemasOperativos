using System;

namespace Library
{
    public static class Impresion
    {
        public static List<string> processNameQueue = new List<string>();
        public static List<string> processNameBlokedList = new List<string>();
        public static List<string> processNameEjecution = new List<string>();
        public static List<string> processNameFinish = new List<string>();




        public static void ImpresionListas(bool activeLog)
        {

            if (!activeLog)
            {

                foreach (var proceso in Planificador.queue)
                {
                    if (!processNameQueue.Contains(proceso.Name))
                    {
                        processNameQueue.Add(proceso.Name);
                    }
                }


                foreach (var proceso in Planificador.blokedList)
                {
                    if (!processNameBlokedList.Contains(proceso.Name))
                    {
                        processNameBlokedList.Add(proceso.Name);
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

                Console.Write($" Lista de procesos esperando para ejecutar ==> [{String.Join("-", processNameQueue)}] \n");
                Console.WriteLine("\n");

                Console.Write($" Proceso en ejecución ==> [{String.Join("-", Planificador.queue[0].Name)}] \n");
                Console.WriteLine("\n");

                Console.Write($" Lista de procesos bloqueados ==> [{String.Join("-", processNameBlokedList)}] \n");
                Console.WriteLine("\n");

                Console.Write($" Lista de procesos finalizados ==> [{String.Join("-", processNameFinish)}] \n");
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }

            processNameBlokedList.Clear();
            processNameQueue.Clear();
            processNameEjecution.Clear();



            //Console.Write($"Procesos esperando para ejecutar [{}]");


        }

        public static void Log(string message, bool active)
        {
            if (active == true)
            {
                Console.WriteLine(message);
            }
        }
    }


}

