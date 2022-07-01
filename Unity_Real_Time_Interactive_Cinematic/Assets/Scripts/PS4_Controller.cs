using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PS4_Controller : MonoBehaviour
{
    public bool controller = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ControllerCheck());

        for (int i = 0; i < Gamepad.all.Count; i++) 
        {
            Debug.Log(Gamepad.all[i].name);
        }
    }

    /*IEnumerator ControllerCheck()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(2f);
            for (int i = 0; i < Input.GetJoystickNames().Length; i++)
            {
                if (!string.IsNullOrEmpty(Input.GetJoystickNames()[i]))
                {
                    Debug.Log("Joystick Connected");
                    i = Input.GetJoystickNames().Length;
                    controller = true;
                }
                else
                {
                    Debug.Log("Joystick Disconnected");
                    i = Input.GetJoystickNames().Length;
                    controller = false;
                }
            }
        }
    }*/
}
