using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
    //アニメーションするためのコンポーネントを入れる
    Animator animator;
    //Unityちゃんを移動させるコンポーネントを入れる
    Rigidbody2D rigid2D;

    //地面の位置
    private float groundLevel = -3.0f;

    //ジャンプの速度を減衰
    private float dump = 0.8f;
    //ジャンプの速度
    float jumpVelocity = 20;
    //ゲームオーバーになる位置
    private float deadLine = -10;


	// Use this for initialization
	void Start () {
        //アニメータのコンポーネントを取得
        this.animator = GetComponent<Animator>();
        //Rididbody2Dのコンポーネントを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //走るアニメーションを再生するために、Animatorのパラメーターを調整
        this.animator.SetFloat("Horizontal", 1);

        //着地しているかどうか調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        //上の文をif else で書いた場合
        //bool isGround;
        //if(transform.position.y > this.groundLevel) {
            //isGround = false;
        //}else{ isGround = true; }
        this.animator.SetBool("isGround", isGround);

        //ジャンプ状態のときボリュームを０にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされた場合
        if(Input.GetMouseButtonDown(0) && isGround) {
            //上方向の力をかける
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        //クリックをやめたら上方向の速度を減速
        if(Input.GetMouseButton(0) == false) {
            if(this.rigid2D.velocity.y > 0) {
                this.rigid2D.velocity *= this.dump;
            }
        }
        //デッドラインを超えた場合ゲームオーバーにする
        if(transform.position.x < this.deadLine) {
            //UIControllerのGameOver関数を呼び出して画面上に「GAMEOVER」を表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //Unityちゃんを破棄
            Destroy(gameObject);
        }
	}
}
