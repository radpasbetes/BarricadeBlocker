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
	public class Main : RocketPlugin<Configuration>
	{
		protected override void Load()
		{
			BarricadeManager.onDeployBarricadeRequested = (DeployBarricadeRequestHandler)Delegate.Combine(BarricadeManager.onDeployBarricadeRequested, new DeployBarricadeRequestHandler(this.OnBarricadeDeployRequested));
		}

		protected override void Unload()
		{
			BarricadeManager.onDeployBarricadeRequested = (DeployBarricadeRequestHandler)Delegate.Remove(BarricadeManager.onDeployBarricadeRequested, new DeployBarricadeRequestHandler(this.OnBarricadeDeployRequested));
		}

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
