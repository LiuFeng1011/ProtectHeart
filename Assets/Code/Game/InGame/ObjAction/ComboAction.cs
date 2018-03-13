using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAction : BaseUnityObject {

    float x = 0.1f;
    float maxx = 6f;

    public float actionSpeed = 2.5f;
    public float maxScale = 1f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float s = 1;
        if (x >= maxx)
        {
            Destroy(this);
        }
        x += Time.deltaTime * actionSpeed * 2;

        s = GetY(x) * maxScale;
        transform.localScale = new Vector3(s, s, s);
	}

    float GetY(float _x){
        return -Mathf.Sin(_x*5) / (_x*5) + 1;
    }
}
