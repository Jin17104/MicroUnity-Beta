using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Programming : MonoBehaviour {

    //Quick Mouse Change 
    public GameObject SpawnPoint; 

    public string GlobalString;
    public float GlobalFloat;
    bool switchDataType = true; 

    GameObject ObjString, ObjInt, GlobalObj;

    //Grab Other Scripts; 
    GameObject ObjManager;
    _GameManager manager; 

    private void Start()
    {
        GlobalObj= GameObject.Find("ProgramingUI");
        ObjString = GameObject.Find("StringInput");
        ObjInt = GameObject.Find("IntInput");

        ObjString.SetActive(true);
        ObjInt.SetActive(false); 

        if (GlobalObj != null)
        {
            GlobalObj.SetActive(false); 
        }

        ObjManager = GameObject.Find("Manager");
        if (ObjManager != null)
        {
            manager = ObjManager.GetComponent<_GameManager>(); 
        }
    }

    private void Update()
    {
        //Call Input On Screen 
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.C))
        {
            GlobalObj.SetActive(true);
        }
        SwitchSytem(); 
    }

    public void CheckString(string StringInput)
    {
        InputField _String = ObjString.GetComponent<InputField>();
        _String.interactable = true; 
        GlobalString = _String.text;

        switch (GlobalString)
        {
            case "manager.food =":
                //  Debug.Log(GlobalString);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    _String.text = "";
                    switchDataType = false; 
                }
                break;
            case "spawnpoint":
                GameObject UI = GameObject.Find("UI");
                Store_UI store = UI.GetComponent<Store_UI>();
                store.mousePointer = null;
                GameObject cloneSpawn = (GameObject)Instantiate(SpawnPoint, transform.position, Quaternion.identity);
                store.mousePointer = cloneSpawn; 
                break; 
        }     
    }

    public void CheckInt()
    {
        InputField _Int = ObjInt.GetComponent<InputField>();

        switch (GlobalString)
        {
            case "manager.food":
                    
                if (Input.GetKeyDown(KeyCode.Return))
                {               
                    GlobalFloat = (float)float.Parse(_Int.text);
                    manager.Food = GlobalFloat;
                    //Close 
                    _Int.text = "";
                    switchDataType = true;
                }

                break;
        }
    }

    void SwitchSytem()
    {
        InputField _String = ObjString.GetComponent<InputField>();

        if (switchDataType)
        {
            CheckString(_String.text);
            ObjString.SetActive(true);
            ObjInt.SetActive(false);
        }
        else
        {
            CheckInt();
            ObjString.SetActive(false);
            ObjInt.SetActive(true);
        }
    }
}
