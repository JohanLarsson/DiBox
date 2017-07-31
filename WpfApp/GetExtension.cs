namespace WpfApp
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Markup;

    using Ninject;

    [MarkupExtensionReturnType(typeof(object))]
    public class GetExtension : MarkupExtension
    {
        private static readonly DependencyObject DependencyObject = new DependencyObject();

        public GetExtension()
        {
        }

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
            if (this.Type == null)
            {
                return null;
            }

            if (IsInDesignMode)
            {
                if (IsDesignTimeCreatable)
                {
                    return App.Kernel?.Get(this.Type);
                }

                return null;
            }
            else
            {
                return App.Kernel?.Get(this.Type);
            }
        }
    }
}
