using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameItemHeart : InGameBaseItem {
    int reviveCount = 3;
    public override void Hurt(int val)
    {
        base.Hurt(val);
        if (state == enObjState.die)
        {
            InGameManager.GetInstance().inGamePlayerManager.AddLife(reviveCount);
        }
    }
}
