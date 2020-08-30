using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")

        {
            GameObject manager = GameObject.Find("Manager");
            _GameManager scriptMa = manager.GetComponent<_GameManager>();

            switch (this.gameObject.name)
            {
                case "Sheep(Clone)":
                    scriptMa.Food = 0.01f + scriptMa.Food;
                    break;
                case "Duck(Clone)":
                    scriptMa.Food = 0.02f + scriptMa.Food;
                    break;
                case "FlowerMonster(Clone)":
                    scriptMa.Food = 0.03f + scriptMa.Food;
                    break;
                case "MoleMonster(Clone)":
                    scriptMa.Food = 0.03f + scriptMa.Food;
                    break;
                case "Penquin(Clone)":
                    scriptMa.Food = 0.01f + scriptMa.Food;
                    break;
            }


            Destroy(this.gameObject); 
        }
    }
}
