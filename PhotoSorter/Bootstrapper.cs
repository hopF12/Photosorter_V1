using Autofac;

namespace PhotoSorter
{
    public class Bootstrapper
    {
        private static Bootstrapper _instance;
        private static readonly object IsLocked = new object();

        private Bootstrapper()
        {}

        public void SetupContainer()
        {
            var builder = new ContainerBuilder();

            Container = builder.Build();
        }

        public IContainer Container { get; private set; }

        public static Bootstrapper Instance
        {
            get
            {
                if (_instance is null)
                    lock (IsLocked)
                        if (_instance is null)
                            _instance = new Bootstrapper();

                return _instance;
            }
        }
    }
}