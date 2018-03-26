using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseObject {
    const float jumphigh = 0.5f;
    public float speed = 0;
    Vector3 baseScale;

    GameObject model;
    public override void ObjInit()
    {
        base.ObjInit();
        speed = Random.Range(0f, 1f) - 0.5f;
        baseScale = transform.localScale;

        model = transform.GetChild(0).gameObject;
    }

    public override void ObjUpdate()
    {
        if (state == enObjState.die) return;
        Vector3 pos = transform.position - new Vector3(0,0, GetSpeed() * Time.deltaTime);
        //pos.y = transform.localScale.y / 2;
        transform.position = pos;
            
        if(model != null){
            float y = Mathf.Abs(Mathf.Sin(transform.position.z * 3)) * jumphigh;
            model.transform.localPosition = new Vector3( 0,transform.localScale.y / 2 +  y, 0);
            model.transform.rotation = Quaternion.Euler((y - jumphigh / 2f) * 90, 0, 0);
            transform.localScale = baseScale +  new Vector3(0, y - 0.3f, 0);
        }

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
