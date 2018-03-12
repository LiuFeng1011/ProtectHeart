using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : BaseGameObject {
    
    Camera camera;

    public float validTouchDistance; //200  

    public TouchManager(){
        camera = Camera.main;
        validTouchDistance = 200;

        EventManager.Register(this,
                       EventID.EVENT_TOUCH_DOWN);
    }

    public override void Destroy()
    {
        EventManager.Remove(this);
    }

    public override void HandleEvent(EventData resp)
    {

        switch (resp.eid)
        {
            case EventID.EVENT_TOUCH_DOWN:
                EventTouch eve = (EventTouch)resp;
                TouchToPlane(eve.pos);
                //Fire(GameCommon.ScreenPositionToWorld(eve.pos));
                break;
        }

    }

    public void TouchToPlane(Vector3 pos){
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;  

        if (Physics.Raycast(ray, out hitInfo , validTouchDistance , LayerMask.GetMask("groundPlane") ))  
        {  
            GameObject gameObj = hitInfo.collider.gameObject;  
            Vector3 hitPoint = hitInfo.point;

            (new EventTouchMap(hitPoint)).Send();
 
        }  

    }

}
