using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class ModelTextManager : MonoBehaviour {

    const string charName = "Prefabs/Text/model_text_";

    static ModelTextManager instance = null;

    public static ModelTextManager GetInstance(){
        if(instance == null){
            GameObject obj = new GameObject("ModelTextManager");
            instance = obj.AddComponent<ModelTextManager>();
            instance.Load();
        }
        return instance;
    }

    List<List<ModelTextObj>> modelList;

	// Use this for initialization
	void Load () {
        modelList = new List<List<ModelTextObj>>(36);

        //加载模型
        for (int i = 0; i < 36; i ++){
            modelList.Add(new List<ModelTextObj>(10));
            AddNum(i,5);
        }
	}

    ModelTextObj AddNum(int charindex , int count ){
        if(charindex < 0 || charindex >= 36){
            return null;
        }

        string resname = charName + charindex;

        GameObject obj = (GameObject)Resources.Load(resname);

        ModelTextObj mt = null;
        for (int i = 0; i < count; i ++){
            GameObject _obj = MonoBehaviour.Instantiate(obj);
            _obj.SetActive(false);
            mt = _obj.GetComponent<ModelTextObj>();
            modelList[charindex].Add(mt);
        }
        return mt;
    }

    public ModelTextObj GetModelTextObj(char c){
        int charindex = (int)c;

        if(charindex >= 97 && charindex <= 122){
            charindex -= 87;
        }else if (charindex >= 65 && charindex <= 90)
        {
            charindex -= 55;
        }else if (charindex >= 48 && charindex <= 57)
        {
            charindex -= 48;
        }else {
            return null;
        }

        List<ModelTextObj> list = modelList[charindex];

        for (int i = 0; i < list.Count; i ++){
            if(!list[i].gameObject.activeSelf){
                return list[i];
            }
        }

        return AddNum(charindex, 1);

    }
	
    private void OnDestroy()
    {
        instance = null;
    }
}
