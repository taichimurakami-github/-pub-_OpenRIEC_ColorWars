using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayUI : MonoBehaviour
{
	// 時間とスコア表示部分
	[SerializeField] private Canvas _playCanvas;
	[SerializeField] private TextMeshProUGUI _gameTimerText;
	// [SerializeField] private Image[] _GreatCannonActivationPanels;

	private double[] _PlayerScores = new double[2];

	void Awake()
	{
		_playCanvas.gameObject.SetActive(false);
	}

	public void Receive(PlayCommand command)
	{
		_playCanvas.gameObject.SetActive(command.IsActive);
	}


	public void Receive(TimeCommand command)
	{
		_gameTimerText.text = command.TimeString;
	}

}
