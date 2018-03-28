using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBaseBuff : BaseGameObject {

    public InGameBaseItem obj;

    float lifeTime;

    public Vector3 targetPos = Vector3.zero;

    public static InGameBaseBuff CreateBuff(InGameBaseItem item)
    {
        InGameBaseBuff ret = null;
        switch((BaseObject.enObjId)item.conf.objid){
            case BaseObject.enObjId.addbullet:
                ret = new InGameBuffAddBullet();
                break;
            case BaseObject.enObjId.fastforward:
                ret = new InGameBuffFast();
                break;
            default:
                break;
        }

        if(ret != null){
            ret.Init();
            ret.obj = item;
            InGameManager.GetInstance().inGamePlayerManager.AddBuff(ret);
        }

        return ret;
    }

    public override void Init()
    {
        base.Init();
        lifeTime = 20f;
    }

    public override void Update()
    {
        base.Update();
        lifeTime -= Time.deltaTime;

        obj.transform.position =obj.transform.position + (targetPos - obj.transform.position) * 0.3f;
    }

    public bool IsOver(){
        return lifeTime <= 0;
    }

    public override void Destroy()
    {
        base.Destroy();
        GameObject.Destroy(obj.gameObject);
    }
}
