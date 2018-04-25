using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==Titleシーンを管理するクラス
//
//使用方法：常にアクティブなゲームオブジェクトにアタッチ
[RequireComponent( typeof(SceneTransition) )]
public class TitleSceneControll : MonoBehaviour {
	enum Phase {	//画面フェーズを表す列挙体
		ATTACH,	//背景取付
		WAIT,	//待機
		REMOVE	//背景取り外し
	};

	Phase _nowPhase;
	SceneTransition _sceneTransition;
	[SerializeField]BackgroundAnimationControll _backgrondAnimationControll = null;
	[SerializeField]GameObject _canvas = null;


	// Use this for initialization
	void Start () {
		_nowPhase = Phase.ATTACH;
		_sceneTransition = GetComponent<SceneTransition> ();
		if (!_backgrondAnimationControll) {
			Debug.LogError ( "_backgrondAnimationControllを設定してください" );
			UnityEditor.EditorApplication.isPlaying = false;
		}
		if (!_canvas) {
			Debug.LogError ( "_canvasを設定してください" );
			UnityEditor.EditorApplication.isPlaying = false;
		} else {
			_canvas.SetActive ( false );
		}
	}


	// Update is called once per frame
	void Update () {
		
		//フェーズごとに処理を行う------------------------------------
		switch (_nowPhase) {
		case Phase.ATTACH:
			if (_backgrondAnimationControll.IsStateWait ()) {
				_canvas.SetActive (true);
				_nowPhase = Phase.WAIT;
			}
			break;
		case Phase.WAIT:
			break;
		case Phase.REMOVE:
			if (_backgrondAnimationControll.GetRemovedFlag ()) {
				_sceneTransition.SceneChange ( "StageSelect" );
			}
			break;
		default:
			break;
		}
		//-----------------------------------------------------------

		Debug.Log ("TitlePhase:" + _nowPhase);
	}


	//----------------------------------------------------------------
	//public関数
	//----------------------------------------------------------------

	//--ボタンが押された時の処理をする関数
	public void OnClicked() {
		_backgrondAnimationControll.Remove ();
		_canvas.SetActive (false);
		_nowPhase = Phase.REMOVE;
	}
	//-----------------------------------------------------------------
	//----------------------------------------------------------------
}
