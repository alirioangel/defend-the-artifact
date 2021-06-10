using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Text timerText;
    public float timeToWin = 300f;
    private bool _gameOver;
    private GameObject _artifact;
    private StringBuilder _stringBuilder;
    private GameplayController _gameplayController;

    private void Awake()
    {
        _artifact = GameObject.FindWithTag("Artifact");
        _gameplayController = GameObject.FindWithTag("GameController").GetComponent<GameplayController>();

        _stringBuilder = new StringBuilder();
    }

    private void Update()
    {

        if (_gameOver || !_artifact) return;
        
        timeToWin -= Time.deltaTime;

        if (timeToWin <= 0f)
        {
            timeToWin = 0f;
            _gameOver = true;
            _gameplayController.CallWonCanvas(true);
            Destroy(_artifact);
        }

        /*
         * This piece of code is really heavy for mobile device don't do it in this way.
         */
       // timerText.text = $"Time Remaining: {(int) timeToWin}";

       DisplayTime((int) timeToWin);
    }

    private void DisplayTime(int time)
    {
        //reset string Builder;
        _stringBuilder.Length = 0;

        _stringBuilder.Append("Time Remaining: ");
        _stringBuilder.Append(time);

        timerText.text = _stringBuilder.ToString();
    }
}
