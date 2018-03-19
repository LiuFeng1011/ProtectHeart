using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : BaseObject {

	// Use this for initialization
	void Start () {
        EventManager.Register(this,EventID.EVENT_TOUCH_MAP);

	}
	
	// Update is called once per frame
	void Update () {
		
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

    void Fire(Vector3 targetPos){
        Bullet b = (Bullet)InGameManager.GetInstance().inGameObjectManager.AddObj(BaseObject.enObjId.bullet_1);
        b.BulletInit(transform.position,targetPos,5);
    }
}
