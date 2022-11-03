using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayState : GameState
{

	[SerializeField] private int _timelimit_sec = 46;
	private Timer _gameTimer = new Timer();

	//ゲーム終了フラグ
	private bool _isGameOver;


	//塗り面積（TallyScoreの結果）: [player1, player2]
	private float[] _scores;

	public PlayState()
	{
		NextType = typeof(ResultState);
	}

	//タイマー関連

	//　トータル制限時間
	[SerializeField] private float _seconds;
	//　前回Update時の秒数

	private float _startTime;

	private string _timerText;
	public string TimerText => _timerText;

	private bool _isTimerActive = false;

	public override void OnEnter(GameManager manager)
	{
		Debug.Log("PlayStateに入りました．");

		//UIを起動
		UIMediator.Instance.Send(new PlayCommand(true));

		//Cannonをアクティベート 
		manager.Player1.gameObject.SetActive(true);
		manager.Player2.gameObject.SetActive(true);

		//BGMを再生
		manager.BattleBGMSource.Play();

		_startTime = Time.time;
		_isTimerActive = true;
	}

	public override void OnExit(GameManager manager)
	{
		Debug.Log("PlayStateを出ました．");

		//UIをデアクティベート
		UIMediator.Instance.Send(new PlayCommand(false));

		//Cannonをデアクティベート
		manager.Player1.gameObject.SetActive(false);
		manager.Player2.gameObject.SetActive(false);

		//BGMを停止
		manager.BattleBGMSource.Stop();
	}

	public override bool IsNext(GameManager manager)
	{
		return _isGameOver;
	}

	public override void Update(GameManager manager)
	{
		UpdateGameTimer();
		UIMediator.Instance.Send(new TimeCommand(0, (int)_seconds));
		// Debug.Log($"残り時間：{_seconds}秒です");


		if (_seconds < 20)
		{
			manager.Player1.gameObject.GetComponent<Cannon>().SetSpeedInterval(100);

			manager.Player2.gameObject.GetComponent<Cannon>().SetSpeedInterval(100);
		}
		else if (_seconds < 25)
		{
			manager.Player1.gameObject.GetComponent<Cannon>().SetSpeedInterval(200);

			manager.Player2.gameObject.GetComponent<Cannon>().SetSpeedInterval(200);
		}
		else if (_seconds < 35)
		{
			manager.Player1.gameObject.GetComponent<Cannon>().SetSpeedInterval(300);

			manager.Player2.gameObject.GetComponent<Cannon>().SetSpeedInterval(300);
		}
		else if (_seconds < 40)
		{
			manager.Player1.gameObject.GetComponent<Cannon>().SetSpeedInterval(500);

			manager.Player2.gameObject.GetComponent<Cannon>().SetSpeedInterval(500);
		}

	}

	void UpdateGameTimer()
	{
		float delta = Time.time - _startTime; // 経過時間を格納
		_seconds = _timelimit_sec - delta;

		if (GetIsTimeOver())
		{
			_isGameOver = true;
		}
	}

	public string GetTimeString(int _minutes, int _seconds)
	{
		return _minutes.ToString("00") + ":" + ((int)_seconds).ToString("00");
	}

	public bool GetIsTimeOver()
	{
		return _seconds <= 0f;
	}

}