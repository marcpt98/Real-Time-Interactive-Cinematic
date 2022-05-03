using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_GameManager : MonoBehaviour
{
    bool visible = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = visible;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/
}
