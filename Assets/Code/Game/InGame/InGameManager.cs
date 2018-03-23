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
    public InGameLevelManager inGameLevelManager;
    public InGameMapManager inGameMapManager;
    public GameEffectManager gameEffectManager;

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

        gameEffectManager = new GameEffectManager();

        inGameObjectManager = new InGameObjectManager();
        inGameObjectManager.Init();
        inGamePlayerManager = new InGamePlayerManager();
        inGamePlayerManager.Init();
        inGameLevelManager = new InGameLevelManager();
        inGameLevelManager.Init();
        inGameMapManager = new InGameMapManager();
        inGameMapManager.Init();


	}
	
	// Update is called once per frame
	void Update () {
        if(gameTouchController != null) gameTouchController.Update();
        if (inGameObjectManager != null)inGameObjectManager.Update();
        if (inGamePlayerManager != null)inGamePlayerManager.Update();
        if (inGameLevelManager != null) inGameLevelManager.Update();
        if (inGameMapManager != null) inGameMapManager.Update();

	}

    private void OnDestroy()
    {
        instance = null;
        if(touchManager != null)        touchManager.Destroy();
        if (inGameObjectManager != null)inGameObjectManager.Destroy();
        if (inGamePlayerManager != null)inGamePlayerManager.Destroy();
        if (inGameLevelManager != null) inGameLevelManager.Destroy();
        if (inGameMapManager != null) inGameMapManager.Destroy();
        if (gameEffectManager != null) gameEffectManager.Destroy();
    }
}
