using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : BaseObject {
    
    List<Bullet> bulletList ;
    Bullet readyBullet = null;

    float addBulletTime = 0f, addBulletMaxTime = 1f, setReadyBulletTime = 0f, setReadyBulletMaxTime = 0.2f;

	// Use this for initialization
	void Start () {
        EventManager.Register(this,EventID.EVENT_TOUCH_MAP);

        bulletList = new List<Bullet>();

        AddBullet(InGameManager.GetInstance().inGamePlayerManager.GetBulletMaxCount());
	}

    // Update is called once per frame
    public override void ObjUpdate()
    {
        base.ObjUpdate();

        if (bulletList == null) return;

        setReadyBulletTime -= Time.deltaTime;
        if(setReadyBulletTime <= 0 && readyBullet == null  && bulletList.Count > 0){
            SetReadyBullet();
        }

        if (bulletList.Count >= InGameManager.GetInstance().inGamePlayerManager.GetBulletMaxCount()) return;
        addBulletTime -= Time.deltaTime;
        if (addBulletTime > 0) return;
        addBulletTime = addBulletMaxTime;
        AddBullet(1);
    }

    void SetReadyBullet(){

        readyBullet = bulletList[bulletList.Count - 1];
        bulletList.RemoveAt(bulletList.Count - 1);
        readyBullet.transform.position = transform.position;
    }

    void AddBullet(int count){
        for (int i = 0; i < count; i ++){
            Bullet b = (Bullet)InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.bullet_1);
            bulletList.Add(b);
            b.transform.position = transform.position + new Vector3(0, (bulletList.Count - 1 )* b.transform.localScale.y, -transform.localScale.z);
            b.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }

    void Fire(Vector3 targetPos){
        if(readyBullet == null){
            return;
        }
        readyBullet.BulletInit(transform.position,targetPos,InGameManager.GetInstance().inGamePlayerManager.GetBulletSpeed());
        readyBullet = null;
        setReadyBulletTime = setReadyBulletMaxTime;
    }

    public override void HandleEvent(EventData resp)
    {
        switch (resp.eid)
        {
            case EventID.EVENT_TOUCH_MAP:
                EventTouchMap tm = (EventTouchMap)resp;
                Fire(tm.pos);
                break;
        }
    }
    private void OnDestroy()
    {
        EventManager.Remove(this);
    }

}
