using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public GameObject instructions;
    bool insactive = false;

    public void PlayGame()
    {
        FadeToLevel();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlay()
    {
        insactive = !insactive;
        instructions.SetActive(insactive);
    }
}
