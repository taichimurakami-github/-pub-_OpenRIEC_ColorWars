using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatCannonCommand : UICommand
{
	public int PlayerId { get; }
	public bool IsActive { get; }

	public GreatCannonCommand(int playerId, bool isActive)
	{
		PlayerId = playerId;
		IsActive = isActive;
	}
}