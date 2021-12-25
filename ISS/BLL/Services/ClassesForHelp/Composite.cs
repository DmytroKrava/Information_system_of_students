using System;
using System.Collections.Generic;

namespace BLL.Services.ClassesForHelp
{
    class Composite : Component
    {
        List<Component> students = new List<Component>();

        public Composite(string name)
            : base(name)
        { }


        public override void Show()
        {
            Console.WriteLine(Name);

            foreach (Component component in students)
            {
                component.Show();
            }
        }
        public override void Add(Component component)
        {
            students.Add(component);
        }
        public override void Remove(Component component)
        {
            students.Remove(component);
        }
    }
}