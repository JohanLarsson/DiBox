namespace WpfApp
{
    using System.Windows;
    using Ninject;

    public partial class App : Application
    {
        public static IKernel Kernel { get; } = new StandardKernel();
    }
}
