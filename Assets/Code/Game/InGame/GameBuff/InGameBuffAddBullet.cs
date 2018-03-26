using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBuffAddBullet : InGameBaseBuff {

    int addBulletCount = 2;
    public override void Init()
    {
        base.Init();
        InGameManager.GetInstance().inGamePlayerManager.ChangeBulletMaxCount(addBulletCount);
    }

    public override void Destroy()
    {
        base.Destroy();
        InGameManager.GetInstance().inGamePlayerManager.ChangeBulletMaxCount(-addBulletCount);
    }
}
