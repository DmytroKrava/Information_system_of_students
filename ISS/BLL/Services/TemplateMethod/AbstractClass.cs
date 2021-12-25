using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.TemplateMethod
{
    abstract class AbstractClass
    {
        public void showInfo()
        {
            header();
            info();
        }

        public abstract void header();
        public abstract void info();
    }
}