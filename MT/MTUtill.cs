//@tettasun
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/**
* 便利クラス
*/
public class MTUtil: MonoBehaviour
{
	
	/**
* コンポーネントの取得
* @param g GameObject
* @return　T コンポーネント
*/
	public static T Get<T> (GameObject g) where T:Component
	{
		if (g == null)
			return null;
		
		return Get<T> (g.transform);
	}
	
	/**
* コンポーネントの取得
* @param t Transform
* @return　T コンポーネント
*/
	public static T Get<T> (Transform t) where T:Component
	{
		if (t == null)
			return null;
		
		return t.GetComponent<T> ();
	}
	
	/**
* コンポーネントの追加
* @param g GameObject
* @return　T コンポーネント
*/
	public static T Add<T> (GameObject g) where T:Component
	{
		if (g == null)
			return null;
		
		return g.AddComponent<T> ();
	}
	
	/**
* コンポーネントの追加
* @param t Transform
* @return　T コンポーネント
*/
	public static T Add<T> (Transform t) where T:Component
	{
		if (t == null)
			return null;
		
		return t.gameObject.AddComponent<T> ();
	}
	
}

/**
* UnityEngine.UI.ImageのUtilクラス
*/
public class ImageUtil :MonoBehaviour
{
	
	/**
* GameObjectからImageを取得する
* @param g GameObject
* @return Image
*/
	public static Image Get (GameObject g)
	{
		return MTUtil.Get<Image> (g.transform);
	}
	
	/**
* TransformからImageを取得する
* @param t Transform
* @return Image
*/
	public static Image Get (Transform t)
	{
		return MTUtil.Get<Image> (t);
	}
	
	/**
* alphaのセット
* @param image Image
* @param alpha アルファ
*/
	public static void SetAlpha (Image image, float alpha)
	{
		Color color = image.color;
		color.a = alpha;
		image.color = color;
	}
	
	/**
* 子要素を含んだalphaの変更(削除予定 CanvasGroup使用のこと)
* @param t Transform　
* @param alpha 透過度
* @param duration 時間
* @param ignoreTimeScale タイムスケールを無視するか
*/
	public static void CrossFadeChildren (Transform t, float alpha, float duration, bool ignoreTimeScale)
	{
		foreach (Graphic i in t.GetComponentsInChildren<Graphic>()) {
			i.CrossFadeAlpha (alpha, duration, ignoreTimeScale);
		}
	}
	
	/**
* 子要素を含んだalphaのセット
* @param t RectTransform
* @param alpha アルファ
*/
	public static void SetFamilyAlpha (RectTransform t, float alpha)
	{
		if (t == null) {
			Debug.LogWarning ("nullref");
			return;
		}
		foreach (Graphic child in t.GetComponentsInChildren<Graphic>()) {
			Color color = child.color;
			color.a = alpha;
			child.color = color;
			
			//自分は含めない
			if (t != child.rectTransform) {
				SetFamilyAlpha (child.rectTransform, alpha);
			}
		}
	}
	
	/**
* alphaを変更したWhiteを取得
* @param alpha アルファ
* @return アルファを変更したColor.white
*/
	public static Color AlphaedWhite (float alpha)
	{
		Color color = Color.white;
		color.a = alpha;
		return color;
	}
	
}

/**
* UnityEngine.UI.TextのUtilクラス
*/
public class TextUtil : MonoBehaviour
{
	
	/**
* GameObjectからTextを取得する
* @param g GameObject
* @return Text
*/
	public static Text Get (GameObject g)
	{
		return MTUtil.Get<Text> (g.transform);
	}
	
	/**
* TransformからTextを取得する
* @param t Transform
* @return Text
*/
	public static Text Get (Transform t)
	{
		return MTUtil.Get<Text> (t);
	}
}

/**
* UnityEngine.UI.RectTransformのUtilクラス
*/
public class RectUtil : MonoBehaviour
{
	
	/**
* GameObjectからRectTransformを取得する
* @param g GameObject
* @return RectTransform
*/
	public static RectTransform Get (GameObject g)
	{
		return MTUtil.Get<RectTransform> (g.transform);
	}
	
	/**
* TransformからRectTransformを取得する
* @param t Transform
* @return RectTransform
*/
	public static RectTransform Get (Transform t)
	{
		return MTUtil.Get<RectTransform> (t);
	}
	
	//
	// Pivot
	//
	
	/**
* Pivotのxを設定する(0 ~ 1)
* @param t RectTransform
* @param x　pivotのx
*/
	public static void SetPivotX (RectTransform t, float x)
	{
		SetPivot (t, x, t.pivot.y);
	}
	
	/**
* Pivotのyを設定する(0 ~ 1)
* @param t RectTransform
* @param y　pivotのy
*/
	public static void SetPivotY (RectTransform t, float y)
	{
		SetPivot (t, t.pivot.x, y);
	}
	
	/**
* Pivotを設定する
* @param t RectTransform
* @param x　pivotのx
* @param y　pivotのy
*/
	public static void SetPivot (RectTransform t, float x, float y)
	{
		t.pivot = new Vector2 (x, y);
	}
	
	//
	// AnchoredPosition
	//
	
	/**
* AnchoredPositionを設定する
* @param t RectTransform
* @param x　x
*/
	public static void SetAnchoredPosX (RectTransform t, float x)
	{
		SetAnchoredPos (t, x, t.anchoredPosition.y);
	}
	
	/**
* AnchoredPositionを設定する
* @param t RectTransform
* @param y　y
*/
	public static void SetAnchoredPosY (RectTransform t, float y)
	{
		SetAnchoredPos (t, t.anchoredPosition.x, y);
	}
	
	/**
* AnchoredPositionを設定する
* @param t RectTransform
* @param x　x
* @param y　y
*/
	public static void SetAnchoredPos (RectTransform t, float x, float y)
	{
		t.anchoredPosition = new Vector2 (x, y);
	}
	
	//
	//Translate
	//
	
	/**
* 平行移動
* @param t RectTransform
* @param x　x
*/
	public static void TranslateX (RectTransform t, float x)
	{
		Translate (t, x, 0);
	}
	
	/**
* 平行移動
* @param t RectTransform
* @param y　y
*/
	public static void TranslateY (RectTransform t, float y)
	{
		Translate (t, 0, y);
	}
	
	/**
* 平行移動
* @param t RectTransform
* @param x　x
* @param y　y
*/
	public static void Translate (RectTransform t, float x, float y)
	{
		t.anchoredPosition = GetTranslatedPos (t, x, y);
	}
	
	/**
* 平行移動した場合の座標を取得する
* @param t RectTransform
* @param x　x
* @param y　y
* @return 平行移動後の座標
*/
	public static Vector2 GetTranslatedPos (RectTransform t, float x, float y)
	{
		return new Vector2 (t.anchoredPosition.x + x, t.anchoredPosition.y + y);
	}
	
	//
	// GetNewPos
	//
	
	/**
* 座標の変更
* @param t RectTransform
* @param x x
* @return 座標(Vector2)
*/
	public static Vector2 GetNewPosX (RectTransform t, float x)
	{
		return GetNewPos (t, x, t.anchoredPosition.y);
	}
	
	/**
* 座標の変更
* @param t RectTransform
* @param y y
* @return 座標(Vector2)
*/
	public static Vector2 GetNewPosY (RectTransform t, float y)
	{
		return GetNewPos (t, t.anchoredPosition.x, y);
	}
	
	/**
* 座標の変更
* @param t RectTransform
* @param x x
* @param y y
* @return 座標(Vector2)
*/
	public static Vector2 GetNewPos (RectTransform t, float x, float y)
	{
		return new Vector2 (x, y);
	}
	
	//
	//size
	//
	
	/**
* 幅の変更
* @param t RectTransform
* @param x x
*/
	public static void SetWidth (RectTransform t, float x)
	{
		SetSize (t, x, t.sizeDelta.y);
	}
	
	/**
* 高さの変更
* @param t RectTransform
* @param y y
*/
	public static void SetHeight (RectTransform t, float y)
	{
		SetSize (t, t.sizeDelta.x, y);
	}
	
	/**
* サイズの変更
* @param t RectTransform
* @param x x
* @param y y
*/
	public static void SetSize (RectTransform t, float x, float y)
	{
		t.sizeDelta = new Vector2 (x, y);
	}
	
	//
	// scale
	//
	
	/**
* スケールの変更
* @param t RectTransform
* @param x x
*/
	public static void SetScaleX (RectTransform t, float x)
	{
		SetScale (t, x, t.localScale.y);
	}
	
	/**
* スケールの変更
* @param t RectTransform
* @param y y
*/
	public static void SetScaleY (RectTransform t, float y)
	{
		SetScale (t, t.localScale.x, y);
	}
	
	/**
* スケールの変更
* @param t RectTransform
* @param x x
* @param y y
*/
	public static void SetScale (RectTransform t, float x, float y)
	{
		t.localScale = new Vector3 (x, y, 1);
	}
	
}