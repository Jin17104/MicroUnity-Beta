using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour {

    public float Health = 100; 
    public float Strength = 1; 
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    CharacterController controller;

    //Animation
    GameObject Player;
    Vector3 PlayerSize; 
    Animator anim;

    //Enemy
    RaycastHit hit;
    GameObject Enemy;
    Vector3 RayDirection;
    float direction;
    float maxDistance = 1.5f;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        anim = Player.GetComponent<Animator>();
    }

    void Update()
    {
        Movement(); 

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) // if standing still 
        {
            Attack();
        }

        Identity(); 
    }

    void Identity()
    {
        switch (this.gameObject.name)
        {
            case "00_Player":
                PlayerSize = controller.transform.position;
                PlayerSize.y += 1f;
                break;
            case "01_Player":
                PlayerSize = controller.transform.position;
                break;
            case "02_Player":
                PlayerSize = controller.transform.position;
                RayDirection *= 4f;
                break;
            case "03_Player":
                PlayerSize = controller.transform.position;
                PlayerSize.y =+ 1f;
               // RayDirection *= 4f;
                break;
        }
    }

    void Movement()
    {
        controller = GetComponent<CharacterController>();

        // Rotate around y - axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");

        controller.SimpleMove(forward * curSpeed);
        anim.SetFloat("Speed", curSpeed);
    }

    void Attack()
    {
        Vector3 RayDirection = transform.TransformDirection(Vector3.forward) * 2f;
        Debug.DrawRay(PlayerSize, RayDirection, Color.red);// show line 

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");

            if (Physics.Raycast(PlayerSize, RayDirection, out hit))
            {
                direction = hit.distance;
                if (direction < maxDistance)
                {
                    if (hit.collider.gameObject.tag == "enemy")
                    {
                        Enemy = hit.collider.gameObject;
                        Damagable EnemyScript = Enemy.GetComponent<Damagable>();
                        EnemyScript.Health -= Strength;
                    }
                }
            }
        }
    }
}

