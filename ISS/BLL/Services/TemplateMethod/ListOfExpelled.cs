using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.TemplateMethod
{
    class ListOfExpelled : AbstractClass
    {
        List<string> expelled = new List<string>();

        void add(string full_name)
        {
            expelled.Add(full_name);
        }


        public override void header()
        {
            Console.WriteLine("Список відрахованих");
        }
        public override void info()
        {
            foreach (string full_name in expelled)
            {
                Console.WriteLine(full_name);
            }
        }
    }
}
