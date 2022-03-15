using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_PressButtonSimple : MonoBehaviour
{
    public float fillAmount = 0;
    bool fail = false;
    Color sucessColor = new Color32(102, 255, 102, 255);
    GameObject gparent;
    bool callfade = false;

    // Start is called before the first frame update
    void Start()
    {
        gparent = transform.parent.gameObject;
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
