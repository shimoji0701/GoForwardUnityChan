using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour {
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        this.audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag =="CubePrefabTag" || collision.gameObject.tag == "groundTag") {
            this.audioSource.Play();
        }else {
            this.audioSource.Stop();
        }
    }

}
