using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineQTE : MonoBehaviour
{
    public PlayableDirector playableDirector;
    
    public void Play()
    {
        playableDirector.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Play();
        }
    }
}
