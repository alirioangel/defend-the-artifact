using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour
{
  public int maximumArtifactHealth = 200;
  public int artifactHealth;
  public int bleed = 2;
  private float timer;
  private AudioSource _artifactAudioSource;
  private PlayerBackpack _playerBackpack;
  private GameplayController _gameplayController;

  private void Awake()
  {
    _artifactAudioSource = GetComponent<AudioSource>();
    _playerBackpack = GameObject.FindWithTag("Player").GetComponent<PlayerBackpack>();
    _gameplayController = GameObject.FindWithTag("GameController").GetComponent<GameplayController>();
    artifactHealth = maximumArtifactHealth;
    timer = Time.time + 1f;
  }

  private void Update()
  {
    if (Time.time > timer)
    {
      artifactHealth -= bleed;
      timer = Time.time + 1f;
    }

    CheckHealth();
  }

  public void TakeDamage(int damageAmount)
  {
    artifactHealth -= damageAmount;
  }

  private void CheckHealth()
  {
    if (artifactHealth < 0)
    {
      artifactHealth = 0;
      _gameplayController.CallGameOverCanvas(true);
      Destroy(gameObject);
      
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      if(_playerBackpack.currentNumberOfStoredFruits != 0 )
        _artifactAudioSource.Play();
      artifactHealth += _playerBackpack.TakeFruits();
      if (artifactHealth > maximumArtifactHealth)
        artifactHealth = maximumArtifactHealth;
    }
  }
}
