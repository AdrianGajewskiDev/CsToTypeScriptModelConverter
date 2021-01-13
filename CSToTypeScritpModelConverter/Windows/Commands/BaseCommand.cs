using System;
using System.Windows.Input;

namespace CSToTypeScritpModelConverter.Windows.Commands
{
    public class BaseCommand : ICommand
    {
        private Action m_Action;


        public BaseCommand(Action action)
        {
            m_Action = action;
        }


        public event EventHandler CanExecuteChanged = (s,e) => { };

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_Action();
        }
    }
}
