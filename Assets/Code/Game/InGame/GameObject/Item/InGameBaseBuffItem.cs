using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBaseBuffItem : InGameBaseItem {


    public override void Hurt(int val)
    {
        base.Hurt(val);

        if (state == enObjState.die)
        {
            isHurt = true;
            InGameBaseBuff.CreateBuff(this);
        }
    }

}
