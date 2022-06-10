using System;

namespace Library
{
    public class Proceso
    {
        private string name;
        private int cpuTime;
        public int priority;
        private int timeWaiting;
        public int waitingEs; //cada cuanto tiempo requiere entrada salida

        public int waitingInEs; //tiempo que demora mientras hace la entrada salida

        public static List<Proceso> processList = new List<Proceso>();

        public Proceso(string name, int cpuTime, int priority, int waitingEs, int waitingInEs)
        {
            this.priority = priority;
            this.name = name;
            this.cpuTime = cpuTime;
            this.timeWaiting = 0;
            this.waitingEs = waitingEs;
            this.waitingInEs = waitingInEs;

            processList.Add(this);
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int CpuTime
        {
            get
            {
                return this.cpuTime;
            }
        }



        public int TimeWaiting
        {
            get
            {
                return this.timeWaiting;
            }
            set
            {
                this.timeWaiting = value;
            }
        }
    }
}