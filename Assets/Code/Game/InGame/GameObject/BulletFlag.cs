using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlag : MonoBehaviour {
    const float scale = 0.5f;
	// Use this for initialization
	void Start () {

        transform.localScale = new Vector3(0,0,0);
        transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
	}

}
