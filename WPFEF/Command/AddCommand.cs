using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFEF.WCFService;

namespace WPFEF.Command
{
	class AddCommand : ICommand
	{
		private Action<object> execute;

		public AddCommand(Action<object> execute)
		{
			this.execute = execute;
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			this.execute(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}
	}
}
