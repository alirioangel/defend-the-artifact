using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBackpack : MonoBehaviour
{

    public int maxNumberOfFruitsToStore = 50;
    public int currentNumberOfStoredFruits;

    [SerializeField] private Text _backpackInfo;

    private void Start()
    {
        SetBackpackInfoText(0);
    }

    public void AddFruits(int amount)
    {
        currentNumberOfStoredFruits += amount;
        if (currentNumberOfStoredFruits > maxNumberOfFruitsToStore)
            currentNumberOfStoredFruits = maxNumberOfFruitsToStore;
        SetBackpackInfoText(currentNumberOfStoredFruits);
    }

    public int TakeFruits()
    {
        var takenFruits = currentNumberOfStoredFruits;
        currentNumberOfStoredFruits = 0;
        
        SetBackpackInfoText(currentNumberOfStoredFruits);

        return takenFruits;
    }

    private void SetBackpackInfoText(int amount)
    {
        _backpackInfo.text = $"Backpack: {currentNumberOfStoredFruits}/{maxNumberOfFruitsToStore}";
    }

}// class









