//@tettasun
using UnityEngine;
using System.Collections;
using System;

public class  MTCameraController : MonoBehaviour {

	public float stageHeight = 960f;
	public float stageWidth = 640f;
	private float _scale = 0.0f;
	public float scale { get {return _scale;} }

	private int _screenOffset = 0;
	public int screenOffset { get {return _screenOffset;} }
	
	private Camera _camera;
	public bool isInitialized = false;
	
	void Awake()
	{
		Application.targetFrameRate = 30;
		
		_camera = Camera.main;

		_camera.orthographic = true;
		this.transform.position = new Vector3(0, 0, -10);
		
		float scale_h = (float)Screen.height / stageHeight;
		float scale_w = (float)Screen.width / stageWidth;

		if (scale_h > scale_w) {
			_scale = scale_w;
		} else {
			_scale = scale_h;
		}
		
		if (_scale != 0.0f) {
			_camera.orthographicSize = ((float)Screen.height / _scale) / 2f;
			float scaledHeight = stageHeight * scale;
			_screenOffset = (int)Math.Ceiling(((float)Screen.height - scaledHeight) / 2f / scale);
		}
	}
}
