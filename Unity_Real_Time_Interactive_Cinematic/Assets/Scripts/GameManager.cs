using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timePassed = 0;
    public GameObject qte_Smash;
    public GameObject canvas;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > 2)
        {
            GameObject newCanvas = Instantiate(canvas);
            GameObject button = Instantiate(qte_Smash, new Vector3(Random.Range(-100f,100f), Random.Range(-100f, 100f), 0), Quaternion.identity);
            button.transform.SetParent(newCanvas.transform, false);
            timePassed = 0;
        }
    }
}
