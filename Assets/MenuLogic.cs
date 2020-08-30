using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuLogic : MonoBehaviour {

    GameObject ManagerObj;
    _GameManager manager;

    public GameObject TerrianObj;
    Text TText;
    int index, changeIndex  = 0;

    //Player 
    public GameObject[] FakePlayers; 
    GameObject Label;
    Text PText;
    int playerIndex = 0; 

    private void Start()
    {
        ManagerObj = GameObject.Find("Manager");
        manager = ManagerObj.GetComponent<_GameManager>();

        TText = TerrianObj.GetComponent<Text>();
        TerrianMenu();
    }

    private void Update()
    {
        PlayerMenu();
    }

    public void Navigate(int RL) //Menu Selected 
    {
        TerrianMenu();

        switch (RL)
        {
            case 0: //TLeft
                if (changeIndex > 0) { changeIndex--; }
                break;
            case 1: //TRight
                if (changeIndex < manager.Terrians.Length - 1) { changeIndex++; }
                break;
            case 2:        
                break;
            case 3:
                break;
            case 4:
                Application.LoadLevel(1); // Load Level 
                break;
        }
    }

    public void TerrianMenu()
    {
        switch (changeIndex)
        {
            case 0:
                manager.TerrianName = "GreenLand";
                TText.text = manager.TerrianName;
                TText.color = Color.green;
                break;

            case 1:
                manager.TerrianName = "Wastland";
                TText.text = manager.TerrianName;
                TText.color = Color.yellow;
                break;

            case 2:
                manager.TerrianName = "SnowLand";
                TText.text = manager.TerrianName;
                TText.color = Color.white;
                break;
        }
    }

    public void PlayerMenu()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
           
            Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
        }

        Debug.Log   ("Call this Function"); 

        switch (playerIndex)
        {
            case 0:
                break; 
        }
    }
}
