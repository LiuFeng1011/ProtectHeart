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

    public override void Init()
    {
        base.Init();

        wallZ = 2.5f;

        GameObject mapObj = (GameObject)Resources.Load("Prefabs/MapObj/Map/Map2");

        mapObj = MonoBehaviour.Instantiate(mapObj);

        //life obj
        GameObject lifeobj = (GameObject)Resources.Load("Prefabs/MapObj/Wall/wall_2");

        lifeobj = MonoBehaviour.Instantiate(lifeobj);

        inGameLifeObj = lifeobj.GetComponent<InGameLifeObj>();
        inGameLifeObj.transform.position = new Vector3(0, 0, wallZ);


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
}
