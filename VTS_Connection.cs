using System.Diagnostics;
using System.Threading.Tasks;
using VTS.Core;


namespace LiveSplit.VTS
{
	public class VTS_Connection
	{
		private static VTS_Connection instance;
		public ConsoleVTSLoggerImpl Logger { get; private set; }
		public CoreVTSPlugin Plugin { get; private set; }
		//HostApplicationBuilder builder = Host.CreateApplicationBuilder(args); // Create a host builder so the program doesn't exit immediately

		public bool Connected { get; private set; } = false;
		public bool IsAutheniticated => Plugin != null ? Plugin.IsAuthenticated : false;

		public static VTS_Connection GetInstance()
		{
			if (instance == null)
			{
				instance = new VTS_Connection();
				instance.Logger = new ConsoleVTSLoggerImpl(); // Create a logger to log messages to the console (you can use your own logger implementation here like in the Advanced example)
				instance.Plugin = new CoreVTSPlugin(instance.Logger, 100, "LiveSplit-VTS", "SuiMachine", "");
				return instance;
			}

			return instance;
		}

		public async Task Connect()
		{
			if (!Connected)
			{
				try
				{
					await Plugin.InitializeAsync(new WebSocketImpl(Logger),	new NewtonsoftJsonUtilityImpl(), new TokenStorageImpl(""), () => Logger.LogWarning("Disconnected!"));
					Logger.Log("Connected!");
					Connected = true;
					var apiState = await Plugin.GetAPIState();

					Logger.Log("Using VTubeStudio " + apiState.data.vTubeStudioVersion);
					var currentModel = await Plugin.GetCurrentModel();
					Debug.WriteLine("Kurwa");

					Logger.Log("The current model is: " + currentModel.data.modelName);

					// Subscribe to your events here using the plugin.SubscribeTo* methods
					await Plugin.SubscribeToBackgroundChangedEvent((backgroundInfo) =>
					{
						Logger.Log($"The background was changed to: {backgroundInfo.data.backgroundName}");
					});
					// To unsubscribe, use the plugin.UnsubscribeFrom* methods
				}
				catch (VTSException error)
				{
					Connected = false;
					Logger.LogError(error); // Log any errors that occur during initialization
				}
			}
		}

		public async Task Disconnect()
		{
			if(Connected && Plugin.IsAuthenticated)
			{
				var apiState = await Plugin.GetAPIState();

			}
		}
	}
}
