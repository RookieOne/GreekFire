using System.Windows;
using System.Windows.Input;

namespace GreekFire.Client.Infrastructure.Behaviors
{
    /// <summary>
    /// Double Click Command Behavior.
    /// Is a attached dependency property where you attach a command to execute upon the dependency object
    /// (control) being 'double clicked'
    /// </summary>
    public static class DoubleClickCommandBehavior
    {
        public static readonly DependencyProperty DoubleClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommandParameter",
                                                typeof (object), typeof (DoubleClickCommandBehavior),
                                                new PropertyMetadata(null));

        public static readonly DependencyProperty DoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("DoubleClickCommand",
                                                typeof (ICommand), typeof (DoubleClickCommandBehavior),
                                                new PropertyMetadata(null, DoubleClickCommandChanged));

        public static ICommand GetDoubleClickCommand(DependencyObject obj)
        {
            return (ICommand) obj.GetValue(DoubleClickCommandProperty);
        }

        public static void SetDoubleClickCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DoubleClickCommandProperty, value);
        }

        public static object GetDoubleClickCommandParameter(DependencyObject obj)
        {
            return obj.GetValue(DoubleClickCommandParameterProperty);
        }

        public static void SetDoubleClickCommandParameter(DependencyObject obj, object value)
        {
            obj.SetValue(DoubleClickCommandParameterProperty, value);
        }

        private static void DoubleClickCommandChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var element = obj as FrameworkElement;

            if (element != null)
                element.PreviewMouseLeftButtonDown += HandlePreviewMouseLeftButtonDown;
        }

        private static void HandlePreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.ClickCount == 2)
            {
                var depObj = sender as DependencyObject;

                if (depObj != null)
                {
                    ICommand command = GetDoubleClickCommand(depObj);
                    object commandParameter = GetDoubleClickCommandParameter(depObj);

                    command.Execute(commandParameter);
                }
            }
        }
    }
}