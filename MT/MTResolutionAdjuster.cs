//@tettasun
using UnityEngine;
using System.Collections;
using System;

public class MTResolutionAdjuster : MonoBehaviour {

	public float stageHeight;
	public float stageWidth;
	
	public float max_height;

	public float scale { get {return MTResolutionUtil.scale;} }
	public float screenOffset { get {return MTResolutionUtil.screenOffset ;} }
	
	private Camera _camera;
	public bool isInitialized = false;
	
	void Awake()
	{
		_camera = this.GetComponent<Camera>();

		_camera.orthographic = true;
		
		
		if (MTResolutionUtil.scale != 0.0f)
		{
			_camera.orthographicSize = ((float)Screen.height /MTResolutionUtil.scale ) /2f;
		}
		
		isInitialized = true;
	}
}