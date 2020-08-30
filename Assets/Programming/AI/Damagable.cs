using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour {

    public float Health;
    public float speed = 10f;
    public float smoothTime = 10.0f;
    private Vector3 smoothVelocity = Vector3.zero;


    public GameObject PrefabExplode;
    public GameObject foodDrop; 

    public GameObject target; 
    bool canCreate = false;

    Animation anim;
    public AnimationClip[] clip; 

    bool animate = false;

    private void Start()
    {
    
        anim = GetComponent<Animation>();
        if (anim != null)
        {
            anim.Play("idle");
        }
      
    }

    private void Update()
    {
        LookAt();
        isDestroyed();
    }

    void LookAt()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance < speed)
            {
                //Move the enemy towards the player with smoothdamp
                transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref smoothVelocity, smoothTime);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject;
            animate = true;

            if (anim != null)
            {
                anim.clip = clip[0];
                anim.Play();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        target = null;
        animate = false;

        if (anim != null)
        {
            anim.clip = clip[1];
            anim.Play();
        }

    }

    void isDestroyed()
    {
        if (Health <= 0)
        {
            canCreate = true;
        }

        if (canCreate)
        {
            GameObject newExplode = (GameObject)Instantiate(PrefabExplode.gameObject, this.transform.gameObject.transform.position, Quaternion.identity);
            newExplode.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
            newExplode.gameObject.name = "Boom";

            GameObject newFood = (GameObject)Instantiate(foodDrop.gameObject, this.transform.gameObject.transform.position, Quaternion.identity);
            newFood.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .5f, this.transform.position.z);
            newFood.gameObject.name = this.gameObject.name;


            canCreate = false;

            Destroy(this.gameObject);
        }
    }
}
