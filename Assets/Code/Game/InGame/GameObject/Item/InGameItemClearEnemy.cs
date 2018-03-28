using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameItemClearEnemy : InGameBaseItem {

    public override void Hurt(int val)
    {
        base.Hurt(val);
        if (state == enObjState.die)
        {
            List<BaseObject> list = InGameManager.GetInstance().inGameObjectManager.GetObjList();

            for (int i = 0; i < list.Count; i++)
            {
                BaseObject obj = list[i];
                if (obj.conf.type != (int)BaseObject.enObjType.enemy )
                {
                    continue;
                }
                obj.Hurt(999);
            }


            //特效 60010015

            (new EventCreateEffect(60010015, null, transform.position, -1f)).Send();
        }
    }
}
