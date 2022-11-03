using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingCommand : UICommand
{
	public int PlayerId { get; }
	public bool IsActive { get; }


	public GatlingCommand(int playerId, bool isActive)
	{
		PlayerId = playerId;
		IsActive = isActive;
	}
}