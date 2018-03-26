using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameBuffFast : InGameBaseBuff {

    int addBulletSpeed = 1;
    public override void Init()
    {
        base.Init();
        InGameManager.GetInstance().inGamePlayerManager.ChangeBulletSpeed(addBulletSpeed);
    }

    public override void Destroy()
    {
        base.Destroy();
        InGameManager.GetInstance().inGamePlayerManager.ChangeBulletSpeed(-addBulletSpeed);
    }
}
