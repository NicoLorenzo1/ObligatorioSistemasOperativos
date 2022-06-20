namespace Library
{
    public class Proceso
    {
        private string name;
        private int cpuTime;
        public int priority;
        private int timeWaiting;
        public int ioTime; //cada cuanto tiempo requiere entrada salida
        public int ioRequiredTime; //tiempo que demora mientras hace la entrada salida
        public int ioCounter; //contador de E/S

        public bool owner;
  
        public Proceso(string name, int cpuTime, int priority, int ioTime, int ioRequiredTime, bool owner)
        {
            this.priority = priority;
            this.name = name;
            this.cpuTime = cpuTime;
            this.timeWaiting = 0;
            this.ioTime = ioTime;
            this.ioRequiredTime = ioRequiredTime;
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