namespace DiBox
{
    using Ninject;
    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void GetFoo()
        {
            var kernel = new StandardKernel();
            // Ninject wires up the bindings for classes automatically.
            // Put breakpoints in the ctors of foo and bar and step through the call below.
            var foo = kernel.Get<Foo>();
        }
    }

    public class Foo
    {
        public Foo(Bar bar)
        {
            this.Bar = bar;
        }

        public Bar Bar { get; }
    }

    public class Bar
    {
    }
}
