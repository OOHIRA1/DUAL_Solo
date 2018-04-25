using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==背景のアニメーションを管理するクラス
//
//使用方法：アニメーションをする背景にアタッチ
public class BackgroundAnimationControll : MonoBehaviour {
	Animator _animator;

	// Use this for initialization
	void Start () {
		_animator          = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//---------------------------------------------------------------
	//public関数
	//---------------------------------------------------------------

	//--背景画像を取り外すアニメーションをさせる関数
	public void Remove( ) {
		_animator.SetTrigger ( "removeTrigger" );
	}


	//--背景画像が取り外されたフラグ(removedFlag)を立てる関数
	public void SetRemovedFlag( ) {
		_animator.SetBool ( "removedFlag", true );
	}


	//--背景画像が取り外されたフラグ(removedFlag)の状況を返す関数
	public bool GetRemovedFlag( ) {
		return _animator.GetBool ( "removedFlag" );
	}


	//--Stateがwait状態かどうかを返す関数
	public bool IsStateWait( ) {
		int layer                           = _animator.GetLayerIndex ( "Base Layer" );
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo ( layer );

		return animatorStateInfo.IsName ( "wait" );
	}
		
	//---------------------------------------------------------------
	//---------------------------------------------------------------
}
