using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    public GameObject gameplay;
    public GameObject SniperModel;
    
    // Start is called before the first frame update
    public void GameplayTransition()
    {
        gameplay.SetActive(true);
        SniperModel.SetActive(false);
    }
}
