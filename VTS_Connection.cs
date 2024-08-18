using System;

namespace LiveSplit.VTS
{
	public class VTS_Connection
	{
		private static VTS_Connection instance;
		public bool Connected { get; private set; } = false;

		public static VTS_Connection GetInstance()
		{
			if (instance == null)
			{
				instance = new VTS_Connection();
				return instance;
			}

			return instance;
		}

		public void Connect()
		{
			if (!Connected)
			{

			}
		}
	}
}
