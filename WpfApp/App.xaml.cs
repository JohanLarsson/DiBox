namespace WpfApp
{
    using System.Windows;
    using Ninject;

    public partial class App : Application
    {
        public static IKernel Kernel { get; } = CreateKernel();

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Foo>().ToSelf().InSingletonScope();
            return kernel;
        }
    }
}
