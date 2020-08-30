using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;

public class Store_UI : MonoBehaviour {

    public GameObject[] OriginalObject;
    public GameObject mousePointer;

    //Instance Vectors 
    bool createOnce = true;
    Vector3 MouseLocation;
    Vector3 MouseRotation;
    Button thisButton; 

    //Manager
    GameObject ObjManger;
    _GameManager manager;

    public bool canPlace = false;
    GameObject StoreUI; 


    private void Start()
    {
        StoreUI = GameObject.Find("UI"); 

        ObjManger = GameObject.Find("Manager");
        manager = ObjManger.GetComponent<_GameManager>();

        thisButton = this.GetComponent<Button>();


        if (createOnce)
        {
            GameObject startPointer = (GameObject)Instantiate(mousePointer.gameObject, Vector3.zero, Quaternion.identity);
            startPointer.name = "MousePointer";
            startPointer.tag = "Pointer";
            mousePointer = startPointer;

            createOnce = false;
        }
    }

    private void Update()
    {
        if (canPlace)
        {
            PlacePrefab();
        }     
        reRayCast();
    }

    void reRayCast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject terrianobj = GameObject.FindGameObjectWithTag("Terrian");
        Terrain terrian = terrianobj.GetComponent<Terrain>();

        if (mousePointer != null)
        {
            if (terrian.GetComponent<Collider>().Raycast(ray, out hit, 1000))
            {
                mousePointer.transform.position = hit.point;
            }

            if (Input.GetMouseButtonDown(1)) // Rotate Object
            {
                mousePointer.transform.Rotate(mousePointer.transform.localRotation.x, mousePointer.transform.localRotation.y + 45f, mousePointer.transform.localRotation.z);
            }

            //Mouse Position Higten 
           // mousePointer.transform.position = new Vector3(mousePointer.transform.position.x, mousePointer.transform.position.y + 1f, mousePointer.transform.position.z);
        }

    }

    public void PlacePrefab() //Place Object On World 
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddPoints();
            //Check Pointer 
            if (mousePointer != null)
            {

                MouseLocation = mousePointer.transform.position;

                foreach (GameObject Objects in OriginalObject)
                {
                    if (manager.GlobalName == Objects.name && manager.GlobalName != "MousePointer")
                    {
                        GameObject Prefab = GameObject.Find("Prefabs"); 
                        GameObject newObject = (GameObject)Instantiate(Objects.gameObject, MouseLocation, mousePointer.transform.localRotation);
                        newObject.transform.parent = Prefab.transform;
                    }
                }
            }
        }
    }


    void AddPoints()
    {
        if (manager.GlobalName == "06_Well")
        {
            manager.Water = 0.1f + manager.Water; 
        }

        if (manager.GlobalName == "10_Windmill")
        {
            manager.Power = 0.1f + manager.Power;
        }
    }


    public void OtherSelected() // Change Mouse Pointer 
    {
        foreach (GameObject newObject in OriginalObject)
        {

            if (manager.GlobalName == newObject.name)
            {
                GameObject newMousePointer = (GameObject)Instantiate(newObject.gameObject, Vector3.zero, Quaternion.identity);
                newMousePointer.name = "MousePointer";
                newMousePointer.tag = "Pointer";
                mousePointer = newMousePointer.gameObject;
            }
        }
    }
}
