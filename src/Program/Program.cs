using Library;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Proceso proceso1 = new Proceso("proceso1", 4, 100, 2, 2, true);
            // Proceso proceso2 = new Proceso("proceso2", 6, 100, 3, 4, false);
            // Proceso proceso3 = new Proceso("proceso3", 8, 50, 2, 3, true);
            // Proceso proceso4 = new Proceso("proceso4", 2, 120);
            //Planificador.queue.Add(proceso1);
            LectorArchivo.Read();

            Planificador.OrderByPriority();
            Cpu cpu = new Cpu();

            //false muestra listas y true muestra paso a paso 
            cpu.TimerCounter(true);


        }
    }
}

