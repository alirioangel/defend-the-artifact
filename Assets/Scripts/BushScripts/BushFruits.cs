using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BushFruits : MonoBehaviour
{

    [SerializeField] private int[] amountPerType;
    [SerializeField] private float[] respawnTime;
    private Visuals _bushVisual;
    private bool _hasFruits;
    private bool _driedBush;
    private float _timer;

    private void Start()
    {
        _bushVisual = GetComponent<Visuals>();
        
        // randomly initialize some bushes and fruits

        if (Random.Range(0, 2) == 0)
        {
            _hasFruits = false;
            _timer = Time.time + respawnTime[(int) _bushVisual.GetBushVariant()];
            
        }
        else
        {
            _hasFruits = true;
            if(!_driedBush)
                _bushVisual.ShowFruit();
        }
    }

    private void Update()
    {
        if (!(Time.time > _timer) || _driedBush) return;
        _hasFruits = true;
        _bushVisual.ShowFruit();
    }

    public bool HasFruits => _hasFruits;

    public void EatBushFruits()
    {
        _bushVisual.HideFruits();
        _hasFruits = false;
        _bushVisual.SetBushToDry();
        _driedBush = true;

    }

    public void WaterTheBush()
    {
        if (!_driedBush) return;
        _bushVisual.SetToHealthyBush();
        _driedBush = false;
        _timer = Time.time + respawnTime[(int) _bushVisual.GetBushVariant()];
    }

    public int HarvestFruits()
    {
        if (!_hasFruits) return 0;
        _hasFruits = false;
        _bushVisual.HideFruits();
        _timer = Time.time + respawnTime[(int) _bushVisual.GetBushVariant()];
        return amountPerType[(int) _bushVisual.GetBushVariant()];

    }
    
} // class
