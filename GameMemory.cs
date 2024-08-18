using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace LiveSplit.VTS
{
	class GameMemory
	{
		public event EventHandler OnFirstLevelLoading;
		public event EventHandler OnPlayerGainedControl;
		public event EventHandler OnLoadStarted;
		public event EventHandler OnLoadFinished;

		private CancellationTokenSource _cancelSource;
		private SynchronizationContext _uiThread;
		private List<int> _ignorePIDs;
		private VTSSettings _settings;

		public bool[] splitStates { get; set; }

		public GameMemory(VTSSettings componentSettings)
		{
			_settings = componentSettings;

			_ignorePIDs = new List<int>();
		}

		public void StartMonitoring()
		{
			if (!(SynchronizationContext.Current is WindowsFormsSynchronizationContext))
			{
				throw new InvalidOperationException("SynchronizationContext.Current is not a UI thread.");
			}

			_uiThread = SynchronizationContext.Current;
			_cancelSource = new CancellationTokenSource();
		}

		public void Stop()
		{
			if (_cancelSource == null)
			{
				return;
			}

			_cancelSource.Cancel();
		}
	}
}
