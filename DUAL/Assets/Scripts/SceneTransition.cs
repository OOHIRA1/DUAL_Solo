using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//==シーン遷移機能を付けるクラス
//
//使い方：シーン遷移機能を付けたいGameObjectにアタッチ
public class SceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//-----------------------------------------------------------
	//public関数
	//-----------------------------------------------------------

	//--シーン遷移をする関数
	public void SceneChange( string nextScene ) {
		SceneManager.LoadScene ( nextScene );
	}
	//-----------------------------------------------------------
	//-----------------------------------------------------------
}
