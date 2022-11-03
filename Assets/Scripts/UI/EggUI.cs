using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggUI : MonoBehaviour
{
	[SerializeField] private Image _imageK;
	[SerializeField] private Image _imageT;

	private float _timeK;
	private float _timeT;
	private float _interval;

	private void Start()
	{
		_imageK.gameObject.SetActive(false);
		_imageT.gameObject.SetActive(false);
		_timeK = 0;
		_timeT = 0;
		_interval = 5.0f;
	}

	public void Receive(EggCommand command)
	{
		if (command.ControllerId == 0)
		{
			_imageK.gameObject.SetActive(true);
			_timeK = 0;
		}
		else
		{
			_imageT.gameObject.SetActive(true);
			_timeT = 0;
		}
	}

	private void Update()
	{
		_timeK += Time.deltaTime;
		_timeT += Time.deltaTime;

		_imageK.gameObject.transform.Translate(new Vector3(0, 0, 0));
		_imageT.gameObject.transform.Translate(new Vector3(0, 0, 0));

		if (_timeK > _interval)
		{
			_imageK.gameObject.SetActive(false);
		}

		if (_timeT > _interval)
		{
			_imageT.gameObject.SetActive(false);
		}

	}
}
