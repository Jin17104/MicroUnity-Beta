using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Design : MonoBehaviour {

    public GameObject[] choosen;
    public String GlobelName;
    public GameObject AssestsObj;

    Assests assests; 
    Dropdown DesignSeleted;


    private void Start()
    {
        assests = AssestsObj.GetComponent<Assests>(); 
    }


    private void Update()
    {
        RaycastHit2D hit;
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (hit = Physics2D.Raycast(ray.origin, new Vector2(0, 0)))
        {
            Debug.Log(hit.collider.name);
        }

    }


    public void Identify()
    {
        GameObject DesignObj = GameObject.Find("Design");
        if (DesignObj != null)
        {
            DesignSeleted = DesignObj.GetComponent<Dropdown>();

            switch (DesignSeleted.value)
            {
                case 0: // Terrian

                    foreach (GameObject obj in choosen)
                    {
                        obj.SetActive(false);
                    }
                    choosen[0].SetActive(true);
                    break;

                case 1:// weather 
                    foreach (GameObject obj in choosen)
                    {
                        obj.SetActive(false);
                    }
                    choosen[1].SetActive(true);
                    break;

                case 2:// 3D models 
                    foreach (GameObject obj in choosen)
                    {
                        obj.SetActive(false);
                    }
                    choosen[2].SetActive(true);
                    break;
            }
        }
    }

    public void Selected(string name)
    {
        string newName = name;
        GlobelName = newName;

        switch (newName)
        {
            case "mousePointer":
                break; 

            case "01_Tree":
               
                break;

            case "CartoonHouse":
                break;

            case "Grass":
                break; 
        }

        assests.OtherSelected();
    }
}
