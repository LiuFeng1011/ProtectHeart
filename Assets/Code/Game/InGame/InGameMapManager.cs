using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMapManager : BaseGameObject {

    public enum enMapSizeDataType
    {
        up,
        down,
        left,
        right
    }

    int[] mapSize = { 25, -5, -8, 8 };

    InGameLifeObj inGameLifeObj;

    public float wallZ { get; private set; }

    float updateTime = 0;

    //分数
    ModelText scoresnum;
    int targetScores = 0, nowScores = 0;

    public override void Init()
    {
        base.Init();

        EventManager.Register(this,EventID.EVENT_INGAME_CHANGE_SCORES);

        wallZ = 2.5f;

        GameObject mapObj = (GameObject)Resources.Load("Prefabs/MapObj/Map/Map2");

        mapObj = MonoBehaviour.Instantiate(mapObj);

        //life obj
        GameObject lifeobj = (GameObject)Resources.Load("Prefabs/MapObj/Wall/wall_2");

        lifeobj = MonoBehaviour.Instantiate(lifeobj);

        inGameLifeObj = lifeobj.GetComponent<InGameLifeObj>();
        inGameLifeObj.transform.position = new Vector3(0, 0, wallZ);


        //scores text
        Transform scoresPos = mapObj.transform.Find("scoresPos");

        ModelText scores = ModelText.Create("scores", "scores");
        scores.spacing = 0.7f;
        scores.transform.position = scoresPos.position;
        scores.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        scores.transform.rotation = Quaternion.Euler(75, -90, 0);
        scores.SetColor(new Color(1f, 190f / 255f, 9f / 255f));

        scoresnum = ModelText.Create("scoresnum", "0");
        scoresnum.spacing = 0.7f;
        scoresnum.transform.position = scoresPos.position + new Vector3(0.7f, 0, 0);
        scoresnum.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        scoresnum.transform.rotation = Quaternion.Euler(75, -90, 0);
        scoresnum.SetColor(new Color(1, 102f / 255f ,0));


        //GameObject ground = new GameObject("ground");
        //for (int i = mapSize[(int)enMapSizeDataType.left]; i <= mapSize[(int)enMapSizeDataType.right]; i ++){
        //    for (int j = mapSize[(int)enMapSizeDataType.down]; j < mapSize[(int)enMapSizeDataType.up]; j ++){

        //        GameObject obj = (GameObject)Resources.Load("Prefabs/MapObj/Prefabs/Box_A" + Random.Range(1,4));

        //        obj = MonoBehaviour.Instantiate(obj);
        //        obj.transform.position = new Vector3(i, -1, j);
        //        obj.transform.parent = ground.transform;
        //    }
        //}
    }

    public override void HandleEvent(EventData resp)
    {
        base.HandleEvent(resp);

        switch(resp.eid){
            case EventID.EVENT_INGAME_CHANGE_SCORES:
                EventInGameChangeScores e = (EventInGameChangeScores)resp;
                targetScores = e.val;
                break;
        }
    }

    public override void Update()
    {
        base.Update();

        updateTime -= Time.deltaTime;
        if(updateTime > 0){
            return;
        }
        updateTime = 0.2f;
        if(nowScores != targetScores){
            nowScores += (int)((targetScores - nowScores) * 0.5f);
            if (Mathf.Abs(nowScores - targetScores) < 2) nowScores = targetScores;
            scoresnum.SetText(nowScores.ToString());
        }
    }


    public override void Destroy()
    {
        base.Destroy();
        EventManager.Remove(this);
    }
}
