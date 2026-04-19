using System;
using System.Collections.Generic;
using Rocket.API;

namespace VehicleBarricadeBlocker
{
	public class Configuration : IRocketPluginConfiguration, IDefaultable
	{
		public void LoadDefaults()
		{
			this.SendWarning = true;
			this.WarningMessage = "Blocked!";
			this.AllowedBarricadeIDs = new List<ushort>
			{
				123,
				456
			};
			this.AdminBypass = true;
		}

		public bool SendWarning;

		public string WarningMessage;

		public List<ushort> AllowedBarricadeIDs;

		public bool AdminBypass;
	}
}
