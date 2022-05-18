using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_Manager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject qte_Smash;
    public GameObject qte_Simple;
    GameObject current_qte;
    int qte_number = 0;

    public void CreateSmashQTE()
    {
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

    public void Sucess()
    {
        switch (qte_number)
        {
            case 1:
                Debug.Log("1 Sucess animation playing");
                break;
            case 2:
                Debug.Log("2 Sucess animation playing");
                break;
            case 3:
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
