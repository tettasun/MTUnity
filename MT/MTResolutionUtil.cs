//@tettasun
using UnityEngine;
using System.Collections;
using System;

public class MTResolutionUtil : MonoBehaviour {

	public static float stageHeight = 960f;
	public static float stageWidth = 640f;
	
	public static float max_height = 1200f;
	
	private static bool _initialized = false;
	private static float _scale = 0f;
	private static float _screenOffset = 0f;
	
	public static float scale
	{
		get {
			if (_initialized == false)
				Initialize();
			
			return _scale;
		}
	}
	
	public static float screenOffset
	{
		get {
			if (_initialized == false)
				Initialize();
			
			return _screenOffset;
		}
	}
	
	public static void Initialize()
	{
		float scale_h = (float)Screen.height / stageHeight;
		float scale_w = (float)Screen.width / stageWidth;
		
		if (scale_h > scale_w)
		{
			_scale = scale_w;
		}
		else
		{
			_scale = scale_h;
		}
		
		if (_scale != 0.0f)
		{
			float scaledHeight = stageHeight * _scale;
			_screenOffset = (int)Math.Ceiling(((float)Screen.height - scaledHeight) / 2f / _scale);
			
			float maxOffset = (max_height - stageHeight) / 2f;
			
			if (_screenOffset > maxOffset)
			{
				_screenOffset = (int)maxOffset;
			}
		}
		
		_initialized = true;
	}
}