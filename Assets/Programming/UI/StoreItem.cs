using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour {

    public Sprite sprite; 
    Image img;
    public int ItemNumber; 

    string ObjName;

    //Manager 
    GameObject ObjManger;
    _GameManager manager;

    //Store UI 
    GameObject ObjUI;
    Store_UI storeUI; 

    private void Start()
    {

        ObjManger = GameObject.Find("Manager");
        manager = ObjManger.GetComponent<_GameManager>();

        ObjUI = GameObject.Find("UI");
        storeUI = ObjUI.GetComponent<Store_UI>(); 

        img = this.GetComponent<Image>();
        img.sprite = sprite; 
    }

    public void ButtonActive( string name)
    {
        manager.GlobalName = name;

        switch (manager.GlobalName) // IF NEEDED (NOT REALLY NEEDED) 
        {
            case "MousePointer": //Default Mouse 
                break;

            case "00_Tree": 
                break;

        }

        storeUI.OtherSelected();

    }
}
