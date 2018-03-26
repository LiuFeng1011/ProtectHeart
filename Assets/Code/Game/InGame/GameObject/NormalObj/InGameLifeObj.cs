using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameLifeObj : BaseUnityObject {
    Material material;
    BoxCollider bc;

    float nowval = 1,targetval;

    float baseRX = -20;
    float shakeTime = 0f;
	// Use this for initialization
	void Start () {
        EventManager.instance().RegisterObj(this,EventID.EVENT_INGAME_CHANGE_LIFE);

        bc = transform.GetComponent<BoxCollider>();
        material = transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial;
        material.SetFloat("_ParentX", transform.position.x);  
        material.SetFloat("_ParentWidth", bc.size.x);

        targetval = nowval;
        material.SetFloat("_LifeRate",nowval);    

        transform.rotation = Quaternion.Euler(baseRX, 0, 0);
	}

	// Update is called once per frame
    void Update () {

        if(shakeTime > 0){
            shakeTime -= Time.deltaTime;
            transform.rotation = Quaternion.Euler(baseRX + GetY((1 - shakeTime)* 20) * 3 , 0, 0);
        }

        if(nowval != targetval){
            nowval += (targetval - nowval) * 0.3f;
            if (Mathf.Abs(nowval - targetval) < 0.01f){
                nowval = targetval;
            }
        }else{
            return;
        }

        material.SetFloat("_LifeRate",nowval);    
	}

    public void SetVal(float val){
        if(targetval > val) shakeTime = 1f;
        targetval = val;
    }
    public override void HandleEvent(EventData resp)
    {

        switch (resp.eid)
        {
            case EventID.EVENT_INGAME_CHANGE_LIFE:
                EventInGameChangeLife eve = (EventInGameChangeLife)resp;
                SetVal(eve.rate);
                break;
        }

    }
    private void OnDestroy()
    {
        EventManager.instance().RemoveObj(this);
    }

    float GetY(float _x)
    {
        return -Mathf.Sin(_x ) / (_x);
    }
}
