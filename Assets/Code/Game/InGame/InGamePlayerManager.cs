using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerManager : BaseGameObject
{
    int maxLife = 10;
    public int life { get;private set;}

	// Use this for initialization
    public override void Init () {
        BaseObject obj = InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.role_1);
        obj.transform.position = new Vector3(0, 0, 1f);


        life = maxLife;
	}
	
    public void Hurt(int val){
        if(life <= 0){
            return;
        }
        life -= val;

        //inGameLifeObj.SetVal(life / maxLife);
        (new EventInGameChangeLife(life, (float)life / (float)maxLife)).Send();
        if (life <= 0){
            
        }
    }

    public void AddLife(int val){
        life = Mathf.Min(life + val, maxLife);
        (new EventInGameChangeLife(life, (float)life / (float)maxLife)).Send();
    }
}
