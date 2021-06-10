using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private Canvas howToPlayCanvas;


    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void HowToPlay(bool status)
    {
        howToPlayCanvas.enabled = status;
    }

}
