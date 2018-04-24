using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==Titleシーンを管理するクラス
//
//使用方法：常にアクティブなゲームオブジェクトにアタッチ
[RequireComponent( typeof(SceneTransition) )]
public class TitleSceneControll : MonoBehaviour {
	SceneTransition _sceneTransition;
	[SerializeField]BackgroundAnimationControll _backgrondAnimationControll = null;

	// Use this for initialization
	void Start () {
		_sceneTransition = GetComponent<SceneTransition> ();
		if (!_backgrondAnimationControll) {
			Debug.LogError ( "_backgrondAnimationControllを設定してください" );
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_backgrondAnimationControll.GetRemovedFlag ()) {
			_sceneTransition.SceneChange ( "StageSelect" );
		}
	}
}
