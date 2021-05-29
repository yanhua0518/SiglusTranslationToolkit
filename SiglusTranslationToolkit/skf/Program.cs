using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skf
{
    class Program
    {
        static int GetPID()
        {
            while (true)
            {
                string Name="";
                Process[] Procs = Process.GetProcesses();
                foreach (Process Proc in Procs)
                {
                    Name = Proc.ProcessName;
                    if (Name.Contains("SiglusEngine"))
                    {
                        return Proc.Id;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
//            System.Console.WriteLine("Please run a siglus engine exe. The process name must contain 'SiglusEngine'.");
//            System.Console.WriteLine("Process Finding...");
            int PID = GetPID();
            if (PID != -1)
            {
//                System.Console.WriteLine("Process Found.");
//                System.Console.WriteLine("Keys Finding...");
                SiglusKeyFinder.KeyFinder.Key[] Keys = SiglusKeyFinder.KeyFinder.ReadProcess(PID);
                string MSG = "";
                foreach (SiglusKeyFinder.KeyFinder.Key Key in Keys)
                        MSG += Key.KeyStr;
                if (MSG != "")
                {
                    System.Console.WriteLine(MSG);
                }
                else
                {
                    System.Console.WriteLine("Error!");
                }
          	}
        }
    }
}
