using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : BaseUnityObject {
    public enum enObjId
    {
        role_1 = 1001,
        role_2 = 1002,
        role_3 = 1003,
        role_4 = 1004,

        enemy_1 = 2001,
        enemy_2 = 2002,
        enemy_3 = 2003,
        enemy_4 = 2004,
        enemy_5 = 2005,
        enemy_6 = 2006,

        bullet_1 = 3001,
    }

    public enum enObjType{
        role = 1,//1角色
        enemy = 2,//2敌人
        bullet = 3,//3子弹
        mapobj = 4//4装饰
    }

    public enum enObjState
    {
        normal,
        pause,
        die
    }

    protected Animator anim;

    public MapObjectConf conf{ get; private set; }

    public enObjState state;

    public int life{ get; protected set; }

    public static BaseObject CreateObj(enObjId objid){
        MapObjectConf conf = ConfigManager.confMapObjectManager.dic[(int)objid];
        if (conf == null) return null;
        Debug.Log(conf.prefabName);
        GameObject obj = (GameObject)Resources.Load(conf.prefabName);

        obj = MonoBehaviour.Instantiate(obj);

        BaseObject baseobj = obj.GetComponent<BaseObject>();
        baseobj.conf = conf;
        baseobj.ObjInit();
        return baseobj;
    }
	
    public virtual void ObjInit(){
        state = enObjState.normal;
        life = conf.life;

        anim = this.GetComponent<Animator>();

    }
    public virtual void ObjUpdate(){
        
    }

    public virtual void Hurt(int val){
        life -= val;
        if (life <= 0){
            state = enObjState.die;
        }
    }

    public virtual void Die(){
        if(anim == null){
            DelSelf();
        }else{
            anim.SetBool("isdeath",true);
            Invoke("DelSelf",1f);
        }

    }

    void DelSelf(){
        Destroy(gameObject);
    }
}
