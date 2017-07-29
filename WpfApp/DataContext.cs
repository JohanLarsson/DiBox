namespace WpfApp
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using Ninject;

    public static class DataContext
    {
        public static readonly DependencyProperty TypeProperty = DependencyProperty.RegisterAttached(
            "Type",
            typeof(Type),
            typeof(DataContext),
            new PropertyMetadata(
                default(Type),
                OnTypeChanged));

        public static void SetType(DependencyObject element, Type value)
        {
            element.SetValue(TypeProperty, value);
        }

        public static Type GetType(DependencyObject element)
        {
            return (Type)element.GetValue(TypeProperty);
        }

        private static void OnTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d))
            {
                return;
            }

            if (e.NewValue is Type type)
            {
                d.SetValue(FrameworkElement.DataContextProperty, App.Kernel?.Get(type));
            }
            else
            {
                d.ClearValue(FrameworkElement.DataContextProperty);
            }
        }
    }
}
