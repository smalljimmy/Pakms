using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel;

namespace PaK_v1._0.utilities
{
    public class VMBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string property)        
        { 
            PropertyChanged(this, new PropertyChangedEventArgs(property)); 
        }

        [TypeDescriptionProvider(typeof(CommandMapDescriptionProvider))]
        public class CommandMap
        {
            public void AddCommand(string commandName, Action<object> executeMethod)
            {
                Commands[commandName] = new DelegateCommand(executeMethod); 
            }

            public void AddCommand(string commandName, Action<object> executeMethod, Predicate<object> canExecuteMethod)
            { 
                Commands[commandName] = new DelegateCommand(executeMethod, canExecuteMethod); 
            }

            public void AddCommand(string commandName, DelegateCommand delegateCommand)
            {
                Commands[commandName] = delegateCommand; 
            }

            public void RemoveCommand(string commandName) { 
                Commands.Remove(commandName); 
            }
            protected Dictionary<string, ICommand> Commands
            { 
                get { if (null == _commands) 
                { 
                    _commands = new Dictionary<string, ICommand>(); } return _commands; 
                } 
            }

            private Dictionary<string, ICommand> _commands;

            private class CommandMapDescriptionProvider : TypeDescriptionProvider
            {
                public CommandMapDescriptionProvider() : this(TypeDescriptor.GetProvider(typeof(CommandMap))) { }

                public CommandMapDescriptionProvider(TypeDescriptionProvider parent) : base(parent) { }

                public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
                { 
                    return new CommandMapDescriptor(base.GetTypeDescriptor(objectType, instance), instance as CommandMap); 
                }
            }

            private class CommandMapDescriptor : CustomTypeDescriptor
            {
                public CommandMapDescriptor(ICustomTypeDescriptor descriptor, CommandMap map) : base(descriptor) { _map = map; }

                public override PropertyDescriptorCollection GetProperties()
                {
                    PropertyDescriptor[] props = new PropertyDescriptor[_map.Commands.Count];
                    int pos = 0; foreach (KeyValuePair<string, ICommand> command in _map.Commands)
                        props[pos++] = new CommandPropertyDescriptor(command);
                    return new PropertyDescriptorCollection(props);
                }

                private CommandMap _map;
            }

            private class CommandPropertyDescriptor : PropertyDescriptor
            {
                public CommandPropertyDescriptor(KeyValuePair<string, ICommand> command)
                    : base(command.Key, null)
                { 
                    _command = command.Value; 
                }

                public override bool IsReadOnly { 
                    get { return true; } 
                }

                public override bool CanResetValue(object component) { return false; }

                public override Type ComponentType 
                { 
                    get { throw new NotImplementedException(); } 
                }

                public override object GetValue(object component)
                {
                    CommandMap map = component as CommandMap;
                    if (null == map) { throw new ArgumentException("component is not a CommandMap instance", "component"); }
                    return map.Commands[this.Name];
                }
                public override Type PropertyType { get { return typeof(ICommand); } }

                public override void ResetValue(object component) { throw new NotImplementedException(); }

                public override void SetValue(object component, object value) { throw new NotImplementedException(); }

                public override bool ShouldSerializeValue(object component) { return false; }

                private ICommand _command;
            }
        }
    }

}
