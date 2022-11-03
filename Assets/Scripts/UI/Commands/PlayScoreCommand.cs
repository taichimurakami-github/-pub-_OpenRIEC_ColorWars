using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScoreCommand : UICommand
{
	public double Player1 { get; }
	public double Player2 { get; }

	public PlayScoreCommand(double score1, double score2)
	{
		Player1 = score1;
		Player2 = score2;
	}

}
