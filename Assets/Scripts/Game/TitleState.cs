using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleState : GameState
{

	public TitleState()
	{
		NextType = typeof(PlayState);
	}

	public override void OnEnter(GameManager manager)
	{
		Debug.Log("TitleStateに入りました．");
		UIMediator.Instance.Send(new TitleCommand(true));
	}

	public override void OnExit(GameManager manager)
	{
		Debug.Log("TitleStateを出ました．");
		UIMediator.Instance.Send(new TitleCommand(false));
	}

	public override bool IsNext(GameManager manager)
	{
		return Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Space);
	}

	public override void Update(GameManager manager)
	{
	}
}