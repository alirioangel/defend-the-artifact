using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    [SerializeField] private Sprite[] slashSprites;
    [SerializeField] private float timeThreshold = 0.06f;
    [SerializeField] private int damage = 35;
    private float timer;
    private int state = 0;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        if (Time.time > timer)
        {
            _spriteRenderer.sprite = slashSprites[state % slashSprites.Length];
            state++;
            timer = Time.time + timeThreshold;
            if (state == slashSprites.Length)
            {
                Destroy(gameObject);
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<WolfHealth>().TakeDamage(damage);
        }
    }
}
