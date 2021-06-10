using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthUI;
    private float _scale;
    [SerializeField] private float maxHealth = 100;
    private float _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
        
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        _scale = (float) _currentHealth / maxHealth;
        healthUI.transform.localScale = new Vector3(_scale, healthUI.transform.localScale.y, 1f);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
} // class
