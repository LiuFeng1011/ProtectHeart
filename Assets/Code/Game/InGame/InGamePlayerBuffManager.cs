using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePlayerBuffManager : BaseGameObject
{
    float buffScale = 0.5f;
    List<InGameBaseBuff> buffList = new List<InGameBaseBuff>();
    List<InGameBaseBuff> delList = new List<InGameBaseBuff>();

    public override void Init()
    {
        base.Init();
    }

    public override void Update()
    {
        base.Update();

        for (int i = 0; i < buffList.Count; i++)
        {
            buffList[i].Update();
            if (buffList[i].IsOver()){
                delList.Add(buffList[i]);
            }
        }

        for (int i = 0; i < delList.Count; i ++){
            buffList.Remove(delList[i]);
            delList[i].Destroy();
        }

        if(delList.Count > 0){
            ResetPos();
        }

        delList.Clear();
    }

    public void AddBuff(InGameBaseBuff buff){
        buff.obj.transform.localScale = new Vector3(buffScale, buffScale, buffScale);
        buff.obj.transform.rotation = Quaternion.Euler(0, 90, 0);
        buffList.Add(buff);
        ResetPos();
    }

    public void ResetPos(){
        float posy = 0f;
        for (int i = 0; i < buffList.Count; i++)
        {
            buffList[i].targetPos = new Vector3(0, i * buffScale , -0.5f);
        }
    }
}
