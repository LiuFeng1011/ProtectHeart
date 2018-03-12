using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerManager : BaseGameObject
{

    public int life { get;private set;}

	// Use this for initialization
    public override void Init () {
        BaseObject obj = InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.role_1);
        obj.transform.position = new Vector3(0, 0, 1f);

        life = 10;
	}
	
    public void Hurt(int val){
        life -= val;
        if (life <= 0){
            
        }
    }
}
