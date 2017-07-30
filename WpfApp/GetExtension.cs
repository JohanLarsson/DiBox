namespace WpfApp
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Markup;

    using Ninject;

    public class GetExtension : MarkupExtension
    {
        private static readonly DependencyObject DependencyObject = new DependencyObject();

        public GetExtension(Type type)
            : this(type, false)
        {
        }

        public GetExtension(Type type, bool isDesignTimeCreatable)
        {
            this.Type = type;
            this.IsDesignTimeCreatable = isDesignTimeCreatable;
        }

        private static bool IsInDesignMode => DesignerProperties.GetIsInDesignMode(DependencyObject);

        [ConstructorArgument("type")]
        public Type Type { get; set; }

        [ConstructorArgument("isDesignTimeCreatable")]
        public bool IsDesignTimeCreatable { get; set; } = false;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Type == null ||
                (!this.IsDesignTimeCreatable && IsInDesignMode))
            {
                return null;
            }

            return App.Kernel?.Get(this.Type);
        }
    }
}
