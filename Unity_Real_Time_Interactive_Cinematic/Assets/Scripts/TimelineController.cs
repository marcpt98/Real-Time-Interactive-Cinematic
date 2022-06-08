using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public GameObject gameplay;
    public GameObject SniperModel;
    public GameObject Bullet;
    public PlayableDirector parkourTimeline;
    public PlayableDirector sniperwaitTimeline;

    // From Intro to Sniper
    public void GameplayTransition()
    {
        gameplay.SetActive(true);
        SniperModel.SetActive(false);
        Bullet.SetActive(false);
        sniperwaitTimeline.Play();
    }

    // From Sniper to Parkour
    public void ParkourTransition()
    {
        parkourTimeline.Play();
    }
}
