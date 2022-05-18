using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE_Manager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject qte_Smash;
    public GameObject qte_Simple;
    GameObject current_qte;

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

    public void Sucess()
    {
        Debug.Log("SUCESS");
    }

    public void Fail()
    {
        Debug.Log("FAILED");
    }
}
