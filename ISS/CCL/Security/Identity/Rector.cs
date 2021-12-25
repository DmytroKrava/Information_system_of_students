using System;
using System.Collections.Generic;
using System.Text;

namespace ISS.Security.Identity
{
    class Rector
    {
        private static Rector instance;
        private static object syncRoot = new Object();
        public string Name { get; }
        public string Surname { get; }

        private Rector(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public static Rector getInstance(string name, string surname)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Rector(name, surname);
                    }
                }
            }

            return instance;
        }
    }
}
