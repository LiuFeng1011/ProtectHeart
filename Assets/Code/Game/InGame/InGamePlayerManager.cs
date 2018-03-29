using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerManager : BaseGameObject
{
    int maxLife = 10;
    public int life { get;private set;}

    InGamePlayerBuffManager inGamePlayerBuffManager = new InGamePlayerBuffManager();

    Role role;

    float bulletSpeed;
    int maxBulletCount;

    int scores,combo;

	// Use this for initialization
    public override void Init () {
        role = InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.role_1) as Role;
        role.transform.position = new Vector3(0, 0, 1f);


        life = maxLife;
        maxBulletCount = 5;
        bulletSpeed = 5;
	}

    public override void Update(){
        inGamePlayerBuffManager.Update();
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

    public void AddScores(int val){
        scores += val;

        (new EventInGameChangeScores(scores)).Send();
    }

    public void AddCombo(){
        combo += 1;
    }

    public void CancleCombo(){
        combo = 0;
    }

    public void AddBuff(InGameBaseBuff buff){
        inGamePlayerBuffManager.AddBuff(buff);
    }

    public void ChangeBulletSpeed(float val){
        bulletSpeed += val;
    }
    public float GetBulletSpeed(){
        return bulletSpeed;
    }

    public void ChangeBulletMaxCount(int val)
    {
        maxBulletCount += val;
    }
    public int GetBulletMaxCount()
    {
        return maxBulletCount;
    }
}
