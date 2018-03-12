using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameObjectManager : BaseGameObject {

    List<BaseObject> objlist = new List<BaseObject>();
    List<BaseObject> delobjlist = new List<BaseObject>();

    public BaseObject AddObj(BaseObject.enObjId objid){
        BaseObject obj = BaseObject.CreateObj(objid);
        if (obj == null) return null;
        objlist.Add(obj);

        return obj;
    }

    public void RemoveObj(BaseObject obj){
        objlist.Remove(obj);
    }

    public override void Update()
    {
        base.Update();

        for (int i = 0; i < objlist.Count; i ++){
            BaseObject obj = objlist[i];
            obj.ObjUpdate();

            if(obj.state == BaseObject.enObjState.die){
                delobjlist.Add(obj);
            }
        }

        while(delobjlist.Count > 0){
            BaseObject obj = delobjlist[0];
            objlist.Remove(delobjlist[0]);
            delobjlist.RemoveAt(0);
            obj.Die();
        }
    }

    public List<BaseObject> GetObjList(){
        return objlist;
    }

}
