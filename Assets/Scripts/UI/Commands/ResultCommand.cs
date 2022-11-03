using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultCommand : UICommand
{
	public bool IsActive { get; }
	public ResultCommand(bool isActive)
	{
		IsActive = isActive;
	}
}

