using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
	[SerializeField] private Canvas _titleCanvas;
	// Start is called before the first frame update
	void Awake()
	{
		_titleCanvas.gameObject.SetActive(true);
	}

	public void Recieve(TitleCommand command)
	{
		_titleCanvas.gameObject.SetActive(command.IsActive);
	}
}
