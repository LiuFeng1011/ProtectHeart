using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlag : MonoBehaviour {

    Transform bulletFlagCircle;

    private void Awake()
    {
        bulletFlagCircle = transform.Find("BulletFlagEffect");
    }
    // Use this for initialization
    void Start () {
        transform.eulerAngles = new Vector3(0,Random.Range(0,360),0);
	}

    public void SetScale(float scale){
        bulletFlagCircle.localScale = new Vector3(scale, scale, scale);
    }

}
