using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelText : MonoBehaviour {

    public enum Pivot
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight,
    }

    public  Pivot mPivot = Pivot.Center,lastPivot = Pivot.Center;

    public float spacing = 1f, lastSpacing = 1f;

    Material m;

    public static ModelText Create(string name,string s){
        GameObject obj = new GameObject(name);
        ModelText mt = obj.AddComponent<ModelText>();
        mt.Init();
        mt.SetText(s);
        return mt;
    }

    List<ModelTextObj> modelList = new List<ModelTextObj>();

    public void Init(){
        m = new Material(Shader.Find("Custom/InGameItemShader")); 
    }
    //设置内容
    public void SetText(string s){
        //
        for (int i = 0; i < modelList.Count; i++)
        {
            modelList[i].gameObject.SetActive(false);
            modelList[i].transform.parent = null;
        }
        modelList.Clear();

        byte[] byteArray = System.Text.Encoding.Default.GetBytes(s);

        for (int i = 0; i < byteArray.Length; i ++){
            ModelTextObj obj = ModelTextManager.GetInstance().GetModelTextObj((char)byteArray[i]);
            modelList.Add(obj);
            obj.gameObject.SetActive(true);
            obj.transform.parent = transform;
            obj.textobj.GetComponent<Renderer>().material = m;

            obj.transform.localRotation = Quaternion.Euler(new Vector3(0,180,0));
            obj.transform.localScale = new Vector3(1, 1, 1);
        }
        SetObjPos();
    }

    //设置坐标
    public void SetObjPos(){
        float basewidht = 0;
        float baseheight = 0;
        float allwidht = modelList.Count * spacing;

        //widht
        if (mPivot == Pivot.BottomLeft || mPivot == Pivot.Left || mPivot == Pivot.TopLeft)
        {
            basewidht = 0;
        }
        else if (mPivot == Pivot.BottomRight || mPivot == Pivot.Right || mPivot == Pivot.TopRight)
        {
            basewidht = allwidht;
        }else{
            basewidht = allwidht / 2;
        }
        //height
        if (mPivot == Pivot.BottomLeft || mPivot == Pivot.Bottom || mPivot == Pivot.BottomRight)
        {
            baseheight = 0;
        }
        else if (mPivot == Pivot.TopLeft || mPivot == Pivot.Top || mPivot == Pivot.TopRight)
        {
            baseheight = 1;
        }else{
            baseheight = 0.5f;
        }

        for (int i = 0; i < modelList.Count; i ++){
            modelList[i].transform.localPosition = new Vector3(i * spacing - basewidht, baseheight, 0);
        }
    }

    public void SetColor(Color c){
        m.SetColor("_Color", c);  
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(mPivot != lastPivot ){
            lastPivot = mPivot;
            SetObjPos();
        }
        if(spacing != lastSpacing){
            lastSpacing = spacing;
            SetObjPos();
        }
	}

    private void OnDestroy()
    {
        //for (int i = 0; i < modelList.Count; i++)
        //{
        //    modelList[i].gameObject.SetActive(false);
        //    modelList[i].transform.parent = null;
        //}
    }
}
