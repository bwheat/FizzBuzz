using Lamar;

namespace FizzBuzz.DependencyInjection
{
    public class DefaultRegistry : ServiceRegistry
    {
        private static DefaultRegistry _registry;

        protected DefaultRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();

                scan.AssembliesFromApplicationBaseDirectory(
                    assembly => assembly.FullName.StartsWith("FizzBuzz"));

                scan.WithDefaultConventions();
            });
        }

        public static DefaultRegistry GetRegistry()
        {
            return _registry ??= new DefaultRegistry();
        }
    }
}