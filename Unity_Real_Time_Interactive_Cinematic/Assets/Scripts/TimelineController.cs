using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector introTimeline;
    public PlayableDirector parkourTimeline;
    public PlayableDirector sniperwaitTimeline;
    public PlayableDirector prefightTimeline;
    public PlayableDirector fightTimeline;
    public PlayableDirector deadParkourTimeline;
    public PlayableDirector deadFightTimeline;
    public PlayableDirector musicTimeline;
    public PlayableDirector creditsTimeline;
    public GameObject deadMenuParkour;
    public GameObject deadMenuFight;
    QTE_Manager Timeline;

    float power, time = 0;

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

    // From Fight to Credits
    public void CreditsTransition()
    {
        fightTimeline.Stop();
        creditsTimeline.Play();
    }

    // From game to Dead screen
    public void DeadParkourMenuTransition()
    {
        if (!GameObject.Find("Parkour_TimelineManager").GetComponent<QTE_Manager>().qte_1)
        {
            parkourTimeline.Stop();
            deadParkourTimeline.Play();
        }
    }

    // From game to Dead screen
    public void DeadFightMenuTransition()
    {
        if (!GameObject.Find("Fight_TimelineManager").GetComponent<QTE_Manager>().qte_3)
        {
            fightTimeline.Stop();
            deadFightTimeline.Play();
        }
        GameObject.Find("Fight_TimelineManager").GetComponent<QTE_Manager>().qte_3 = false;
    }

    public void SetActiveMenuDead(int timelinenum)
    {
        switch (timelinenum)
        {
            case 1:
                deadMenuParkour.SetActive(true);
                break;
            case 2:
                deadMenuFight.SetActive(true);
                break;
            default:
                Debug.LogError("WRONG NUMBER");
                break;
        }
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void TryAgainParkour()
    {
        deadParkourTimeline.Stop();
        deadMenuParkour.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        parkourTimeline.Play();
    }

    public void TryAgainFight()
    {
        deadFightTimeline.Stop();
        deadMenuFight.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fightTimeline.Play(); 
    }

    public void ControllerVibrateTime(float timevalue)
    {
        time = timevalue;
        StartCoroutine(Vibrate());
    }

    public void ControllerVibratePower(float powervalue)
    {
        power = powervalue;
    }

    IEnumerator Vibrate()
    {
        Gamepad.all[0].SetMotorSpeeds(power, power);
       
        yield return new WaitForSeconds(time);
        
        Gamepad.all[0].SetMotorSpeeds(0, 0);
    }
}
