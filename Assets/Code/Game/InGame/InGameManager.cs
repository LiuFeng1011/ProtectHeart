using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour {
    static InGameManager instance;

    GameTouchController gameTouchController;
    TouchManager touchManager;

    private void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
        gameTouchController = new GameTouchController();
        touchManager = new TouchManager();
	}
	
	// Update is called once per frame
	void Update () {
        gameTouchController.Update();
	}

    private void OnDestroy()
    {
        instance = null;
    }
}
