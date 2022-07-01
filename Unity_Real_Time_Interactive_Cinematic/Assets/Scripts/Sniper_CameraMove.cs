using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sniper_CameraMove : MonoBehaviour
{
    float speedH = 0.7f;
    float speedV = 0.7f;
    float speedHScope = 0.1f;
    float speedVScope = 0.1f;
    float speedHCont = 1.2f;
    float speedVCont = 1.2f;
    float speedHContScope = 0.1f;
    float speedVContScope = 0.1f;

    float yaw = 0f;
    float pitch = 0f;

    public Sniper_Scope scope;

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null) 
        {
            if (!scope.isScoped)
            {
                yaw += speedHCont * Input.GetAxis("Horizontal");
                pitch -= speedVCont * Input.GetAxis("Vertical");
            }
            else
            {
                yaw += speedHContScope * Input.GetAxis("Horizontal");
                pitch -= speedVContScope * Input.GetAxis("Vertical");
            }
        }
        else
        {
            if (!scope.isScoped)
            {
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");
            }
            else
            {
                yaw += speedHScope * Input.GetAxis("Mouse X");
                pitch -= speedVScope * Input.GetAxis("Mouse Y");
            }
        }
        
        yaw = Mathf.Clamp(yaw, -120f, -40f);
        pitch = Mathf.Clamp(pitch, -30f, 30f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
