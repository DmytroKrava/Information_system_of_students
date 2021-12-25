namespace BLL.Services.ClassesForHelp
{
    public abstract class Component
    {
        public string Name { get; set; }

        protected Component(string name)
        {
            Name = name;
        }

        public abstract void Show();
        public abstract void Add(Component component);
        public abstract void Remove(Component component);
    }
}