using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBaseItem : BaseObject {

    float showTime = 10f;
    float rotation;

    public bool isHurt = false;
    private void Start()
    {
        rotation = 0;
    }

    public override void ObjUpdate()
    {
        base.ObjUpdate();

        if (state == enObjState.die) return;

        showTime -= Time.deltaTime;
        if(showTime <= 0){
            state = enObjState.die;
        }

        rotation += 360 * Time.deltaTime;
        transform.rotation = Quaternion.Euler( 0, rotation, 0);
    }

    public override void Hurt(int val)
    {
        base.Hurt(val);
    }

    public override void DelSelf()
    {
        if (!isHurt) Destroy(gameObject);
    }


}
