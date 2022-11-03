using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCommand : UICommand
{
	int _minutes;
	int _seconds;
	string _timeString;

	public string TimeString => _timeString;

	public TimeCommand(int minutes, int seconds)
	{
		_minutes = minutes;
		_seconds = seconds;
		_timeString = GetTimeString(minutes, seconds);
	}

	public string GetTimeString(int minute, int seconds)
	{
		return (seconds).ToString("00");
	}
}
