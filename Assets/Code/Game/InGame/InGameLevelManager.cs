using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameLevelManager : BaseGameObject {

    float addTime;

    public override void Init()
    {
        base.Init();
        addTime = Random.Range(1f, 2f);
    }

    public override void Update()
    {
        base.Update();

        addTime -= Time.deltaTime;
        if (addTime > 0) return;

        addTime = Random.Range(1f, 2f);


        BaseObject obj = InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.enemy_1);
        obj.transform.position = new Vector3(-3f + Random.Range(0, 6f), 0, 13);

    }
}
