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
		const int ANIMATION_FLAME = 90;
		const int MOVE_FLAME = 60;
		const int EXPAND_FLAME = ANIMATION_FLAME - MOVE_FLAME;
		const int MAX_SIZE_X = 180;
		const int MAX_SIZE_Y = 250;
		RectTransform rectTransform = button.GetComponent<RectTransform>();
		Vector2 vec = -rectTransform.anchoredPosition / MOVE_FLAME;
		Vector3 rotation = new Vector3( 0, 180 / MOVE_FLAME, 0);
		Vector2 sizaDelta = new Vector2 ( ( MAX_SIZE_X - rectTransform.sizeDelta.x ) / EXPAND_FLAME, ( MAX_SIZE_Y - rectTransform.sizeDelta.y ) / EXPAND_FLAME );
		for (int i = 0; i < ANIMATION_FLAME; i++) {
			if (i < MOVE_FLAME) {
				rectTransform.anchoredPosition += vec;
				rectTransform.localEulerAngles += rotation;
			} else if (i == MOVE_FLAME) {
				rectTransform.anchoredPosition = Vector2.zero;
				rectTransform.localEulerAngles = new Vector3 (0, 180, 0);
			} else if (i > MOVE_FLAME) {
				rectTransform.sizeDelta += sizaDelta;
			}
			if (i == ANIMATION_FLAME - 1) {
				rectTransform.sizeDelta = new Vector2 ( MAX_SIZE_X, MAX_SIZE_Y );
			}
			yield return null;
		}
	}
	//--------------------------------------------------------
	//----------------------------------------------------------
}
