using Library;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Proceso proceso1 = new Proceso("proceso1", 4, 60);
            Proceso proceso2 = new Proceso("proceso2", 3, 100);
            Proceso proceso3 = new Proceso("proceso3", 6, 50);
            //Proceso proceso4 = new Proceso("proceso4", 2, 120);


       //Console.WriteLine(Planificador.queue.Count);
        //Planificador.LogicaPlanificador();
        Cpu cpu = new Cpu();
        cpu.FinishTimeGame();
        //cpu.OrderByPriority();

        }
    }
}

