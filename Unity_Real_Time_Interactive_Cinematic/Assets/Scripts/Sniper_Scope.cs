using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.InputSystem;

public class Sniper_Scope : MonoBehaviour
{
    public Animator animator;
    public bool isScoped = false;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    /*float scopedFOV = 10f;
    float unScopedFOV = 60f;*/

    public PlayableDirector sniperTimeline;
    public PlayableDirector musicTimeline;
    public GameObject gameplay;
    public GameObject SniperModel;

    public AudioSource scopeIn;
    public AudioSource scopeOut;
    public AudioSource noShoot;
    bool playUnScope = false;
    bool gamepadAim = false;
    bool gamepadShoot = false;

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current != null)
        {
            if (Gamepad.all[0].leftShoulder.isPressed && !gamepadAim)
            {
                gamepadAim = true;
                animator.SetBool("Scoped", isScoped = true);
                StartCoroutine(OnScoped());
                scopeIn.Play();
                playUnScope = true;
            }
            if (Gamepad.all[0].leftShoulder.isPressed == false)
            {
                if (playUnScope)
                {
                    scopeOut.Play();
                    playUnScope = false;
                }
                animator.SetBool("Scoped", isScoped = false);
                OnUnScoped();
                gamepadAim = false;
            }
            if (isScoped && Gamepad.all[0].rightShoulder.isPressed)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    animator.SetBool("Scoped", isScoped = false);
                    OnUnScoped();
                    gameplay.SetActive(false);
                    SniperModel.SetActive(true);
                    musicTimeline.Stop();
                    sniperTimeline.Play();
                    Debug.Log(hit.transform.gameObject.name);
                }
                else
                {
                    if (!gamepadShoot)
                    {
                        gamepadShoot = true;
                        StartCoroutine(noShootPlay());
                    }
                }
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                animator.SetBool("Scoped", isScoped = true);
                StartCoroutine(OnScoped());
                scopeIn.Play();
                playUnScope = true;
            }
            if (Input.GetKey(KeyCode.Mouse1) == false)
            {
                if (playUnScope)
                {
                    scopeOut.Play();
                    playUnScope = false;
                }
                animator.SetBool("Scoped", isScoped = false);
                OnUnScoped();
            }
            if (isScoped && Input.GetButtonDown("Fire1"))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    animator.SetBool("Scoped", isScoped = false);
                    OnUnScoped();
                    gameplay.SetActive(false);
                    SniperModel.SetActive(true);
                    musicTimeline.Stop();
                    sniperTimeline.Play();
                    Debug.Log(hit.transform.gameObject.name);
                }
                else
                {
                    noShoot.Play();
                }
            }
        }
        
        /*if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("Scoped", isScoped = false);
            OnUnScoped();
        }*/
        

        
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        //unScopedFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = 10;
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = 60;
    }

    IEnumerator noShootPlay()
    {
        noShoot.Play();
        yield return new WaitForSeconds(0.1f);
        gamepadShoot = false;
    }
}
