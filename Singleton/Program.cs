using System;
using System.Threading;

namespace Singleton
{
    /// <summary>
    /// Singleton
    /// </summary>
    class OS
    {
        private static OS _instance;
        public string Name { get; private set; }
        protected OS(string name)
        {
            this.Name = name;
        }

        // Объект для блокировки потоков.
        private static readonly object _lock = new object();

        public static OS GetInstance(string name)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new OS(name);
                    }
                }
            }
            return _instance;
        }
    }

    class Computer
    {
        public OS OS { get; set; }

        public void Launch(string osName)
        {
            OS = OS.GetInstance(osName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread process1 = new Thread(() =>
            {
                Computer comp2 = new Computer();
                comp2.OS = OS.GetInstance("Windows 10");
                Console.WriteLine(comp2.OS.Name);
            });
            process1.Start();

            Computer comp = new Computer();
            comp.Launch("Linux kali");
            Console.WriteLine(comp.OS.Name);
        }
    }
}
