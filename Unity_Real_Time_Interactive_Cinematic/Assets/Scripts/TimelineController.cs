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
    public PlayableDirector deadTimeline;
    public GameObject deadMenu;
    QTE_Manager Timeline;

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

    // From game to Dead screen
    public void DeadParkourMenuTransition()
    {
        if (!GameObject.Find("Parkour_TimelineManager").GetComponent<QTE_Manager>().qte_1)
        {
            parkourTimeline.Stop();
            deadTimeline.Play();
        }
    }

    public void SetActiveMenuDead()
    {
        deadMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void TryAgain(int checkpoint)
    {
        if (checkpoint == 1)
        {
            deadTimeline.Stop();
            deadMenu.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            parkourTimeline.Play();
        }
        else if (checkpoint == 2)
        {

        }
        else
        {
            Debug.LogError("Try again wrong number");
        }
    }
}
