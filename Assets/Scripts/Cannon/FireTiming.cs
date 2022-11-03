using UnityEngine;
using System.Timers;

public class FireTiming : ITiming
{

	Timer IntervalCountTimer = new Timer();
	bool isAbleToShoot = true;
	public bool IsActive()
	{
		return isAbleToShoot;
	}

	public void SetNewIntervalMs(double newInterval_ms)
	{
		// Debug.Log($"set new interval:{newInterval_ms}");
		isAbleToShoot = false;
		IntervalCountTimer.Interval = newInterval_ms;
		IntervalCountTimer.Elapsed += onElabsed;
		IntervalCountTimer.Enabled = true; //タイマーをスタート
	}

	public void SetActive(bool state)
	{
		isAbleToShoot = state;
	}

	void onElabsed(object sender, ElapsedEventArgs e)
	{
		IntervalCountTimer.Enabled = false;//タイマーを停止
		isAbleToShoot = true;
	}

}
