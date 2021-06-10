using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] wolfsAnimSprites;
    [SerializeField] private float time = 0.1f;
    private SpriteRenderer _spriteRenderer;
    private int state = 0;
    private float timer;
    private WolfAI _wolfAI;

    private void Awake()
    {
        _wolfAI = GetComponent<WolfAI>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(_wolfAI.isMoving)
        {
            if (Time.time > timer)
            {
                _spriteRenderer.sprite = wolfsAnimSprites[state % wolfsAnimSprites.Length];
                state++;
                timer = Time.time + time;

            }
        }
        else
        {
            _spriteRenderer.sprite = wolfsAnimSprites[0];
            
        }

        _spriteRenderer.flipX = _wolfAI.left;   

    }
}
