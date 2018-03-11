using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MapObjectConf
{
    public string objid;    /*  道具id    */
    public string name; /*  道具名 */
    public string prefabName;   /*  预制体 */
    public int group;/*   分类   */
    public int layerIndex;   /*地理层级*/
    public string createwithl;  /*  伴随生成  */
    public int isburning;   /*燃烧*/
    public int ispoisoning;   /*毒液*/
    public int isblast;   /*爆炸*/
    public int isironFight;   /*是否铁属性攻击*/
    public int quality;   /*质量(道具被推动时消耗的力)*/
    public int IsCopy;   /* 是否可以再编辑器复制 */
    public int islevitate;/*是否可以悬浮*/
    public int fightType;    /*攻击属性*/
    public int isMove;      /*移动功能*/
    public int speedAdjust;/*速度调节功能*/
    public int openState;   /*开闭状态*/
    public int beLinkWith;  /*被链接搭载*/
    public int linkWith;    /*搭载*/
    public string linkObj; /*  可搭载目标  */
    public int initAspect;  /*初始方向*/
    public int rotateAspect;    /*自转方向*/
    public int isLoad;  /*承载*/
    public string dropOut;/*掉落配置*/
    public int isPush;
    public int StyleCount; /* 样式数量 */
    public int ShadowStyle; /* 影子样式 */

    public override string ToString(){
        return "objid : " + objid + " name : " + name + "  prefabName : " + prefabName;
    }

}


public class ConfMapObjectManager{
    public List<MapObjectConf> datas {get;private set;}

	public void Load(){

		if(datas != null) datas.Clear();

        datas = ConfigManager.Load<MapObjectConf>();
		
	}

}
