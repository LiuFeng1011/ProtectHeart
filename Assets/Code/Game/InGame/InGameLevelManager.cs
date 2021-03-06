﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameLevelManager : BaseGameObject {

    float addTime;

    float addItemTime;

    public override void Init()
    {
        base.Init();
        addTime = Random.Range(1f, 2f);
        addItemTime = Random.Range(5f, 10f);
    }

    public override void Update()
    {
        base.Update();

        addTime -= Time.deltaTime;
        addItemTime -= Time.deltaTime;
        if (addTime > 0) return;

        addTime = Random.Range(1f, 2f);


        BaseObject obj = InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.enemy_1);
        obj.transform.position = new Vector3(-3f + Random.Range(0, 6f), 0, 13);
        //60010013
        (new EventCreateEffect(60010013, null, obj.transform.position, 0.8f)).Send();
        if(addItemTime < 0){
            obj.AddItem((BaseObject.enObjId)ConfigManager.confMapObjectManager.GetRandomObjByType((int)BaseObject.enObjType.item).objid);
            addItemTime = Random.Range(5f, 15f);

            //特效 60010016
            (new EventCreateEffect(60010016, obj.gameObject, obj.transform.position, -1f)).Send();
        }

    }
}
