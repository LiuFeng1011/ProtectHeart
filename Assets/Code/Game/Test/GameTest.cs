using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTest : MonoBehaviour {
    ModelText mt;

    public string s = "scoreS";
    public string lasts = "scoreS";
	// Use this for initialization
	void Start () {
        mt = ModelText.Create("abc","scoreS");
	}
	
	// Update is called once per frame
	void Update () {
        if(s != lasts){
            lasts = s;
            mt.SetText(s);
        }
	}


}
