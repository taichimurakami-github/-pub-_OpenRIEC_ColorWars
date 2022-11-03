using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ResultState : GameState
{

	//タイトル画面遷移フラグ
	private bool _isResultSceneOver;

	public ResultState()
	{
		NextType = typeof(TitleState);
	}

	public override void OnEnter(GameManager manager)
	{
		Debug.Log("ResultStateに入りました．");
		UIMediator.Instance.Send(new ResultCommand(true));
		PaintTarget.TallyScore();

		Vector2 parsedScores = GetPercentagePlayerScore(PaintTarget.scores[0], PaintTarget.scores[1]);

		manager.ResultBGMSource.Play();

		UIMediator.Instance.Send(new PlayScoreCommand(parsedScores[0], parsedScores[1]));
	}

	public override void OnExit(GameManager manager)
	{
		Debug.Log("ResultStateを出ました．");
		manager.ResultBGMSource.Stop();
	}

	public override bool IsNext(GameManager manager)
	{
		return _isResultSceneOver;
	}

	public override void Update(GameManager manager)
	{

	}

	Vector2 GetPercentagePlayerScore(double player1Score, double player2Score)
	{
		float sum = (float)(player1Score + player2Score);
		Vector2 result = new Vector2((float)player1Score * 100 / sum, (float)player2Score * 100 / sum);

		return result;
	}

}