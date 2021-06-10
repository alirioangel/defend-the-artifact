using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHarvest : MonoBehaviour
{

    [SerializeField] private float harvestTime = 0.4f;
    private PlayerController _playerController;
    private PlayerBackpack _playerBackpack;
    private AudioSource _audioSource;
    private Collider2D _collidedBush;
    private BushFruits hitBush;

    private bool _canHarvestFruits;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerBackpack = GetComponent<PlayerBackpack>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            TryHarvestFruit();
        }
    }

    private void TryHarvestFruit()
    {
        if (!_canHarvestFruits) return;

        if (_collidedBush) hitBush = _collidedBush.GetComponent<BushFruits>();
        
        if (!hitBush.HasFruits) return;
        _audioSource.Play();
        _playerController.HarvestStopMovement(harvestTime);
        _playerBackpack.AddFruits(hitBush.HarvestFruits());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            _canHarvestFruits = true;
            _collidedBush = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {
            _canHarvestFruits = false;
            _collidedBush = null;
        }
    }
} // class
