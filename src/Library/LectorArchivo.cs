namespace Library
{
    public class LectorArchivo
    {
        public static List<Proceso> Read(String path)
        {
            List<Proceso> list = new List<Proceso>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                int n = 0;
                while ((line = reader.ReadLine()) != null)
                {
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

                        Proceso process = new Proceso(name, cpu, priority, wait, waitEs, owner);
                        list.Add(process);
                    }
                }
                return list;
            }
        }
    }
}