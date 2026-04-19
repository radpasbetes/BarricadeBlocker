using System;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace VehicleBarricadeBlocker
{
	// Token: 0x02000003 RID: 3
	public class Main : RocketPlugin<Configuration>
	{
		// Token: 0x06000003 RID: 3 RVA: 0x00002091 File Offset: 0x00000291
		protected override void Load()
		{
			BarricadeManager.onDeployBarricadeRequested = (DeployBarricadeRequestHandler)Delegate.Combine(BarricadeManager.onDeployBarricadeRequested, new DeployBarricadeRequestHandler(this.OnBarricadeDeployRequested));
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020B3 File Offset: 0x000002B3
		protected override void Unload()
		{
			BarricadeManager.onDeployBarricadeRequested = (DeployBarricadeRequestHandler)Delegate.Remove(BarricadeManager.onDeployBarricadeRequested, new DeployBarricadeRequestHandler(this.OnBarricadeDeployRequested));
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020D8 File Offset: 0x000002D8
		private void OnBarricadeDeployRequested(Barricade barricade, ItemBarricadeAsset asset, Transform hit, ref Vector3 point, ref float angle_x, ref float angle_y, ref float angle_z, ref ulong owner, ref ulong group, ref bool shouldAllow)
		{
			try
			{
				if (!(hit == null))
				{
					if (!(hit.GetComponentInParent<InteractableVehicle>() == null))
					{
						Player player = PlayerTool.getPlayer(new CSteamID(owner));
						if (!(player == null))
						{
							UnturnedPlayer unturnedPlayer = UnturnedPlayer.FromPlayer(player);
							if (!base.Configuration.Instance.AdminBypass || !unturnedPlayer.IsAdmin)
							{
								if (base.Configuration.Instance.AllowedBarricadeIDs.Contains(asset.id))
								{
									shouldAllow = true;
								}
								else
								{
									if (base.Configuration.Instance.SendWarning)
									{
										UnturnedChat.Say(unturnedPlayer, base.Configuration.Instance.WarningMessage, Color.red);
									}
									shouldAllow = false;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Rocket.Core.Logging.Logger.LogException(ex, "Error in plugin");
			}
		}
	}
}
