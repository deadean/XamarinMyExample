using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.Commands
{
	public class AsyncCommand : ICommand
	{
		Func<bool> modCanExecutePredicate;
		Func<Task> modAsyncHandler;

		public AsyncCommand(Func<Task> asyncHandler, Func<bool> canExecutePredicate)
		{
			modCanExecutePredicate = canExecutePredicate;
			modAsyncHandler = asyncHandler;
		}

		public AsyncCommand(Func<Task> asyncHandler)
		{
			modAsyncHandler = asyncHandler;
		}

		public bool CanExecute(object parameter)
		{
			return modCanExecutePredicate == null || modCanExecutePredicate();
		}

		public async void Execute(object parameter)
		{
			if (modAsyncHandler != null)
			{
				await modAsyncHandler();
			}
		}

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged()
		{
			var handler = CanExecuteChanged;

			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}
	}

	public class AsyncCommand<T> : ICommand
	{
		Func<T, bool> modCanExecutePredicate;
		Func<T, Task> modAsyncHandler;

		public AsyncCommand(Func<T, Task> asyncHandler, Func<T, bool> canExecutePreditcate)
		{
			modCanExecutePredicate = canExecutePreditcate;
			modAsyncHandler = asyncHandler;
		}

		public AsyncCommand(Func<T, Task> asyncHandler)
		{
			modAsyncHandler = asyncHandler;
		}

		public bool CanExecute(object parameter)
		{
			return modCanExecutePredicate == null || modCanExecutePredicate((T)parameter);
		}

		public async void Execute(object parameter)
		{
			if (modAsyncHandler != null)
			{
				await modAsyncHandler((T)parameter);
			}
		}

		public event EventHandler CanExecuteChanged;

		public void RaiseCanExecuteChanged()
		{
			var handler = CanExecuteChanged;

			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}
	}
}
