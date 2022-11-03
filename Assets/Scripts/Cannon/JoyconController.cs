using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct JoyconData
{
	public bool isJoyconLeft;
	public string name;
	public float[] stick;
	public Vector3 gyro;
	public Vector3 accel;
	public Quaternion orientation;//公式ドキュメントによると取得できる値が不安定らしいので、ゲームにそのまま使用するのは非推奨
}

public enum GButtons
{
	Shoot,
	Calibrate,
}

// ***********************************************************************
// class JoyconController : IControllerWrapper
//
// JoyconManagerを利用し、ペアで登録されたJoyconのデータを取得 &
// ゲームに必要なデータをフィルタリングしてそのまま提供
//
// ※注意
//  このクラスは使用されるJoyconが左右１ペアの前提で作成されています。
//  もしも左右のペアでなく左のみ、右のみで運用する場合、あるいは
//  ３つ以上のJoyconを用いる場合は新たにControllerクラスを作成する必要があります
// *************************************************************************

public class JoyconController : IControllerWrapper
{
	// public properties
	private JoyconData _JoyconData;//一応用意したけどほとんど意味ない気がする

	// private properties
	private List<Joycon> m_joycons;
	private Joycon m_joyconL;
	private Joycon m_joyconR;
	private Joycon.Button? m_pressedButtonL;
	private Joycon.Button? m_pressedButtonR;


	private static readonly Joycon.Button[] m_buttons = Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

	// インスタンスはMonoBehaviour.Start()メソッド内で作成する事
	// それ以前のタイミングで呼ぶとJoyconManagerが情報を取得出来ていないっぽい
	public JoyconController()
	{
		m_joycons = JoyconManager.Instance.j;
		Debug.Log($"joycons count: {m_joycons.Count}");

		// joycon接続チェック
		var checkResult = _CheckBothJoyconConnected();
		if (!checkResult) return;

		m_joyconL = m_joycons.Find(c => c.isLeft);
		m_joyconR = m_joycons.Find(c => !c.isLeft);
	}

	private JoyconData _GetJoyconData(Joycon joycon)
	{
		var joyconData = new JoyconData();

		joyconData.isJoyconLeft = joycon.isLeft;
		joyconData.name = joycon.isLeft ? "Joy-Con (L)" : "Joy-Con (R)";
		joyconData.stick = joycon.GetStick();
		joyconData.gyro = joycon.GetGyro();
		joyconData.accel = joycon.GetAccel();
		joyconData.orientation = joycon.GetVector();

		return joyconData;
	}

	private bool _CheckBothJoyconConnected()
	{
		if (m_joycons == null || m_joycons.Count <= 0)
		{
			Debug.Log("Joy-Con が接続されていません");
			return false;
		}

		if (!m_joycons.Any(c => c.isLeft))
		{
			Debug.Log("Joy-Con (L) が接続されていません");
			return false;
		}

		if (!m_joycons.Any(c => !c.isLeft))
		{
			Debug.Log("Joy-Con (R) が接続されていません");
			return false;
		}

		return true;
	}

	bool _IsJoyconConnected()
	{
		return m_joycons != null && m_joycons.Count > 0;
	}

	Joycon.Button _GetJoyconButtonFromGButtons(GButtons buttonId)
	{
		switch (buttonId)
		{
			case GButtons.Shoot:
				return Joycon.Button.SHOULDER_2;

			case GButtons.Calibrate:
				return Joycon.Button.DPAD_UP;

			default:
				return Joycon.Button.MINUS;
		}
	}

	bool _CheckControllerId(int cId)
	{
		return 0 <= cId && cId <= 1;
	}

	bool _CheckControllerInstance(int cId)
	{
		return m_joycons[cId] != null;
	}

	public bool CheckConnection(int cId)
	{
		return _IsJoyconConnected() && _CheckControllerInstance(cId);
	}

	public Joycon _GetJoyconFromCId(int cId)
	{
		// if (cId == 1)
		// {
		// 	return m_joyconR;
		// }

		// return m_joyconL;
		return m_joycons[cId];
	}

	public bool GetButton(int cId, GButtons buttonId)
	{
		if (!_CheckControllerId(cId))
		{
			Debug.LogError("Invalid controller id has been passed!!");
			return false;
		}

		if (!_CheckControllerInstance(cId))
		{
			Debug.LogError("Something error happened: cannot find connected joy-con.");
			return false;
		}

		var joyconButton = _GetJoyconButtonFromGButtons(buttonId);
		return _GetJoyconFromCId(cId).GetButton(joyconButton);
	}

	public bool GetButtonUp(int cId, GButtons buttonId)
	{
		if (!_CheckControllerId(cId))
		{
			Debug.LogError("Invalid controller id has been passed!!");
			return false;
		}

		if (!_CheckControllerInstance(cId))
		{
			Debug.LogError("Something error happened: cannot find connected joy-con.");
			return false;
		}
		var joyconButton = _GetJoyconButtonFromGButtons(buttonId);
		Debug.Log(joyconButton);
		return _GetJoyconFromCId(cId).GetButtonUp(joyconButton);
	}

	public bool GetButtonDown(int cId, GButtons buttonId)
	{
		if (!_CheckControllerId(cId))
		{
			Debug.LogError("Invalid controller id has been passed!!");
			return false;
		}

		if (!_CheckControllerInstance(cId))
		{
			Debug.LogError("Something error happened: cannot find connected joy-con.");
			return false;
		}
		var joyconButton = _GetJoyconButtonFromGButtons(buttonId);
		return _GetJoyconFromCId(cId).GetButtonDown(joyconButton);
	}

	public Vector3 GetGyro(int cId)
	{
		if (!_CheckControllerId(cId))
		{
			Debug.LogError("Invalid controller id has been passed!!");
			return new Vector3(0, 0, 0);
		}

		if (!_CheckControllerInstance(cId))
		{
			Debug.LogError("Something error happened: cannot find connected joy-con.");
			return new Vector3(0, 0, 0);
		}

		Vector3 gyro = _GetJoyconFromCId(cId).GetGyro();
		// Debug.Log($"now gyro is {gyro.x}, {gyro.y} {gyro.z}");

		return _GetJoyconFromCId(cId).GetGyro();
	}

	public Vector3 GetAccel(int cId)
	{
		if (!_CheckControllerId(cId))
		{
			Debug.LogError("Invalid controller id has been passed!!");
			return new Vector3(0, 0, 0);
		}

		if (!_CheckControllerInstance(cId))
		{
			Debug.LogError("Something error happened: cannot find connected joy-con.");
			return new Vector3(0, 0, 0);
		}

		return _GetJoyconFromCId(cId).GetAccel();
	}

	public Quaternion GetVector(int cId)
	{
		if (!_CheckControllerId(cId))
		{
			Debug.LogError("Invalid controller id has been passed!!");
			return new Quaternion(0, 0, 0, 0);
		}

		if (!_CheckControllerInstance(cId))
		{
			Debug.LogError("Something error happened: cannot find connected joy-con.");
			return new Quaternion(0, 0, 0, 0);
		}

		return _GetJoyconFromCId(cId).GetVector();
	}

	public void Vibrate(int cId, GInteraction vibrationType)
	{
		switch (vibrationType)
		{
			default:
				m_joycons[cId].SetRumble(150, 225, 0.45f, 50);
				break;
		}
	}

	public void VibrateTest(int cId, float l_f, float h_f, float amp, int time)
	{
		m_joycons[cId].SetRumble(l_f, h_f, amp, time);
	}
}