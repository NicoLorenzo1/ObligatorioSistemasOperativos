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
        public int blokingOnTime; //tiempo que paso en espera


        public bool owner;

        public int count;

        public Proceso(string name, int cpuTime, int priority, int waitingEs, int waitingInEs, bool owner)
        {
            this.priority = priority;
            this.name = name;
            this.cpuTime = cpuTime;
            this.timeWaiting = 0;
            this.waitingEs = waitingEs;
            this.waitingInEs = waitingInEs;
            this.owner = owner;

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
            set
            {
                this.cpuTime = value;
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