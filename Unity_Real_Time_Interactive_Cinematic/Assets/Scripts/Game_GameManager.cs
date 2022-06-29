using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Game_GameManager : MonoBehaviour
{
    public PlayableDirector parkourTimeline;
    public PlayableDirector fightTimeline;
    public PlayableDirector introTimeline;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
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
        if (Input.GetKeyDown(KeyCode.N))
        {
            introTimeline.Stop();
            fightTimeline.Play();
        }
    }
}
