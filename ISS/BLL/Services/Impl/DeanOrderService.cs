using BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Impl
{
    class DeanOrderService : IDeanOrderService
    {
        string text;
        public DeanOrderService(string text_)
        {
            text = text_;
        }

        public void print()
        {
            Console.WriteLine("Наказ декана");
            Console.WriteLine(text);
        }
    }
}
