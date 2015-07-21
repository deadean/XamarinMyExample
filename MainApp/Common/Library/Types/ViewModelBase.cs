namespace Library.Types
{
	using GalaSoft.MvvmLight;
	using System;
	using System.Diagnostics;
	using System.Threading;

	public interface INotifyPropertyChangedWithRaise
	{
		void RaisePropertyChanged1(string propertyName);
	}

	/// <summary>
	///   Base class for ViewModel pattern implementation
	/// </summary>
	public class ViewModelBaseCommon : ViewModelBase, IViewModel, INotifyPropertyChangedWithRaise
	{
		#region Fields

		private string mvToken;

		#endregion // Fields

		#region Properties

		/// <summary>
		///   Sets the messanger token to send messages
		/// </summary>
		public string Token
		{
			protected get { return mvToken; }
			set
			{
				if (mvToken == value)
					return;

				mvToken = value;
			}
		}

		#endregion // Properties

		#region Events

		#endregion // Events

		#region Public Methods

		public void RaisePropertyChanged1(string propertyName)
		{
			this.RaisePropertyChanged(propertyName);
			//OnPropertyChanged(propertyName);
		}

		public virtual void RefreshCommands() { }

		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			//// Verify that the property name matches a real,  
			//// public, instance property on this object.
			//if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			//{
			//	string msg = "Invalid property name: " + propertyName;

			//	throw new Exception(msg);
			//}
		}

		#endregion // Public Methods

		#region Protected Methods

		protected void Invoke(Action actionToExecute)
		{
			if (actionToExecute == null)
				return;

			actionToExecute();
		}

		protected void Invoke<TParameter>(TParameter parameter, Action<TParameter> actionToExecute)
		{
			if (actionToExecute == null)
				return;

			actionToExecute(parameter);
		}

		protected TResult Invoke<TResult>(Func<TResult> actionToExecute)
		{
			if (actionToExecute == null)
				return default(TResult);

			return actionToExecute();
		}

		protected TResult InvokeWithLock<TResult>(object synchronizationObject, Func<TResult> actionToExecute)
		{
			if (synchronizationObject == null || actionToExecute == null)
				return default(TResult);

			lock (synchronizationObject)
			{
				return actionToExecute();
			}
		}

		protected virtual void OnDispatcherChanged() { }

		protected virtual bool TryInvokeWithLock(object synchronizingObject, Action actionToExecute)
		{
			if (synchronizingObject == null || actionToExecute == null)
				return false;

			var isEnter = Monitor.TryEnter(synchronizingObject);

			if (isEnter)
			{
				try
				{
					actionToExecute();
				}
				catch (Exception)
				{
				}
				finally
				{
					Monitor.Exit(synchronizingObject);
				}
			}

			return isEnter;
		}

		#endregion // Protected Methods
	}
}