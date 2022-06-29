using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonRight : MonoBehaviour
{
    float ZRotation = 0;
    bool moveright = false;

    // Update is called once per frame
    void Update()
    {
        if (ZRotation >= 0)
        {
            moveright = true;
        }
        else if (ZRotation <= -50)
        {
            moveright = false;
        }

        if (moveright)
        {
            ZRotation -= 130f * Time.deltaTime;
        }
        else
        {
            ZRotation += 130f * Time.deltaTime;
        }

        Debug.Log(ZRotation);

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, ZRotation);
    }
}
