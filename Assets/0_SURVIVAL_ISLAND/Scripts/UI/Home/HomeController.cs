using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public GameObject Introduction, Credits;

    public Button openCreditsBtn, closeCreditsBtn;
    // Start is called before the first frame update
    


    public void LoadScenePlay()
    {
        Introduction.SetActive(true);
        // SceneManager.LoadScene(1);
    }

    public void OpenCredits()
    {
        Credits.SetActive(true);
    }

    public void CloseCredits()
    {
        Credits.SetActive(false);
    }
} 
