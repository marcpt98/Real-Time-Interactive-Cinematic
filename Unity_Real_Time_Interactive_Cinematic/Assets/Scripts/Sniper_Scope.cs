using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Sniper_Scope : MonoBehaviour
{
    public Animator animator;
    bool isScoped = false;

    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    float scopedFOV = 10f;
    float unScopedFOV;

    public PlayableDirector sniperTimeline;
    public GameObject gameplay;
    public GameObject SniperModel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) 
        {
            animator.SetBool("Scoped", isScoped = true);
            StartCoroutine(OnScoped());
        }
        if (Input.GetButtonUp("Fire2"))
        {
            animator.SetBool("Scoped", isScoped = false);
            OnUnScoped();
        }

        if (isScoped && Input.GetButtonDown("Fire1")) 
        {
            animator.SetBool("Scoped", isScoped = false);
            OnUnScoped();
            gameplay.SetActive(false);
            SniperModel.SetActive(true);
            sniperTimeline.Play();
        }
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        unScopedFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = unScopedFOV;
    }
}
