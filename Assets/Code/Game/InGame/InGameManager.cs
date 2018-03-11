using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : BaseUnityObject {
    static InGameManager instance;
    public static InGameManager GetInstance(){
        return instance;
    }

    public InGameObjectManager inGameObjectManager;
    public InGamePlayerManager inGamePlayerManager;

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


        inGameObjectManager = new InGameObjectManager();
        inGameObjectManager.Init();
        inGamePlayerManager = new InGamePlayerManager();
        inGamePlayerManager.Init();
	}
	
	// Update is called once per frame
	void Update () {
        gameTouchController.Update();
        inGameObjectManager.Update();
        inGamePlayerManager.Update();
	}

    private void OnDestroy()
    {
        instance = null;
    }
}
