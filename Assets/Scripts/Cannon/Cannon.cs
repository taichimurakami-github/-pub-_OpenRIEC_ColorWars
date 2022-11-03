using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Cannon : MonoBehaviour, IGun

{
	public IControllerWrapper Controller { get; set; }
	public IPaint Paint { get; set; }

	public enum BulletType
	{
		Normal,
		Gatling,
		Giant,
	}

	[SerializeField] private float _gyroAdjustment = 0.1f;
	[SerializeField] private float _error = 0.2f;

	[SerializeField] private int controllerId = 0;
	[SerializeField] private Brush brush;

	[SerializeField] private bool _enableAutoShot = true;//trueにすると弾を自動で射出（falseの場合はZL/Rボタンで射出）

	//shot intervals
	[SerializeField] private int _normalShotInterval_ms = 1000;

	[SerializeField] private int _gatlingShotInterval_ms = 500;

	[SerializeField] private int _giantShotInterval_ms = 2000;

	private ITiming _fireTiming;

	[SerializeField] private GameObject _normalBulletBaseObj;
	[SerializeField] private GameObject _giantBulletBaseObj;
	private Color _cannonColor;

	[SerializeField] private BulletType _bulletType;

	[SerializeField] private float _maxAngle = 330;
	[SerializeField] private float _minAngle = 25f;

	private FireTiming _stateChangeTiming;

	private int _gameTimeCount_sec;

	private float _bulletFireForce = 30f;

	[SerializeField] public int GameTimeCount_sec => _gameTimeCount_sec;

	// Start is called before the first frame update
	void Awake()
	{
		// get the public Joycon array attached to the JoyconManager in scene
	}

	void OnEnable()
	{

		// _stateChangeTiming.SetNewIntervalMs(10 * 1000);

		// brush = new Brush();
		// brush.splatTexture = Resources.Load<Texture2D>("splats");
		Controller = new JoyconController();
		_fireTiming = new FireTiming();
		_stateChangeTiming = new FireTiming();
		_cannonColor = controllerId == 0 ? GColors.GetColor(GColorPallet.INK_YELLOW) : GColors.GetColor(GColorPallet.INK_BLUE);
		_bulletType = BulletType.Normal;
		_fireTiming.SetNewIntervalMs(_normalShotInterval_ms);
	}

	public void SetSpeedInterval(int interval_ms)
	{
		_normalShotInterval_ms = interval_ms;
	}


	// Update is called once per frame
	//本当はStateMachineで管理しようかなと思ったけど，書き直す時間が足りませんでした...無念
	void Update()
	{
		gameObject.GetComponent<Renderer>().material.color = _cannonColor;

		if (!gameObject.activeSelf)
		{
			return;
		}

		if (!Controller.CheckConnection(controllerId))
		{
			//コントローラーの接続状態が正常でなければ処理を中断
			Debug.LogError("コントローラーが接続されていません");
			return;
		}

		//現在のジャイロセンサの値を基準にキャリブレーションを行う
		if (Controller.GetButton(controllerId, GButtons.Calibrate))
		{
			gameObject.GetComponent<Renderer>().material.color = GColors.GetColor(GColorPallet.DEBUG_RAY_GREEN);
			CalibrateAngle();
		}

		//ジャイロセンサの値を砲台の角度に反映
		SetCannonAnglesFromGyro();


		//照準を表示
		// DrawRaycast(Color.green);


		bool isShotTriggered = _enableAutoShot || Controller.GetButton(controllerId, GButtons.Shoot);


		if (isShotTriggered && _fireTiming.IsActive())
		{
			ShotNormalBullet();
			_fireTiming.SetNewIntervalMs(_normalShotInterval_ms);
		}

		if (Controller.GetButton(controllerId, GButtons.Shoot))
		{
			UIMediator.Instance.Send(new EggCommand(controllerId));
		}
		
	}

	void DrawRaycast(Color rayColor)
	{
		// var direction = transform.up;
		// var direction = transform.forward;
		var direction = transform.right;
		var length = 5.0f;
		Debug.DrawRay(transform.position, direction * length, rayColor);
	}

	void CalibrateAngle()
	{
		// transform.localEulerAngles = Vector3.zero;
		// transform.rotation = new Quaternion(0, 0, 0, 0);
	}


	void SetCannonAnglesFromGyro()
	{
		var vector = Controller.GetVector(controllerId);
		vector = Quaternion.AngleAxis(90, Vector3.right) * vector;

		transform.rotation = vector;
	}


	GameObject ShotNormalBullet()
	{
		//クールダウン時間を設定（ノーマルショット）
		_fireTiming.SetNewIntervalMs(_normalShotInterval_ms);

		//オブジェクトを生成
		GameObject newBulletObj = Instantiate(_normalBulletBaseObj, transform.position, transform.rotation);
		newBulletObj.GetComponent<Renderer>().material.color = _cannonColor;

		//力を付与して射出
		newBulletObj.GetComponent<Rigidbody>().AddForce(transform.forward * _bulletFireForce, ForceMode.Impulse);

		//砲弾の設定をカスタマイズ
		GBrushChannel brushChannel = controllerId == 1 ? GColors.GetBrushChannelFromColor(GColorPallet.INK_BLUE) : GColors.GetBrushChannelFromColor(GColorPallet.INK_YELLOW);
		Bullet normalBullet = newBulletObj.GetComponent<Bullet>();

		normalBullet.SetSplatChannel(brushChannel);//弾の色を設定
		normalBullet.SetControllerInstance(Controller);//コントローラーの参照渡し
		normalBullet.SetControllerId(controllerId);//インタラクションを起こすコントローラー番号を指定

		Destroy(newBulletObj, 2f);

		return newBulletObj;
	}
}