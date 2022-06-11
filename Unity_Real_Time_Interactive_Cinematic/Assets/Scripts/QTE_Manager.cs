using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class QTE_Manager : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject canvas;
    public GameObject qte_Smash;
    public GameObject qte_Simple;
    GameObject current_qte;
    int qte_number = 0;
    bool qte_1 = false;

    public void CreateSmashQTE()
    {
        if(!qte_1)
        CreateQTE(qte_Smash);
    }

    public void CreateSimpleQTE()
    {
        CreateQTE(qte_Simple);
    }

    void CreateQTE(GameObject qte)
    {
        GameObject newCanvas = Instantiate(canvas);
        current_qte = Instantiate(qte, new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), 0), Quaternion.identity);
        current_qte.transform.SetParent(newCanvas.transform, false);
    }

    public void GetNumberQTE(int number)
    {
        qte_number = number;
        Debug.Log(number);
    }

    public void JumpTo(float seconds)
    {
        director.time = seconds;
        Debug.Log("jumped to " + seconds);
    }
    public void JumpFromFailToMain()
    {
        switch (qte_number)
        {
            case 1:
                //director.time = 11.28f;
                Debug.Log("1 From Fail to Main Timeline");
                break;
            case 2:
                if (!qte_1)
                {
                    director.time = 11.683f;
                    Debug.Log("2 From Fail to Main Timeline");
                }
                break;
            case 3:
                Debug.Log("3 From Fail to Main Timeline");
                break;
            case 4:
                Debug.Log("4 From Fail to Main Timeline");
                break;
            case 5:
                Debug.Log("5 From Fail to Main Timeline");
                break;
            default:
                Debug.LogError("WRONG NUMBER");
                break;
        }

        Debug.Log("jumped to " + director.time);
    }

    public void Sucess()
    {
        switch (qte_number)
        {
            case 1:
                qte_1 = true;
                JumpTo(10.75f);
                Debug.Log("1 Sucess animation playing");
                break;
            case 2:
                JumpTo(9.6f);
                Debug.Log("2 Sucess animation playing");
                break;
            case 3:
                JumpTo(17.45f);
                Debug.Log("3 Sucess animation playing");
                break;
            case 4:
                Debug.Log("4 Sucess animation playing");
                break;
            case 5:
                Debug.Log("5 Sucess animation playing");
                break;
            default:
                Debug.LogError("WRONG NUMBER");
                break;
        }
    }

    public void Fail()
    {
        switch (qte_number)
        {
            case 1:
                Debug.Log("1 Fail animation playing");
                break;
            case 2:
                Debug.Log("2 Fail animation playing");
                break;
            case 3:
                Debug.Log("3 Fail animation playing");
                break;
            case 4:
                Debug.Log("4 Fail animation playing");
                break;
            case 5:
                Debug.Log("5 Fail animation playing");
                break;
            default:
                Debug.LogError("WRONG NUMBER");
                break;
        }
    }
}
