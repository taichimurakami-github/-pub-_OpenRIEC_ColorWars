using UnityEngine;

public enum GInteraction
{
	VIBRATE_NORMAL_SHOT_FIRED,
}

public interface IControllerWrapper
{
	bool CheckConnection(int controllerId);//コントローラーの接続チェック
	bool GetButton(int controllerId, GButtons buttonId);//第二引数で指定したボタンが押されているか
	bool GetButtonUp(int controllerId, GButtons buttonId);//第二引数で指定したボタンが離されたか
	bool GetButtonDown(int controllerId, GButtons buttonId);//第二引数で指定したボタンが押された瞬間か
	Vector3 GetGyro(int controllerId);//コントローラーのジャイロセンサの値を取得
	Vector3 GetAccel(int controllerId);//コントローラーの加速度センサの値を取得
	Quaternion GetVector(int controllerId);
	void Vibrate(int controllerId, GInteraction vibrateType);//コントローラーを振動させる
	void VibrateTest(int cId, float l_f, float h_f, float amp, int time);//デバッグ用関数(バイブの強さ調整用)
}
