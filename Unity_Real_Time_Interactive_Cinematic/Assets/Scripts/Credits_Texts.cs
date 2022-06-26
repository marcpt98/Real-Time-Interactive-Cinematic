using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Texts : MonoBehaviour
{
    public GameObject ToBeCon_Text;
    public GameObject ThxWatch_Text;
    public GameObject MadeBy_Text;

    // Start is called before the first frame update
    void Start()
    {
        ToBeCon_Text.SetActive(true);
        ThxWatch_Text.SetActive(false);
        MadeBy_Text.SetActive(false);
    }

    public void MadeBy()
    {
        ToBeCon_Text.SetActive(false);
        MadeBy_Text.SetActive(true);
    }

    public void ThanksForWatching()
    {
        MadeBy_Text.SetActive(false);
        ThxWatch_Text.SetActive(true);
    }
}
