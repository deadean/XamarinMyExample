using System;
using PhotoTransfer.UI.Common.Bases;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace MainApp.UI.Common.VVms
{
	public class PageWorkingWithFilesVm: AdvancedPageViewModelBase, IPageWorkingWithFilesVm
	{
		#region Fields

		private const int _max = 10;

		#endregion

		#region Events

		#endregion

		#region Properties

		#endregion

		#region Bindable Properties

		#endregion

		#region Commands

		public ICommand RunUsingAwaitCommand{ get; private set;}
		public ICommand RunCallingFuncCommand{ get; private set;}
		public ICommand RunUsingTaskRunCommand{ get; private set;}
		public ICommand RunUsingTaskRunAndAwaitCommand{ get; private set;}

		#endregion

		#region Ctor

		public PageWorkingWithFilesVm ()
		{
			RunUsingAwaitCommand = new Command (OnRunUsingAwaitCommand);
			RunCallingFuncCommand = new Command (OnRunCallingFuncCommand);
			RunUsingTaskRunCommand = new Command (OnRunUsingTaskRunCommand);
			RunUsingTaskRunAndAwaitCommand = new Command (OnRunUsingTaskRunAndAwaitCommand);
		}

		#endregion

		#region Public Methods

		#endregion

		#region Private Methods

		private async Task LongRunningFunction()
		{
			for (int i = 0; i < _max; i++) {
				await Task.Delay (1000);
				System.Diagnostics.Debug.WriteLine ("Step :"+i);
			}
		}

		private void LongRunningFunctionSimple()
		{
			for (int i = 0; i < _max; i++) {
				System.Diagnostics.Debug.WriteLine ("Step :"+i);
			}
		}

		#endregion

		#region Protected Methods

		#endregion

		#region Commands Execute Handlers

		private async void OnRunUsingAwaitCommand()
		{
			System.Diagnostics.Debug.WriteLine ("Start OnRunUsingAwaitCommand");
			await LongRunningFunction ();
			System.Diagnostics.Debug.WriteLine ("Stop OnRunUsingAwaitCommand");
		}

		private void OnRunCallingFuncCommand()
		{
			System.Diagnostics.Debug.WriteLine ("Start OnRunCallingFuncCommand");
			LongRunningFunction ();
			System.Diagnostics.Debug.WriteLine ("Stop OnRunCallingFuncCommand");
		}

		private void OnRunUsingTaskRunCommand()
		{
			System.Diagnostics.Debug.WriteLine ("Start OnRunUsingTaskRunCommand");
			Task.Run(async ()=>await LongRunningFunction ());
			System.Diagnostics.Debug.WriteLine ("Stop OnRunUsingTaskRunCommand");
		}

		private void OnRunUsingTaskRunAndAwaitCommand()
		{
			System.Diagnostics.Debug.WriteLine ("Start OnRunUsingTaskRunAndAwaitCommand");
			Task.Run (async () => await LongRunningFunction ());
			System.Diagnostics.Debug.WriteLine ("Stop OnRunUsingTaskRunAndAwaitCommand");
		}

		#endregion

	}
}

