using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform player;

    float xrot = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;    

        xrot -= mouseY;
        xrot = Mathf.Clamp(xrot , -80f,80f);


        transform.localRotation = Quaternion.Euler(xrot,0,0);
        player.Rotate(Vector3.up * mouseX);
        
    }
}
