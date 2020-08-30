using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class StoreInterface : MonoBehaviour {

    public GameObject[] UIObj;

    public static bool BlockedByUI;
    private EventTrigger eventTrigger;

    //GRAB UI 
    GameObject UI;
    Store_UI store_ui;

    GameObject m_Remove;
    public bool create_Remove; 

    private void Start()
    {
       

        UIObj[0].SetActive(false);
        UIObj[1].SetActive(true);

        UI = GameObject.Find("UI");
        store_ui = UI.GetComponent<Store_UI>(); 

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
    }

    public void ButtonClicked(string name)
    {
        switch (name)
        {
            case "X":
                UIObj[0].SetActive(false);
                UIObj[1].SetActive(true);
                break;

            case "Store":
                UIObj[0].SetActive(true);
                UIObj[1].SetActive(false);
                break;

            case "ColorWheel":
                break;

            case "1":
                UIObj[2].SetActive(true);
                UIObj[3].SetActive(false);
                break;

            case "2":
                UIObj[3].SetActive(true);
                UIObj[2].SetActive(false);
                break;

            case "3":
                break;
        }
    }


    public void EnterUI()
    {
        store_ui.canPlace = false;
        BlockedByUI = true;
        Cursor.visible = true;

        m_Remove = GameObject.Find("MousePointer");
        if (m_Remove != null)
        {
            Destroy(m_Remove); 
        }
    }

    public void ExitUI()
    {
        BlockedByUI = false;
        Cursor.visible = false;
        store_ui.canPlace = true;
    }

}
