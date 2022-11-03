using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCommand : UICommand
{
	public bool IsActive { get; }
	public PlayCommand(bool isActive)
	{
		IsActive = isActive;
	}
}