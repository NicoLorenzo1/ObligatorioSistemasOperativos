using System;

namespace Library
{
    public class Proceso
    {
        private string name;
        private int cpuTime;
        public int priority;
        private int timeWaiting;
        public static List<Proceso> processList = new List<Proceso>();

        public Proceso(string name, int cpuTime, int priority)
        {
            this.priority = priority;
            this.name = name;
            this.cpuTime = cpuTime;
            this.timeWaiting = 0;
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