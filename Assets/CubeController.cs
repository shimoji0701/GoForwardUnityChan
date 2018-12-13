using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
    //キューブの移動速度
    private float speed = -0.2f;
    //消滅位置
    private float deadLine = -11;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //キューブを移動
        transform.Translate(this.speed, 0, 0);
        //画面外に出たら破棄
        if(transform.position.x < deadLine) {
            Destroy(gameObject);
        }
	}
}
