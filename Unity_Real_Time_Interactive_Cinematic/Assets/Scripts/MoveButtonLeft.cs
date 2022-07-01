using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonLeft : MonoBehaviour
{
    float ZRotation = 0;
    bool moveleft = false;

    // Update is called once per frame
    void Update()
    {
        if (ZRotation <= 0)
        {
            moveleft = true;
        }
        else if (ZRotation >= 50) 
        {
            moveleft = false;
        }

        if (moveleft)
        {
            ZRotation += 130f * Time.deltaTime;
        }
        else
        {
            ZRotation -= 130f * Time.deltaTime;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, ZRotation);
    }
}
