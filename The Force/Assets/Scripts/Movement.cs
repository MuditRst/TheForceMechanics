using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController con;

    public float speed = 5f;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDist = 0.4f;

    public LayerMask ground;
    bool isgrounded;
    Vector3 vel;

    public float jump = 3f;
    public GameObject target;

    public Camera cam;



    void Start(){

    }


    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position,groundDist,ground);

        if(isgrounded && vel.y < 0){
            vel.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;

        con.Move(movement * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isgrounded){
            vel.y = Mathf.Sqrt(jump * -2f * gravity);
        }

        vel.y += gravity * Time.deltaTime;

        con.Move(vel * Time.deltaTime);
    }

}
