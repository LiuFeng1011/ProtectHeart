using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MapObjectConf
{
    public int objid;    /*  道具id    */
    public string name; /*  道具名 */
    public string prefabName;   /*  预制体 */
    public int type;/*   "种类
    1角色
    2敌人
    3子弹
    4装饰" 
    */
    public float speed;/*  移动速度    */
    public int life;/* 生命 */
}


public class ConfMapObjectManager{
    public List<MapObjectConf> datas {get;private set;}
    public Dictionary<int, MapObjectConf> dic = new Dictionary<int, MapObjectConf>();

	public void Load(){

		if(datas != null) datas.Clear();

        datas = ConfigManager.Load<MapObjectConf>();
        dic.Clear();

        for (int i = 0; i < datas.Count; i++)
        {
            dic.Add(datas[i].objid, datas[i]);
        }
	}


}
