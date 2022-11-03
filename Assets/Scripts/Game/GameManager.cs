using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
	private GameState _currentState;
	public IControllerWrapper Controller;
	[SerializeField] private Cannon _playerCannon1;
	public Cannon Player1 => _playerCannon1;
	[SerializeField] private Cannon _playerCannon2;
	public Cannon Player2 => _playerCannon2;
	[SerializeField] private PaintTarget _paintTarget;
	public PaintTarget PaintTarget => _paintTarget;
	[SerializeField] private AudioSource _battleBGMSource;
	public AudioSource BattleBGMSource => _battleBGMSource;
	[SerializeField] private AudioSource _resultBGMSource;
	public AudioSource ResultBGMSource => _resultBGMSource;
	[SerializeField] private AudioSource _paintSESource;
	public AudioSource PaintSESource => _paintSESource;



	// Start is called before the first frame update
	void Start()
	{
		_currentState = new TitleState();
		_currentState.OnEnter(this);

		_playerCannon1.gameObject.SetActive(false);
		_playerCannon2.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		_currentState.Update(this);
		if (_currentState.IsNext(this))
		{
			Debug.Log("State is changing");
			_currentState.OnExit(this);
			_currentState = (GameState)Activator.CreateInstance(_currentState.NextType);
			_currentState.OnEnter(this);
		}
	}
}
