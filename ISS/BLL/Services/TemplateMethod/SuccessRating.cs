using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.TemplateMethod
{
    class SuccessRating : AbstractClass
    {
        Queue<string> rating = new Queue<string>();


        void add(string full_name)
        {
            rating.Enqueue(full_name);
        }


        public override void header()
        {
            Console.WriteLine("Рейтинг успішності");
        }
        public override void info()
        {
            foreach (string full_name in rating)
            {
                Console.WriteLine(full_name);
            }
        }

    }
}
