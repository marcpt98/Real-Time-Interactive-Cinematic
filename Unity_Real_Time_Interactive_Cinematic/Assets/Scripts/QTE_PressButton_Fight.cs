using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class QTE_PressButton_Fight : MonoBehaviour
{
    public float fillAmount = 0;
    float currentTime = 1.76f;
    float maxTime = 1.76f;
    bool fail = false;
    Color sucessColor = new Color32(102, 255, 102, 255);
    Color failColor = new Color32(255, 102, 102, 255);
    GameObject gparent;
    bool callfade = false;
    QTE_Manager Timeline;
    int qteNumber;
    bool success = false;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = GameObject.Find("Fight_TimelineManager").GetComponent<QTE_Manager>();
        gparent = transform.parent.gameObject;
        StartCoroutine(time());
        StartCoroutine(FillBar());
    }

    // Update is called once per frame
    void Update()
    {
        if (!fail)
        {
            if(!success)
            {
                if (Input.anyKeyDown || Gamepad.current != null && Gamepad.all[0].IsPressed(1) 
                    || Gamepad.current != null && Input.GetAxis("Horizontal") != 0)
                {
                    qteNumber = Timeline.qte_number;

                    if (qteNumber == 5 || qteNumber == 7)
                    {
                        if (qteNumber == 5 && Input.GetKeyDown(KeyCode.A) || qteNumber == 7 && Input.GetKeyDown(KeyCode.D) ||
                            Gamepad.current != null && qteNumber == 5 && Gamepad.all[0].leftStick.left.isPressed ||
                            Gamepad.current != null && qteNumber == 7 && Gamepad.all[0].leftStick.right.isPressed)
                        {
                            GetComponent<Image>().color = sucessColor;
                            fillAmount = 1;
                            StartCoroutine(FadeOut());
                            Timeline.Sucess();
                            success = true;
                        }
                        else if(qteNumber == 5 && Input.GetKeyDown(KeyCode.D) || qteNumber == 7 && Input.GetKeyDown(KeyCode.A) ||
                            Gamepad.current != null && qteNumber == 5 && Gamepad.all[0].leftStick.right.isPressed ||
                            Gamepad.current != null && qteNumber == 7 && Gamepad.all[0].leftStick.left.isPressed)
                        {
                            StopAllCoroutines();
                            fail = true;
                            GetComponent<Image>().color = failColor;
                            fillAmount = 1;
                            Timeline.Fail();
                        }
                    }
                    else
                    {
                        if (qteNumber == 6 && Input.GetKeyDown(KeyCode.E) || qteNumber == 8 && Input.GetKeyDown(KeyCode.E) ||
                            qteNumber == 9 && Input.GetKeyDown(KeyCode.Q) || Gamepad.current != null && qteNumber == 6 && Gamepad.all[0].rightShoulder.isPressed ||
                            Gamepad.current != null && qteNumber == 8 && Gamepad.all[0].rightShoulder.isPressed ||
                            Gamepad.current != null && qteNumber == 9 && Gamepad.all[0].leftShoulder.isPressed)
                        {
                            GetComponent<Image>().color = sucessColor;
                            fillAmount = 1;
                            StartCoroutine(FadeOut());
                            Timeline.Sucess();
                            success = true;
                        }
                        else
                        {
                            StopAllCoroutines();
                            fail = true;
                            GetComponent<Image>().color = failColor;
                            fillAmount = 1;
                            Timeline.Fail();
                        }
                    }
                }
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
            Timeline.Fail();
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
