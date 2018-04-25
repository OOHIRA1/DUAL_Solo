using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//==StageButtonのアニメーションを管理するクラス
//
//使用方法：全てのボタンの親オブジェクトにアタッチ
public class StageButtonAnimationControll : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//--------------------------------------------------------
	//public関数
	//---------------------------------------------------------

	//--ボタンをアップする関数
	public void Up( GameObject x ) {
		//RectTransform rectTransform = x.gameObject.GetComponent<RectTransform>();
		//rectTransform.anchoredPosition = new Vector2 ( 0, 0 );
		StartCoroutine( "UpCoroutin", x );
	}

	public IEnumerator UpCoroutin( GameObject button ) {
		const int ANIMATIONFLAME = 90;
		RectTransform rectTransform = button.GetComponent<RectTransform>();
		Vector2 vec = -rectTransform.anchoredPosition / ( ANIMATIONFLAME - 30 );
		Vector3 rotation = new Vector3( 0, 180 / (ANIMATIONFLAME - 30), 0);
		for (int i = 0; i < ANIMATIONFLAME; i++) {
			if (i < ANIMATIONFLAME - 30) {
				rectTransform.anchoredPosition += vec;
				rectTransform.localEulerAngles += rotation;
			} else if (i == ANIMATIONFLAME - 30) {
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.localEulerAngles = new Vector3 ( 0, 180, 0 );
			}
			yield return null;
		}
	}
	//--------------------------------------------------------
	//----------------------------------------------------------
}
