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

    GameObject flag;

    float rotation = 0f;

    bool isStart = false;

    public void BulletInit(Vector3 startPos, Vector3 targetPos,float speed){
        this.targetPos = targetPos;
        this.startPos = startPos;
        this.speed = speed;
        distance = Vector3.Distance(startPos, targetPos);

        maxTime = Vector3.Distance(targetPos, startPos) / speed;

        transform.position = startPos;
        transform.forward = targetPos - startPos;
        //flag

        GameObject obj = (GameObject)Resources.Load("Prefabs/Other/BulletFlag");
        flag = MonoBehaviour.Instantiate(obj);

        flag.transform.position = targetPos;
        flag.transform.localScale = transform.localScale;
        rotation = Random.Range(0, 360);

        //60010012
        (new EventCreateEffect(60010012, gameObject, transform.position, 1f)).Send();
        isStart = true;
    }

    public override void ObjUpdate()
    {
        base.ObjUpdate();
        if (!isStart) return;

        moveTime += Time.deltaTime;
        float rate = moveTime / maxTime;
        Vector3 pos = startPos + (targetPos - startPos) * (rate);
        pos.y = GameCommon.JumpFormula(distance * rate, distance, distance * 0.3f, startPos.y);
        this.transform.position = pos;


        if(moveTime > maxTime){
            state = enObjState.die;
            Bomb();
        }
        rotation += 360 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotation, 0, 0);
    }

    public void Bomb(){
        List<BaseObject> list = InGameManager.GetInstance().inGameObjectManager.GetObjList();

        for (int i = 0; i < list.Count; i ++){
            BaseObject obj = list[i];
            if(obj.conf.type != (int)BaseObject.enObjType.enemy && obj.conf.type != (int)BaseObject.enObjType.item){
                continue;
            }
            float dis = Vector3.Distance(transform.position, obj.transform.position);
            if (dis < (transform.localScale.x + obj.transform.localScale.x) * 0.7f){
                obj.Hurt(10);

                if(obj.state == BaseObject.enObjState.die){
                    Debug.Log("x : " + obj.transform.position.x);
                    InGameManager.GetInstance().inGamePlayerManager.AddScores(Mathf.Abs((int)(obj.transform.position.x * 5)));
                }
            }
        }

        (new EventCreateEffect(conf.dieeffect, null, transform.position, 1f)).Send();
    }

    public override void Die()
    {
        base.Die();
        Destroy(flag);
    }
}
