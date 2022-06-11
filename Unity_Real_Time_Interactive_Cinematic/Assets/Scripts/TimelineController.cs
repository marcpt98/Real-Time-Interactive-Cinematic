using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public GameObject SniperCamera;
    public GameObject SniperModel;
    public GameObject Bullet;
    public PlayableDirector parkourTimeline;
    public PlayableDirector sniperwaitTimeline;

    // From Intro to Sniper
    public void GameplayTransition()
    {
        sniperwaitTimeline.Play();
    }

    // From Sniper to Parkour
    public void ParkourTransition()
    {
        sniperwaitTimeline.Stop();
        parkourTimeline.Play();
    }
}
