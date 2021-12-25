using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.ClassesForHelp
{
    class Student : Component
    {
        public string Surname { get; set; }
        protected Student(string name, string surname) : base(name)
        {
            this.Surname = surname;
        }

        public override void Show()
        {
            Console.WriteLine(this.Surname);
            Console.WriteLine(this.Name);
        }
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }
        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
