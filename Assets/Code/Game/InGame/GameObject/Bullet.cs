using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BaseObject {
    Vector3 targetPos;
    Vector3 startPos;
    float distance;
    float speed;
    float moveTime = 0f;
    float maxTime;
    public void BulletInit(Vector3 startPos, Vector3 targetPos,float speed){
        this.targetPos = targetPos;
        this.startPos = startPos;
        this.speed = speed;
        distance = Vector3.Distance(startPos, targetPos);

        maxTime = Vector3.Distance(targetPos, startPos) / speed;

        transform.position = startPos;
    }

    public override void ObjUpdate()
    {
        base.ObjUpdate();

        moveTime += Time.deltaTime;
        float rate = moveTime / maxTime;
        Vector3 pos = startPos + (targetPos - startPos) * (rate);
        pos.y = GameCommon.JumpFormula(distance * rate, distance, distance * 0.3f);
        this.transform.position = pos;

        if(moveTime > maxTime){
            state = enObjState.die;
        }
    }

    public void Bomb(){
        List<BaseObject> list = InGameManager.GetInstance().inGameObjectManager.GetObjList();

        for (int i = 0; i < list.Count; i ++){
            BaseObject obj = list[i];
            if(obj.conf.type != (int)BaseObject.enObjType.enemy){
                continue;
            }
            float dis = Vector3.Distance(transform.position, obj.transform.position);
            if (dis < (transform.localScale.x + obj.transform.localScale.x) * 0.7f){
                obj.Hurt(10);
            }
        }

    }

    public override void Die()
    {
        base.Die();
        Bomb();
    }
}
