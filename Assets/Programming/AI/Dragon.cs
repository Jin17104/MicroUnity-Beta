using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {

    public GameObject[] points;
    int destPoint;
    float allowence = 1;
    public float speed = .5f;
    int count;

    bool runOnce = true;
    bool beginRotate = false; 
    Vector3 relativePos;

    //Test 
    public Transform target; 


    //Child 
    GameObject inChild;

    private void Start()
    {
        UpdateTarget();
        inChild = GameObject.Find("Path_Dragon");
        Debug.Log(inChild.name + " has " + inChild.transform.childCount + " children ");

        points = new GameObject[inChild.transform.childCount];

        for (int i = 0; i < inChild.transform.childCount; i++)
        {
            points[i] = inChild.transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        LookAt(); 
    }

    void LookAt()
    {
      
        Vector3 thisPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (runOnce)
        {
            transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, speed * Time.deltaTime);

            relativePos = points[destPoint].transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.localRotation = rotation;
        }

        if (Vector3.Distance(thisPos, points[destPoint].transform.position) < allowence)
        {
           // runOnce = false; // Lock when hits target 
            transform.localRotation = points[destPoint].transform.localRotation; 
            UpdateTarget();     
        }

    }

    void UpdateTarget()
    {

        if (points.Length == 0)
        {
            return;
        }

        transform.position = points[destPoint].transform.position;

        destPoint = (destPoint + 1) % points.Length;

    }


    void OldScript()
    {
        Vector3 thisPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Vector3.Distance(thisPos, points[destPoint].transform.position) < allowence)
        {
            UpdateTarget();
        }

        if (destPoint + 1 == inChild.transform.childCount) //add one and add two on the door  
        {
            Destroy(this.gameObject);
            Debug.Log("Last Hit");
        }

        transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, speed * Time.deltaTime);
    }
}
