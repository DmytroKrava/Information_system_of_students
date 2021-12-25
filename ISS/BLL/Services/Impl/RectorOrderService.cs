using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Impl
{
    public class RectorOrderService : IRectorOrderService
    {
        string text;
        public RectorOrderService(string text_)
        {
            text = text_;
        }

        public void show()
        {
            Console.WriteLine("Наказ ректора");
            Console.WriteLine(text);
        }
    }
}
