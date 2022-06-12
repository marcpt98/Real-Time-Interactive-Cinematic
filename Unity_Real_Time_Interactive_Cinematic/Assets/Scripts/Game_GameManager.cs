using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Game_GameManager : MonoBehaviour
{
    bool visible = false;
    public PlayableDirector parkourTimeline;
    public PlayableDirector introTimeline;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = visible;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            introTimeline.Stop();
            parkourTimeline.Play();
        }
    }
}
