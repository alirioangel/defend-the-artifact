using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject wolf,eater;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int eaterChance = 3;
    [SerializeField] private float spawnTime = 12f;
    [SerializeField] private float spawnReductionPerWolf = 1f;
    [SerializeField] private float minSpawnDelay = 3.5f;

    private float currentSpawnTime;
    private float timer;
        
    private void Start()
    {
        currentSpawnTime = spawnTime;
        timer = Time.time;
    }

    private void Update()
    {
        if (Time.time > timer)
        {
            Spawn();
            currentSpawnTime -= spawnReductionPerWolf;
            if (currentSpawnTime < minSpawnDelay)
                currentSpawnTime = minSpawnDelay;
            timer = Time.time + currentSpawnTime;
        }
    }

    private void Spawn()
    {
        if (Random.Range(0, 11) > eaterChance)
        {
            Instantiate(wolf,spawnPoints[Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
        }
        else
        {
            Instantiate(eater, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        }
        
    }
}
