//@tettasun
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class MTUIBehaviour : MonoBehaviour {
	
	protected Transform _transform;
	protected RectTransform _rectTransform;
	public RectTransform rectTransform
	{
		get
		{
			return _rectTransform;
		}
	}

	protected virtual void Awake()
	{
		_Assign();
	}
	
	protected void _Assign()
	{
		if (_rectTransform == null)
		{
			_transform = this.transform;
			_rectTransform = _transform as RectTransform;
		}
	}
	
	// //
	// // transform
	// //
	// public void SetLocalX(float value)
	// {
	// _Assign();
	// SetLocalPosition(value, _transform.localPosition.y, _transform.localPosition.z);
	// }
	// public void SetLocalY(float value)
	// {
	// _Assign();
	// SetLocalPosition(_transform.localPosition.x, value, _transform.localPosition.z);
	// }
	// public void SetLocalZ(float value)
	// {
	// _Assign();
	// SetLocalPosition(_transform.localPosition.x, _transform.localPosition.y, value);
	// }
	
	// public void SetLocalPosition(float x, float y, float z)
	// {
	// _Assign();
	// Vector3 newPosition =
	// new Vector3(x, y, z);
	// _transform.localPosition = newPosition;
	// }
	
	//
	//RectTransform
	//
	
	/**
* アンカードポジションの設定
* @param v Vector2
*/
	public void SetAnchoredPosition(Vector2 v)
	{
		_rectTransform.anchoredPosition = v;
	}
	
	/**
* アンカードポジションの設定
* @param x X座標
* @param y Y座標
*/
	public void SetAnchoredPosition(float x, float y)
	{
		SetAnchoredPosition(new Vector2(x, y));
	}
	
	/**
* ピボットの設定
* @param v Vector2
*/
	public void SetPivot(Vector2 v)
	{
		_rectTransform.pivot = v;
	}
	
	/**
* ピボットの設定
* @param x X座標
* @param y Y座標
*/
	public void SetPivot(float x, float y)
	{
		SetPivot(new Vector2(x, y));
	}
	
	/**
* サイズの設定
* @param v Vector2
*/
	public void SetSize(Vector2 v)
	{
		_rectTransform.sizeDelta = v;
	}
	
	/**
* サイズの設定
* @param x X座標
* @param y Y座標
*/
	public void SetSize(float w, float h)
	{
		SetSize(new Vector2(w, h));
	}
	
	/**
* 幅の設定
* @param w 幅
*/
	public void SetWidth(float w)
	{
		SetSize(new Vector2(w, _rectTransform.sizeDelta.y));
	}
	
	/**
* 高さの設定
* @param h 高さ
*/
	public void SetHeight(float h)
	{
		SetSize(new Vector2(_rectTransform.sizeDelta.x, h));
	}
	
	/**
* コンポーネントの追加
* @param s 子要素の名称
* @returen コンポーネント
*/
	public T Add<T>(string s) where T:Component
	{
		return MTUtil.Add<T>(GetTransform(s));
	}
	
	/**
* コンポーネントの取得
* @param s 子要素の名称
* @returen コンポーネント
*/
	public T Get<T>(string s) where T:Component
	{
		return MTUtil.Get<T>(GetTransform(s));
	}
	
	/**
* イメージの取得
* @param s 子要素の名称
* @returen イメージ
*/
	public Image GetImage(string s)
	{
		return ImageUtil.Get(GetTransform(s));
	}
	
	/**
* テキストの取得
* @param s 子要素の名称
* @returen テキスト
*/
	public Text GetText(string s)
	{
		return TextUtil.Get(GetTransform(s));
	}
	
	/**
* RectTransformの取得
* @param s 子要素の名称
* @returen RectTransform
*/
	public RectTransform GetRectT(string s)
	{
		return RectUtil.Get(GetTransform(s));
	}
	
	/**
* Transformの取得
* @param s 子要素の名称
* @returen Transform
*/
	public Transform GetTransform(string s)
	{
		if (s == null)
		{
			return null;
		}
		
		Transform t = _transform.FindChild(s);
		if (t == null)
		{
			return null;
		}
		
		return t;
	}

	//Gismos
	void OnDrawGizmos ()
	{
		RectTransform rectTransform = transform as RectTransform;

		float xOffset = transform.position.x - transform.localPosition.x;
		float yOffset = transform.position.y - transform.localPosition.y;

		float x1 = (transform.localPosition.x - (rectTransform.sizeDelta.x * rectTransform.pivot.x) * transform.lossyScale.x) + xOffset;
		float x2 = (transform.localPosition.x + (rectTransform.sizeDelta.x * (1f - rectTransform.pivot.x) * transform.lossyScale.x))+ xOffset;
		float y1 = (transform.localPosition.y - (rectTransform.sizeDelta.y  * rectTransform.pivot.y) * transform.lossyScale.y) + yOffset;
		float y2 = (transform.localPosition.y + (rectTransform.sizeDelta.y  * (1f - rectTransform.pivot.y) * transform.lossyScale.y)) + yOffset;
        
        
        float max = 100000f;
		float min = -100000f;

		Gizmos.color = new Color32(255,0,0,100);
		Gizmos.DrawLine(new Vector3(x1,min,0f), new Vector3(x1,max,0f));
		Gizmos.DrawLine(new Vector3(x2,min,0f), new Vector3(x2,max,0f));
		Gizmos.DrawLine(new Vector3(min,y1,0f), new Vector3(max,y1,0f));
		Gizmos.DrawLine(new Vector3(min,y2,0f), new Vector3(max,y2,0f));
	}
	
}