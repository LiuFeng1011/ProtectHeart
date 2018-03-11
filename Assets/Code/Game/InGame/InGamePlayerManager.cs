using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerManager : BaseGameObject {

	// Use this for initialization
    public override void Init () {
        BaseObject obj = InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.role_1);
        obj.transform.position = new Vector3(0, 0, 1f);

	}
	
}
