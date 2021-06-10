using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // this script is just for academical purposes and is actually not used in the game.

    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] _animSpritesArray;
    private float _timeThreshold = 0.1f;
    private float _timer;
    private int state = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CalculateSpriteToRender();
    }

    private void CalculateSpriteToRender()
    {
        if (!(Time.time > _timer)) return;
         /*
          * state % _animSpritesArray.Length gonna evaluate the remains of the division of state/ _animSpritesArray.Length.
          */
        _spriteRenderer.sprite = _animSpritesArray[state % _animSpritesArray.Length];
        state++;
        // an easiest way to understand how it is works is: 
        
        /*
         * _spriteRenderer.sprite = _animSpritesArray[state];
         * state++;
         *
         * if (state == _animSpritesArray.Length){
         *      state = 0;
         * }
         */
        _timer = Time.time + _timeThreshold;
    }
}
