using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    GameObject ManagerObj;
    _GameManager manager;
    bool movePlayer = true; 

    private void Start()
    {

        ManagerObj = GameObject.Find("Manager");
        manager = ManagerObj.GetComponent<_GameManager>(); 

 
    }

    private void Update()
    {
        if (ManagerObj != null)
        {
            if (manager.gloabalNumber == 1 || movePlayer == true)
            {
                this.GetComponent<MeshRenderer>().enabled = false;

                GameObject Player = GameObject.FindGameObjectWithTag("PlayerOb");
                Debug.Log(Player);
                Player.gameObject.transform.position = this.transform.position;
                movePlayer = false;

                Debug.Log("Player Moved"); 
            }
            
            if(manager.gloabalNumber == 0)
            {
                Debug.Log("Not Moving"); 
                movePlayer = true; 
            }
        }
    }
}
