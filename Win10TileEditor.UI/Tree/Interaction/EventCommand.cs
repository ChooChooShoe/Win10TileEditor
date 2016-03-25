using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace Win10TileEditor.Tree.Interaction {
    public static class EventCommand {
        private static readonly MethodInfo HandlerMethod = typeof(EventCommand).GetMethod("OnEvent", BindingFlags.NonPublic | BindingFlags.Static);

        public static readonly DependencyProperty EventProperty = DependencyProperty.RegisterAttached("Event", typeof(RoutedEvent), typeof(EventCommand), new PropertyMetadata(null, OnEventChanged));
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(EventCommand), new PropertyMetadata(null));

        public static void SetEvent(DependencyObject owner, RoutedEvent value) {
            owner.SetValue(EventProperty, value);
        }

        public static RoutedEvent GetEvent(DependencyObject owner) {
            return (RoutedEvent)owner.GetValue(EventProperty);
        }

        public static void SetCommand(DependencyObject owner, ICommand value) {
            owner.SetValue(CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject owner) {
            return (ICommand)owner.GetValue(CommandProperty);
        }

        private static void OnEventChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            if (e.OldValue != null) {
                var @event = d.GetType().GetEvent(((RoutedEvent)e.OldValue).Name);
                @event.RemoveEventHandler(d, Delegate.CreateDelegate(@event.EventHandlerType, HandlerMethod));
            }

            if (e.NewValue != null) {
                var @event = d.GetType().GetEvent(((RoutedEvent)e.NewValue).Name);
                @event.AddEventHandler(d, Delegate.CreateDelegate(@event.EventHandlerType, HandlerMethod));
            }
        }

        private static void OnEvent(object sender, EventArgs args) {
            var command = GetCommand((DependencyObject)sender);
            if (command != null && command.CanExecute(null))
                command.Execute(null);
        }
    }
}
