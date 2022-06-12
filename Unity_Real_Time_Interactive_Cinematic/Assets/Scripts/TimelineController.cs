using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector introTimeline;
    public PlayableDirector parkourTimeline;
    public PlayableDirector sniperwaitTimeline;
    public PlayableDirector prefightTimeline;
    public PlayableDirector fightTimeline;

    // From Intro to Sniper
    public void GameplayTransition()
    {
        introTimeline.Stop();
        sniperwaitTimeline.Play();
    }

    // From Sniper to Parkour
    public void ParkourTransition()
    {
        sniperwaitTimeline.Stop();
        parkourTimeline.Play();
    }

    // From Parkour to prefight
    public void PrefightTransition()
    {
        parkourTimeline.Stop();
        prefightTimeline.Play();
    }

    // From Prefight to Fight
    public void FightTransition()
    {
        prefightTimeline.Stop();
        fightTimeline.Play();
    }
}
