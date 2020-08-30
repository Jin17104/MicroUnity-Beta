using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;


public class _GameManager : MonoBehaviour

{
    public string GlobalName; //Item Placed Name 
    public float Food, Water, Power;
    GameObject FoodObj, WaterObj, PowerObj;

    public GameObject[] Scene;//Player & Edit Mode 
    public int gloabalNumber = 0;

    //Terrians 
    public GameObject[] Terrians;
    public string TerrianName;
    bool create = true;

    //Players 
    public GameObject[] Players;
    public string PlayerName; 


    private void Update()
    {
        if (Scene[0] != null)
        {
            if (gloabalNumber == 1)
            {
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    GameSwitch(0);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    GameSwitch(1);
                }
            }

            SustainableEnergy();
        }
    }

    void SustainableEnergy()
    {
        FoodObj = GameObject.Find("FSlider");
        WaterObj = GameObject.Find("WSlider");
        PowerObj = GameObject.Find("PSlider");

        if (FoodObj != null)
        {
            Slider FSlider = FoodObj.GetComponent<Slider>();
            Slider WSlider = WaterObj.GetComponent<Slider>();
            Slider PSlider = PowerObj.GetComponent<Slider>();

            PSlider.value = Power;
            WSlider.value = Water;
            FSlider.value = Food;
        }
    }

    public void GameSwitch(int number)
    {
        if (Scene[0] != null)
        {
            gloabalNumber = number;

            switch (gloabalNumber)
            {
                case 0: // Editor Mode 
                    Scene[0].GetComponent<Camera>().enabled = true;
                    Scene[1].GetComponent<Camera>().enabled = false;
                    
                    Cursor.visible = true;
                    Screen.lockCursor = false;

                    break;

                case 1: // Play Mode 

                    Scene[0].GetComponent<Camera>().enabled = false;
                    Scene[1].GetComponent<Camera>().enabled = true;

                    Cursor.visible = false;
                    Screen.lockCursor = true;

                    break;
            }
        } 
    }

    public void CreateTerrian() // Instaiate a Terrian
    {
        switch (TerrianName)
        {
            case "GreenLand":
                GameObject CloneGreenLand = (GameObject)Instantiate(Terrians[0], transform.position, Quaternion.identity);
                break;
            case "Wastland":
                GameObject CloneWastland = (GameObject)Instantiate(Terrians[1], transform.position, Quaternion.identity);
                break;
            case "SnowLand":
                GameObject CloneSnowLand = (GameObject)Instantiate(Terrians[2], transform.position, Quaternion.identity);
                break;
        }
    }

    private void OnLevelWasLoaded(int level) // Caall Terrian and Player 
    {
        if (level == 1 || create == true)
        {
            CreateTerrian();

            Scene[0] = GameObject.Find("RTS_Camera");
            Scene[1] = GameObject.FindGameObjectWithTag("PCamera");

            if (Scene[1] != null)
            {
                GameSwitch(0);
            }

            create = false;
        }
        if (level == 0)
        {
            create = true; 
        }
    }


    //Don't Destroy this Object 
    private static _GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }        
    }
    
}
