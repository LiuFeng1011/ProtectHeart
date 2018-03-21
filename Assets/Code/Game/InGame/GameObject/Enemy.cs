using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseObject {

    public float speed = 0;
    Vector3 baseScale;
    public override void ObjInit()
    {
        base.ObjInit();
        speed = Random.Range(0f, 1f);
        baseScale = transform.localScale;
    }

    public override void ObjUpdate()
    {
        if (state == enObjState.die) return;
        Vector3 pos = transform.position - new Vector3(0, 0, GetSpeed() * Time.deltaTime);

        pos.y = Mathf.Abs(Mathf.Sin(transform.position.z*2)) *0.3f;

        transform.position = pos;
        transform.rotation = Quaternion.Euler((pos.y - 0.1f)*90, 0, 0);
        transform.localScale = baseScale + new Vector3(0,pos.y - 0.3f,0);

        if(transform.position.z < InGameManager.GetInstance().inGameMapManager.wallZ + transform.localScale.x / 2){
            state = enObjState.die;
            InGameManager.GetInstance().inGamePlayerManager.Hurt(1);
        }

    }

    public float GetSpeed(){
        return conf.speed + speed;
    }

    public override void Die()
    {
        (new EventCreateEffect(conf.dieeffect, null, transform.position, 1f)).Send();
        base.Die();
    }
}
