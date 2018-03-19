using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBombEffect : MonoBehaviour {
    const float startLight = 10f;
    const float time = 1f;

    Light light = null;
    private void Awake()
    {
        light = transform.GetComponent<Light>(); 
    }
    // Use this for initialization
    void Start () {
        
	}
    private void OnEnable()
    {
        light.range = startLight;
    }
    // Update is called once per frame
    void Update () {
        if(light.range > 0){
            light.range -= Time.deltaTime*(startLight / time);
        }
	}
}
