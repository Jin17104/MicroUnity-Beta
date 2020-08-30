using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]

public class UserInterface : MonoBehaviour
{
    public GameObject MasterList;
    public GameObject SubList; 
    public GameObject ArrowUp,ArrowDown; 
    public GameObject[] Selection;

    Dropdown masterListDrop;
    Design design;
    Programming program; 

    public static bool BlockedByUI;
    private EventTrigger eventTrigger;

    private void Start()
    {
        Cursor.visible = false;
        eventTrigger = GetComponent<EventTrigger>();
        if (eventTrigger != null)
        {
    
            EventTrigger.Entry enterUIEntry = new EventTrigger.Entry();
            // Pointer Enter
            enterUIEntry.eventID = EventTriggerType.PointerEnter;
            enterUIEntry.callback.AddListener((eventData) => { EnterUI(); });
            eventTrigger.triggers.Add(enterUIEntry);

            //Pointer Exit
            EventTrigger.Entry exitUIEntry = new EventTrigger.Entry();
            exitUIEntry.eventID = EventTriggerType.PointerExit;
            exitUIEntry.callback.AddListener((eventData) => { ExitUI(); });
            eventTrigger.triggers.Add(exitUIEntry);
           
        }


        //Objects 
        masterListDrop = MasterList.GetComponent<Dropdown>();
        design = Selection[0].GetComponent<Design>();

        //Menu Active / noneActive 
        ArrowUp.SetActive(true);
        ArrowDown.SetActive(false);

        MasterList.SetActive(true);
        SubList.SetActive(false); 
    }

    public void EnterUI()
    {
         BlockedByUI = true;
        Cursor.visible = true;

        GameObject GridObj = GameObject.Find("Grid");
        GameObject destroy = GameObject.Find("MousePointer"); 

        if (GridObj != null)
        {
            Grid grid = GridObj.GetComponent<Grid>();
            grid.mousePointer = null;
            Destroy(destroy); 
        }

        //Active non-Active
        ArrowUp.SetActive(false);
        ArrowDown.SetActive(true);

        MasterList.SetActive(true);
        SubList.SetActive(true);


    }

    public void ExitUI()
    {
        BlockedByUI = false;
        Cursor.visible = false;

        //set Active non-active 
        ArrowUp.SetActive(true);
        ArrowDown.SetActive(false);

        MasterList.SetActive(true);
        SubList.SetActive(false);
    }


    private void Update()
    {
        MasterFunction();

        //MemuPops on left if move mouse left 
        Vector3 mouse = Input.mousePosition;
        if (mouse.x <= 100f)
        {
            ArrowUp.SetActive(false);
            ArrowDown.SetActive(true);

            MasterList.SetActive(true);
            SubList.SetActive(true);
        }
    }

    void MasterFunction()
    {
        switch (masterListDrop.value)
        {
            case 0: //Design 
                Selection[0].SetActive(true);
                Selection[1].SetActive(false);
                Selection[2].SetActive(false);

                design.Identify(); // Call Class
                break;

            case 1://Sound 

                Selection[0].SetActive(false);
                Selection[1].SetActive(true);
                Selection[2].SetActive(false);

                break;

            case 2://Programming

                Selection[0].SetActive(false);
                Selection[1].SetActive(false);
                Selection[2].SetActive(true);

                break;
        }
    }
}