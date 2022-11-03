using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] PaintTarget WallCanvas;

	[SerializeField] private Brush brush;

	// [SerializeField] private float v_low_freq = 160;
	// [SerializeField] private float v_high_freq = 320;
	// [SerializeField] private float v_amp = 0.3f;
	// [SerializeField] private int v_time = 100;


	public GBrushChannel SplatChannel = GBrushChannel.INK_YELLOW;
	public IControllerWrapper Controller { get; set; }
	public int ControllerId = 0;

	// Start is called before the first frame update
	void Start()
	{
		// WallCanvas = GameObject.Find("WallCanvas").GetComponent<PaintTarget>();
	}

	// Update is called once per frame
	void Update()
	{
		// var direction = transform.forward;
		// PaintTarget.PaintRay(new Ray(transform.position, direction), brush);
	}


	public void SetSplatChannel(GBrushChannel splatChannel)
	{
		SplatChannel = splatChannel;
	}

	public void SetControllerId(int cId)
	{
		ControllerId = cId;
	}

	public void SetControllerInstance(IControllerWrapper controller)
	{
		Controller = controller;
	}
}
