using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_PressButton : MonoBehaviour
{
    public float fillAmount = 0;
    float currentTime = 2f;
    float maxTime = 2f;
    bool fail = false;
    Color sucessColor = new Color32(102, 255, 102, 255);
    Color failColor = new Color32(255, 102, 102, 255);
    GameObject gparent;
    bool callfade = false;

    // Start is called before the first frame update
    void Start()
    {
        gparent = transform.parent.gameObject;
        StartCoroutine(time());
        StartCoroutine(FillBar());
    }

    // Update is called once per frame
    void Update()
    {
        if (!fail)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                GetComponent<Image>().color = sucessColor;
                fillAmount = 1;
                StartCoroutine(FadeOut());
            }
        }
        else
        {
            if (!callfade)
            {
                StartCoroutine(FadeOut());
                callfade = true;
            }
        }

        GetComponent<Image>().fillAmount = fillAmount;
    }

    IEnumerator FillBar()
    {
        while (fillAmount != 1)
        {
            currentTime -= Time.deltaTime;
            fillAmount = currentTime / maxTime;
            yield return null;
        }
        yield return null;
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(maxTime);
        
        if (fillAmount != 1) 
        {
            fail = true;
            GetComponent<Image>().color = failColor;
            fillAmount = 1;
        }
    }

    IEnumerator FadeOut()
    {
        CanvasGroup canvas = gameObject.GetComponentInParent<CanvasGroup>();
        while (canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime * 1.5f;
            yield return null;
        }

        gparent = transform.parent.gameObject;
        Destroy(gparent.transform.parent.gameObject);
    }
}
