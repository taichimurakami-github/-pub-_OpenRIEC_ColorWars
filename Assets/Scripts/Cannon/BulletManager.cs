using UnityEngine;
public class BulletManager : MonoBehaviour
{
	private GameObject _normalBulletBaseObj;
	private GameObject _gatlingBulletBaseObj;
	private GameObject _giantBulletBaseObj;

	public BulletManager(GameObject normalBulletBaseObj, GameObject gatlingBulletBaseObj, GameObject giantBulletBaseObj)
	{
		_normalBulletBaseObj = normalBulletBaseObj;
		_gatlingBulletBaseObj = gatlingBulletBaseObj;
		_giantBulletBaseObj = giantBulletBaseObj;
	}

	public GameObject CreateNormalBullet(Vector3 position, Quaternion rotation, Color bulletColor, float existDuration)
	{
		GameObject newBulletObj = Instantiate(_normalBulletBaseObj, position, rotation);
		Color newBulletColor = bulletColor;
		newBulletObj.GetComponent<Renderer>().material.color = newBulletColor;

		//とりあえず的に当たらなかったら自動で破壊
		Destroy(newBulletObj, existDuration);

		return newBulletObj;
	}
	public GameObject CreateGatlingBullet(Vector3 position, Quaternion rotation, Color bulletColor, float existDuration)
	{
		GameObject newBulletObj = Instantiate(_gatlingBulletBaseObj, position, rotation);
		Color newBulletColor = bulletColor;
		newBulletObj.GetComponent<Renderer>().material.color = newBulletColor;

		//とりあえず的に当たらなかったら自動で破壊
		Destroy(newBulletObj, existDuration);
		return newBulletObj;
	}
	public GameObject CreateGiantBullet(Vector3 position, Quaternion rotation, Color bulletColor, float existDuration)
	{
		GameObject newBulletObj = Instantiate(_giantBulletBaseObj, position, rotation);
		Color newBulletColor = bulletColor;
		newBulletObj.GetComponent<Renderer>().material.color = newBulletColor;
		_giantBulletBaseObj.GetComponent<Transform>().localScale = new Vector3(2.5f, 2.5f, 2.5f);

		//とりあえず的に当たらなかったら自動で破壊
		Destroy(newBulletObj, existDuration);
		return newBulletObj;
	}
}