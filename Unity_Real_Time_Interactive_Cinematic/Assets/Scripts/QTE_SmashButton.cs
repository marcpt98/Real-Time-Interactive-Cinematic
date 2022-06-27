using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class QTE_SmashButton : MonoBehaviour
{
    public float fillAmount = 0;
    float timePassed = 0;
    float maxTime = 0.05f;
    float fillProgress = 0.1f;
    float substractProgress = 0.01f;
    bool fail = false;
    Color sucessColor = new Color32(102, 255, 102, 255);
    Color failColor = new Color32(255, 102, 102, 255);
    GameObject gparent;
    float Strength = 2;
    float PulseDelay = 0.1f;
    float ReturnToNormalSpeed = 2;
    float BeatDelay = 0;
    bool firstframe = false;
    bool callfade = false;
    QTE_Manager Timeline;
    int qteNumber;

    // Start is called before the first frame update
    void Start()
    {
        Timeline = GameObject.Find("Parkour_TimelineManager").GetComponent<QTE_Manager>();
        gparent = transform.parent.gameObject;
        StartCoroutine(time());
        StartCoroutine(Pulse());
    }

    // Update is called once per frame
    void Update()
    {
        if (!fail)
        {
            if (fillAmount < 1)
            {
                if (Input.anyKeyDown || Gamepad.all[0].IsPressed(1))
                {
                    qteNumber = Timeline.qte_number;

                    if (qteNumber == 2 && Input.GetKeyDown(KeyCode.W) || qteNumber == 3 && Input.GetKeyDown(KeyCode.W) || 
                        qteNumber == 2 && Gamepad.all[0].crossButton.isPressed || qteNumber == 3 && Gamepad.all[0].crossButton.isPressed)
                    {
                        fillAmount += fillProgress;
                    }
                    else
                    {
                        StopAllCoroutines();
                        fail = true;
                        GetComponent<Image>().color = failColor;
                        fillAmount = 1;
                        Timeline.Fail();
                    }

                    timePassed += Time.deltaTime;

                    if (timePassed > maxTime)
                    {
                        timePassed = 0;
                        fillAmount -= substractProgress;
                    }

                    if (fillAmount < 0)
                    {
                        fillAmount = 0;
                    }
                }
                timePassed += Time.deltaTime;

                if (timePassed > maxTime)
                {
                    timePassed = 0;
                    fillAmount -= substractProgress;
                }

                if (fillAmount < 0)
                {
                    fillAmount = 0;
                }
            }
            else
            {
                if (!callfade)
                {
                    GetComponent<Image>().color = sucessColor;
                    fillAmount = 1;
                    StartCoroutine(FadeOut());
                    callfade = true;
                    Timeline.Sucess();
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

    IEnumerator Pulse()
    {
        // Loops forever
        while (fillAmount < 1) 
        {
            float timer = 0f;
            float originalSize = gparent.transform.localScale.x;

            while (timer < PulseDelay)
            {
                yield return new WaitForEndOfFrame();
                timer += Time.deltaTime;

                gparent.transform.localScale = new Vector3
                (
                    gparent.transform.localScale.x + (Time.deltaTime * Strength * 2),
                    gparent.transform.localScale.y + (Time.deltaTime * Strength * 2)
                );
            }

            if (firstframe)
            {
                // Return to normal
                while (gparent.transform.localScale.x > originalSize)
                {
                    yield return new WaitForEndOfFrame();

                    gparent.transform.localScale = new Vector3
                    (
                        gparent.transform.localScale.x - Time.deltaTime * Strength * ReturnToNormalSpeed,
                        gparent.transform.localScale.y - Time.deltaTime * Strength * ReturnToNormalSpeed
                    );
                }
            }
            firstframe = true;

            gparent.transform.localScale = new Vector3(originalSize, originalSize);

            yield return new WaitForSeconds(BeatDelay);
        }
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(2.75f);
        
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
