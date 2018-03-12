using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseObject {

    public float speed = 0;

    public override void ObjInit()
    {
        base.ObjInit();
        speed = Random.Range(0f, 1f);
    }

    public override void ObjUpdate()
    {
        if (state == enObjState.die) return;
        transform.position = transform.position - new Vector3(0, 0,GetSpeed() * Time.deltaTime);

        if(transform.position.z < 0){
            state = enObjState.die;
            InGameManager.GetInstance().inGamePlayerManager.Hurt(1);
        }

    }

    public float GetSpeed(){
        return conf.speed + speed;
    }

    public override void Die()
    {
        base.Die();
    }
}
