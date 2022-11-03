using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Timers;

public class ResultUI : MonoBehaviour
{

	[SerializeField] private Canvas _resultCanvas;
	[SerializeField] private TextMeshProUGUI _player1ScoreText;
	[SerializeField] private TextMeshProUGUI _player2ScoreText;

	[SerializeField] private TextMeshProUGUI _player1WinText;
	[SerializeField] private TextMeshProUGUI _player2WinText;
	[SerializeField] private TextMeshProUGUI _drawText;

	// Start is called before the first frame update
	void Awake()
	{
		_resultCanvas.gameObject.SetActive(false);
		_player1WinText.gameObject.SetActive(false);
		_player2WinText.gameObject.SetActive(false);
		_drawText.gameObject.SetActive(false);
	}

	public void Receive(ResultCommand command)
	{
		_resultCanvas.gameObject.SetActive(command.IsActive);
	}

	public void Receive(PlayScoreCommand command)
	{
		int player1Score = (int)command.Player1;
		int player2Score = (int)command.Player2;

		//値が小さすぎるとなぜか負の値になるので強制的に0になるように上書き
		if (player1Score < 0)
		{
			player1Score = 0;
		}

		if (player2Score < 0)
		{
			player2Score = 0;
		}

		Debug.Log($"scores player1: {player1Score} , player2: {player2Score}");

		ActivateWinnerText(player1Score, player2Score);
	}

	// Update is called once per frame
	void Update()
	{

	}


	void ActivateWinnerText(int player1Score, int player2Score)
	{
		if (player1Score == player2Score)
		{
			_drawText.gameObject.SetActive(true);
		}
		else if (player1Score > player2Score)
		{
			_player1WinText.gameObject.SetActive(true);
		}
		else
		{
			_player2WinText.gameObject.SetActive(true);
		}

		_player1ScoreText.text = player1Score.ToString();
		_player2ScoreText.text = player2Score.ToString();
	}
}
