using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OrderObj : MonoBehaviour {

    [MenuItem("Edit/OrderObj")]
    static void OrderObjFunction()
    {
        //获取编辑器中当前选中的物体  
        GameObject obj = Selection.activeGameObject;  
        //如果没有选择任何物体，弹出提示并退出  
        if(obj == null){  
            EditorUtility.DisplayDialog("ERROR", "No select obj!!", "ENTRY");  
            return;  
        }

        float x = 0;
        foreach (Transform child in obj.transform)  
        {

            x += 1.0f;
            child.localPosition = new Vector3(x,0,0);
        }  
    }
}
