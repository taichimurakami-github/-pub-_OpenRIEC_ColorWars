using UnityEngine;

public class WallCanvas : MonoBehaviour
{
	[SerializeField] private Brush brush;
	[SerializeField] private AudioSource _battleBGMSource;
	[SerializeField] private AudioSource _paintSESource;
	private PaintTarget _paintTarget;

	void Start()
	{
		_paintTarget = this.gameObject.GetComponent<PaintTarget>();
	}

	void OnCollisionEnter(Collision collision)
	{
		//##TODO##
		//
		//painttarget側に処理を移植
		//

		//Painz Script/CollisionPainter を改変
		foreach (ContactPoint contact in collision.contacts)
		{
			Bullet bullet = contact.otherCollider.gameObject.GetComponent<Bullet>();


			if (bullet == null)
			{
				Debug.LogError("No bullet component is collided");
				continue;
			}

			//銃弾が衝突した場合
			brush.splatChannel = (int)bullet.SplatChannel; //WallCanvasのPaintTargetで設定された4つの色のうちいずれかの番号を指定(0~4)

			PaintTarget.PaintObject(_paintTarget, contact.point, contact.normal, brush);


			int controllerId = bullet.ControllerId;

			bullet.Controller.Vibrate(controllerId, GInteraction.VIBRATE_NORMAL_SHOT_FIRED);
			// Controller.VibrateTest(controllerId, v_low_freq, v_high_freq, v_amp, v_time);
			_battleBGMSource.PlayOneShot(_paintSESource.clip);

			Destroy(bullet.gameObject, 0);
		}

	}
}