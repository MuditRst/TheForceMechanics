using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheForce : MonoBehaviour
{

    private GameObject target;
    private Vector3 TargetPos;

    private float distance;
    public Camera cam;

    Vector3 des;

    float thrust = 10f;

    Vector3 distAdd = new Vector3(1f,-0.5f,0);
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Pullable");
    }

    // Update is called once per frame

    void FixedUpdate(){
        if(Input.GetButton("Fire2") && target.tag == "PullObject"){
            Ray r = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(r,out hit)){
                des= hit.point;
            }
        TargetPos = target.transform.position;
        distance = Vector3.Distance(TargetPos,des);
        if(target.tag == "PullObject" && distance > 1.5f){

            target.transform.LookAt(des);
            target.transform.position = Vector3.MoveTowards(target.transform.position,des,1f);

            target.GetComponent<Rigidbody>().freezeRotation = true;
            target.GetComponent<Rigidbody>().isKinematic = true;
        }
        }

        if(Input.GetButtonDown("Fire1")){
            target.GetComponent<Rigidbody>().isKinematic = false;

            target.GetComponent<Rigidbody>().velocity = transform.forward * thrust;
            print("Pushing");
        }
    }

}
