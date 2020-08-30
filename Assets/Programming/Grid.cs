using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public GameObject mousePointer;
    bool createOnce = true; 

    public float size = 4f;

    private void Start()
    {
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
        if (mousePointer != null)
        {
            mousePointer.transform.position = GetNearestPointOnGrid(getWorldPoint());

            //Rotate Object on MousePointer 
            if (Input.GetMouseButtonDown(1))
            {
                mousePointer.transform.Rotate(mousePointer.transform.localRotation.x, mousePointer.transform.localRotation.y + 45f, mousePointer.transform.localRotation.z);
            }

            //Mouse Position Higten 
           // mousePointer.transform.position = new Vector3(mousePointer.transform.position.x, mousePointer.transform.position.y + 1f, mousePointer.transform.position.z);
        }
    }

    public Vector3 getWorldPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit; 

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);

        result += transform.position;

        return result;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 40; x += size)
        {
            for (float z = 0; z < 40; z += size)
            {
                Vector3 point = GetNearestPointOnGrid(new Vector3(x, 0f, z));
                Gizmos.DrawSphere(point, 0.1f);
            }

        }
    }
}
