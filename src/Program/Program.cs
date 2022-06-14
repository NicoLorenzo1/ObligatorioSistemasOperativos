using Library;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // Proceso proceso1 = new Proceso("proceso1", 5, 100, 2, 2, true);
            Proceso proceso2 = new Proceso("proceso2", 6, 100, 3, 4, false);
            Proceso proceso3 = new Proceso("proceso3", 7, 100, 2, 3, true);
           // Proceso proceso4 = new Proceso("proceso4", 2, 120);

            //LectorArchivo.Read();

            Cpu cpu = new Cpu();
            cpu.TimerCounter();
            //cpu.OrderByPriority();


        }
    }
}

