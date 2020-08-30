using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assests : MonoBehaviour {

    public GameObject[] Prefabs;  

    public GameObject GridObj, DesignObj; 
    Design design;
    Grid grid;

    //pointer change
    bool createOnce = true;

    //Placed Obj
    Vector3 MouseLocation;
    Vector3 MouseRotation; 


    private void Start()
    {
        design = DesignObj.GetComponent<Design>();
        grid = GridObj.GetComponent<Grid>();
    }

    private void Update()
    {
        PlacePrefab();
    }
    

    void PlacePrefab() // Add Object to World 
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Check for pointer 
            if (grid.mousePointer != null)
            {
                MouseLocation = grid.mousePointer.transform.position;

                foreach (GameObject Objects in Prefabs)
                {

                    if (design.GlobelName == Objects.name && design.GlobelName != "MousePointer")
                    {
                        GameObject newObject = (GameObject)Instantiate(Objects.gameObject, MouseLocation, grid.mousePointer.transform.localRotation);
                    }
                }

            }
        }
    }

    public void OtherSelected() // Mouse Pointer 
    {

        foreach (GameObject newObject in Prefabs)
        {

            if (design.GlobelName == newObject.name)
            {
                GameObject newMousePointer = (GameObject)Instantiate(newObject.gameObject, Vector3.zero, Quaternion.identity);
                newMousePointer.name = "MousePointer";
                grid.mousePointer = newMousePointer.gameObject;
            }
        }
    }


}
