using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : MonoBehaviour
{
  [SerializeField] private GameObject slashPrefabs;
  [SerializeField] private float coolDown = 0.3f;
  private float attackTimer;
  private AudioSource audioSource;
  private Camera mainCamera;
  private Vector3 spawnPosition;

  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
    mainCamera = Camera.main;
    
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > attackTimer)
    {
      Slash();
      audioSource.Play();
      attackTimer = Time.time + coolDown;
    }
  }

  private void Slash()
  {
    spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    spawnPosition.z = 0f;
    Instantiate(slashPrefabs, spawnPosition, Quaternion.identity);
    
  }
}
