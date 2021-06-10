using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private Canvas wonCanvas;
    [SerializeField] private Canvas gameOverCanvas;


    public void CallWonCanvas(bool status)
    {
        wonCanvas.enabled = status;
    }

    public void CallGameOverCanvas(bool status)
    {
        gameOverCanvas.enabled = status;
    }

    public void RestartGame()
    {
        CallWonCanvas(false);
        CallGameOverCanvas(false);
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
