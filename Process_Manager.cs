using System.Collections;
using System.Diagnostics;

namespace ex3
{
    public class Process_Manager
    {
        private List<Process> listProcess;

        public Process_Manager()
        {
            this.listProcess = new List<Process>();
        }
        public void addProcess(Process ps)
        {
            listProcess.Add(ps);
        }

        public int killProcessByPath(string path)
        {
            int counter = 0;
            foreach (Process item in listProcess.ToList())
            {
                if (item.MainModule != null && item.MainModule.FileName.Equals(path))
                {
                    listProcess.Remove(item);
                    counter++;
                    item.Kill(true);
                }

                item.WaitForExit();
            }

            return counter;
        }

        public string getAllProcessPaths()
        {
            ArrayList listNames = new ArrayList();

            foreach (Process item in listProcess)
            {
                if (item.MainModule != null)
                    listNames.Add(item.MainModule.FileName);
            };

            return string.Join(" , ", listNames.ToArray());
        }
    }
}