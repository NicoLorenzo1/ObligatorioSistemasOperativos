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
                while ((line = reader.ReadLine()) != null)
                {
                    
                    string[] lectura = new string[5];
                    lectura = line.Split(';');
                    string name = lectura[0];
                    
                    int cpu = int.Parse(lectura[1]);
                    int priority = int.Parse(lectura[2]);
                    int wait = int.Parse(lectura[3]);
                    int waitEs = int.Parse(lectura[4]);

                    Proceso proceso = new Proceso(name, cpu, priority, wait, waitEs);
                    //Console.WriteLine(cpu);
                    //Console.WriteLine(line);



                }
            }
        }
    }
}