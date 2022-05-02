using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_CameraMove : MonoBehaviour
{
    float speedH = 2f;
    float speedV = 2f;

    float yaw = 0f;
    float pitch = 0f;

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, -120f, -40f);
        pitch = Mathf.Clamp(pitch, -30f, 30f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
