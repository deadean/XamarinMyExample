namespace Library.Types
{
	using Commands;
	using Extensions;
	using System;
	using System.Diagnostics;

	/// <summary>
	///   Represents 
	/// </summary>
	public abstract class AdvancedViewModelBase : ViewModelBaseCommon
	{
		#region Fields
		private readonly object mvSyncRoot = new object();

		private bool mvCanChange;

		private bool mvIsBlocked;
		private bool mvIsBusy;
		private bool mvIsCancelPending;
		private bool mvIsCleaning;
		private bool mvIsEnabled;

		#endregion // Fields

		#region Ctor

		protected AdvancedViewModelBase()
			: this(false)
		{

		}

		protected AdvancedViewModelBase(bool isEnabled)
		{
			mvIsEnabled = isEnabled;
			mvCanChange = true;

			RefreshCommand = new DelegateCommand(Refresh, CanRefresh);
		}

		#endregion // Ctor

		#region Properties

		public bool CanChange
		{
			[DebuggerStepThrough]
			get { return mvCanChange; }
			private set
			{
				if (mvCanChange == value)
					return;

				mvCanChange = value;
				this.OnPropertyChanged();

				if (mvCanChange)
				{
					OnActivated();
				}
				else
				{
					OnFreezed();
				}
			}
		}

		public bool IsBlocked
		{
			[DebuggerStepThrough]
			get { return mvIsBlocked; }
			set
			{
				if (mvIsBlocked == value)
					return;

				mvIsBlocked = value;
				this.OnPropertyChanged();
			}
		}

		/// <summary>
		///   Gets value indicating some operation is executing at the moment
		/// </summary>
		public bool IsBusy
		{
			get { return mvIsBusy; }
			protected set
			{
				if (mvIsBusy == value)
					return;

				mvIsBusy = value;
				this.OnPropertyChanged();

				RefreshCommands();
			}
		}

		/// <summary>
		/// Gets value indicating current operation cancel request
		/// </summary>
		public virtual bool IsCancelPending
		{
			get { return mvIsCancelPending; }
			protected set
			{
				if (mvIsCancelPending == value)
					return;

				mvIsCancelPending = value;
				this.OnPropertyChanged();

				if (mvIsCancelPending)
				{
					OnCancelPending();
				}
			}
		}

		public bool IsCleaning
		{
			get { return mvIsCleaning; }
			private set
			{
				if (mvIsCleaning == value)
					return;

				mvIsCleaning = value;
				this.OnPropertyChanged();
			}
		}

		public bool IsEnabled
		{
			get { return mvIsEnabled; }
			set
			{
				if (mvIsEnabled == value)
					return;

				mvIsEnabled = value;
				this.OnPropertyChanged();

				OnIsEnabledChanged();
			}
		}

		/// <summary>
		///   Gets synchronized object
		/// </summary>
		protected object SyncRoot
		{
			get { return mvSyncRoot; }
		}

		#endregion // Properties

		#region Commands

		public DelegateCommand RefreshCommand { get; private set; }

		#endregion // Commands

		#region Command Can Execute Handlers

		public virtual bool CanRefresh()
		{
			return !IsBusy;
		}

		#endregion // Command Can Execute Handlers

		#region Command Execute Handlers

		protected virtual void OnActivated() { }

		protected virtual void OnFreezed() { }

		protected virtual void RefreshPrivate() { }

		#endregion // Command Execute Handlers

		#region Public Methods

		public void Activate()
		{
			if (CanChange)
				return;

			CanChange = true;
		}

		public void Clean()
		{
			if (IsCleaning)
				return;

			try
			{
				IsCleaning = true;

				Interrupt();
				CleanPrivate();


				Token = null;
			}
			catch (Exception)
			{
			}
			finally
			{
				IsCancelPending = false;
				IsCleaning = false;
			}
		}

		public void Freeze()
		{
			if (CanChange)
			{
				CanChange = false;
			}
		}

		public void Interrupt()
		{
			IsCancelPending = true;
		}

		public void Refresh()
		{
			try
			{
				if (CanRefresh())
				{
					IsBusy = true;

					RefreshPrivate();
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				IsBusy = false;
			}
		}

		#endregion // Public Methods

		#region Protected Methods

		protected virtual void CleanPrivate()
		{

		}

		protected TResult InvokeWithLock<TResult>(Func<TResult> actionToExecute)
		{
			if (actionToExecute == null)
				return default(TResult);

			lock (SyncRoot)
			{
				return actionToExecute();
			}
		}

		protected virtual void OnCancelPending() { }

		protected virtual void OnIsEnabledChanged()
		{
			if (IsEnabled)
			{
				IsCancelPending = false;

				Refresh();
			}
			else
			{
				IsCancelPending = true;
			}
		}

		protected void WaitFor(Action action)
		{
			if (action == null)
				return;

			try
			{
				action();
			}
			finally
			{
			}
		}

		[DebuggerStepThrough]
		protected void WithLock(Action action)
		{
			if (action == null)
				return;

			lock (SyncRoot)
			{
				action();
			}
		}

		[DebuggerStepThrough]
		protected TResult WithLock<TResult>(Func<TResult> func)
		{
			if (func == null)
				return default(TResult);

			lock (SyncRoot)
			{
				return func();
			}
		}

		#endregion // Protected Methods

		#region Methods Override

		/// <summary>
		///   Refreshes UI Command Elements IsEnabled state
		/// </summary>
		public override void RefreshCommands()
		{
			base.RefreshCommands();
		}

		#endregion // Methods Override
	}
}