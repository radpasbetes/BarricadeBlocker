using System;
using System.Collections.Generic;
using Rocket.API;

namespace VehicleBarricadeBlocker
{
	// Token: 0x02000002 RID: 2
	public class Configuration : IRocketPluginConfiguration, IDefaultable
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
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

		// Token: 0x04000001 RID: 1
		public bool SendWarning;

		// Token: 0x04000002 RID: 2
		public string WarningMessage;

		// Token: 0x04000003 RID: 3
		public List<ushort> AllowedBarricadeIDs;

		// Token: 0x04000004 RID: 4
		public bool AdminBypass;
	}
}
