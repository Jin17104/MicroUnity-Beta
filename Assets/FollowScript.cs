using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

    public Transform Target;

	// Use this for initialization
	void Start () {

      
		
	}

    // Update is called once per frame
    void Update()
    {
        GameObject TSnow = GameObject.Find("TSnow");

        if (TSnow != null)
        {
            GameObject Player = GameObject.Find("Player");
            if (Target == null)
            {
                this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 27f, Player.transform.position.z);
            }

            this.transform.position = new Vector3(Target.position.x, Target.position.y + 27f, Target.position.z);
        }
    }
}
