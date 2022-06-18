using System;
using System.IO;

namespace Library
{
    public class LectorArchivo
    {

        public static void Read()
        {
            string path = @"C:\Users\loren\OneDrive\Escritorio\Sistemas Operativos\PlanificadorLectura.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                //while ((line = reader.ReadLine()) != null)
                int n = 0;
                //while (n < 6)
                while ((line = reader.ReadLine()) != null)
                {
                    //line = reader.ReadLine();
                    if (line != string.Empty)
                    {
                        n++;

                        string[] lectura = new string[6];


                        lectura = line.Split(';');


                        string name = lectura[0];

                        int cpu = int.Parse(lectura[1]);


                        int priority = int.Parse(lectura[2]);
                        int wait = int.Parse(lectura[3]);
                        int waitEs = int.Parse(lectura[4]);
                        bool owner = bool.Parse(lectura[5]);


                        Proceso proceso = new Proceso(name, cpu, priority, wait, waitEs, owner);
                        Planificador.queue.Add(proceso);
                        //Console.WriteLine(cpu);

                        // Console.WriteLine(name);

                        //Console.WriteLine(line);

                    }


                }
            }
        }
    }
}