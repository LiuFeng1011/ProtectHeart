using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMapManager : BaseGameObject {

    enum enMapSizeDataType
    {
        up,
        down,
        left,
        right
    }

    int[] mapSize = { 25, -5, -8, 8 };

    public override void Init()
    {
        base.Init();

        GameObject mapObj = (GameObject)Resources.Load("Prefabs/MapObj/Map/Map1");

        mapObj = MonoBehaviour.Instantiate(mapObj);

        GameObject ground = new GameObject("ground");
        for (int i = mapSize[(int)enMapSizeDataType.left]; i <= mapSize[(int)enMapSizeDataType.right]; i ++){
            for (int j = mapSize[(int)enMapSizeDataType.down]; j < mapSize[(int)enMapSizeDataType.up]; j ++){

                GameObject obj = (GameObject)Resources.Load("Prefabs/MapObj/Prefabs/Box_A" + Random.Range(1,4));

                obj = MonoBehaviour.Instantiate(obj);
                obj.transform.position = new Vector3(i, -1, j);
                obj.transform.parent = ground.transform;
            }
        }
    }
}
