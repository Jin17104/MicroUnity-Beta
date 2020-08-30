using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[DisallowMultipleComponent]
public class Hammer : MonoBehaviour {

    public GameObject empty;

    //Change Color Right Click 
    Renderer rend;
    public Color[] colors;

    public bool canDestroy = false; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.gameObject.tag == "Pointer")
        {
            if (empty != null)
            {
                Destroy(empty.gameObject);
            }  
        }

        if (Input.GetMouseButtonDown(1) && this.gameObject.tag == "Pointer")
        {
            if (empty != null)
            {
                rend = empty.GetComponent<Renderer>();
                rend.material.color = colors[Random.Range(0, colors.Length)];
            }
        }

        GameObject[] others = GameObject.FindGameObjectsWithTag("Pointer");
        foreach (GameObject myPointers in others)
        {
            if (myPointers != gameObject)
            {
                Destroy(myPointers); 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Object")
        {
            empty = other.gameObject; 
        }

    }
}
