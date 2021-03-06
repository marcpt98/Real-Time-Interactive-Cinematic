using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class QTE_Manager : MonoBehaviour
{
    public PlayableDirector director;
    public GameObject canvas;
    public GameObject qte_Smash;
    public GameObject qte_Simple_Grab;
    public GameObject qte_Simple_L_Hit;
    public GameObject qte_Simple_R_Hit;
    public GameObject qte_Simple_Left;
    public GameObject qte_Simple_Right;
    GameObject current_qte;
    public int qte_number = 0;
    public bool qte_1 = false;
    bool qte_2 = false;
    public bool qte_3 = false;
    /*bool qte_4 = false;*/

    public void CreateSmashQTE()
    {
        if(!qte_1)
        CreateQTE(qte_Smash);
    }

    public void CreateSimpleQTE()
    {
        switch (qte_number)
        {
            case 1:
                CreateQTE(qte_Simple_Grab);
                break;
            case 4:
                CreateQTE(qte_Simple_Grab);
                break;
            case 5:
                CreateQTE(qte_Simple_Left);
                break;
            case 6:
                CreateQTE(qte_Simple_R_Hit);
                break;
            case 7:
                CreateQTE(qte_Simple_Right);
                break;
            case 8:
                CreateQTE(qte_Simple_R_Hit);
                break;
            case 9:
                CreateQTE(qte_Simple_L_Hit);
                break;
            default:
                CreateQTE(qte_Simple_Grab);
                Debug.LogError("WRONG NUMBER");
                break;
        }
    }

    void CreateQTE(GameObject qte)
    {
        GameObject newCanvas = Instantiate(canvas);

        switch (qte_number)
        {
            case 1:
                current_qte = Instantiate(qte, new Vector3(-39, -181, 0), Quaternion.identity);
                break;
            case 2:
                current_qte = Instantiate(qte, new Vector3(-212, 132, 0), Quaternion.identity);
                break;
            case 3:
                current_qte = Instantiate(qte, new Vector3(-106, 135, 0), Quaternion.identity);
                break;
            case 4:
                current_qte = Instantiate(qte, new Vector3(-1, -206, 0), Quaternion.identity);
                break;
            case 5:
                current_qte = Instantiate(qte, new Vector3(106, 43, 0), Quaternion.identity);
                break;
            case 6:
                current_qte = Instantiate(qte, new Vector3(153, -161, 0), Quaternion.identity);
                break;
            case 7:
                current_qte = Instantiate(qte, new Vector3(368, -100, 0), Quaternion.identity);
                break;
            case 8:
                current_qte = Instantiate(qte, new Vector3(-376, 24, 0), Quaternion.identity);
                break;
            case 9:
                current_qte = Instantiate(qte, new Vector3(-221, -9, 0), Quaternion.identity);
                break;
            default:
                current_qte = Instantiate(qte, new Vector3(-35, -180, 0), Quaternion.identity);
                Debug.LogError("WRONG NUMBER");
                break;
        }
        
        current_qte.transform.SetParent(newCanvas.transform, false);
    }

    public void GetNumberQTE(int number)
    {
        qte_number = number;
        Debug.Log(qte_number);
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
                if (!qte_1 || qte_2)
                {
                    director.time = 11.70f;
                    Debug.Log("2 From Fail to Main Timeline");
                    qte_2 = false;
                }
                qte_1 = false;
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
        Debug.Log(qte_number);
        switch (qte_number)
        {
            case 1:
                qte_1 = true;
                JumpTo(10.75f);
                Debug.Log("1 Sucess animation playing");
                break;
            case 2:
                qte_1 = true;
                qte_2 = true;
                JumpTo(9.6f);
                Debug.Log("2 Sucess animation playing");
                break;
            case 3:
                qte_1 = true;
                JumpTo(17.45f);
                Debug.Log("3 Sucess animation playing");
                break;
            case 4:
                qte_1 = true;
                JumpTo(23.25f);
                Debug.Log("4 Sucess animation playing");
                break;
            case 5:
                qte_3 = true;
                JumpTo(11.45f);
                Debug.Log("5 Sucess animation playing");
                break;
            case 6:
                qte_3 = true;
                JumpTo(16.75f);
                Debug.Log("6 Sucess animation playing");
                break;
            case 7:
                qte_3 = true;
                JumpTo(21.70f);
                Debug.Log("7 Sucess animation playing");
                break;
            case 8:
                qte_3 = true;
                JumpTo(25.45f);
                Debug.Log("8 Sucess animation playing");
                break;
            case 9:
                qte_3 = true;
                JumpTo(29.75f);
                Debug.Log("9 Sucess animation playing");
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
                JumpTo(5.25f);
                Debug.Log("1 Fail animation playing");
                break;
            case 2:
                JumpTo(8.9f);
                Debug.Log("2 Fail animation playing");
                break;
            case 3:
                JumpTo(16.75f);
                Debug.Log("3 Fail animation playing");
                break;
            case 4:
                qte_1 = false;
                JumpTo(22.0833f);
                Debug.Log("4 Fail animation playing");
                break;
            case 5:
                JumpTo(10.1333f);
                Debug.Log("5 Fail animation playing");
                break;
            case 6:
                JumpTo(14.2167f);
                Debug.Log("6 Fail animation playing");
                break;
            case 7:
                JumpTo(20.3833f);
                Debug.Log("7 Fail animation playing");
                break;
            case 8:
                JumpTo(24.3833f);
                Debug.Log("8 Fail animation playing");
                break;
            case 9:
                JumpTo(28.4f);
                Debug.Log("9 Fail animation playing");
                break;
            default:
                Debug.LogError("WRONG NUMBER");
                break;
        }
    }

    /*public void ResetParkour()
    {
        if (!qte_1 && !qte_2 && !qte_3 && !qte_4)
        {
            director.Stop();
            director.time = 0;
            director.Evaluate();
            director.Play();
            qte_1 = false;
            qte_2 = false;
            qte_3 = false;
            qte_4 = false;
            Debug.Log("Reset Parkour");
        }
        qte_2 = false;
        qte_3 = false;
        qte_4 = false;
    }*/
}
