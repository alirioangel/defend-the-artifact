using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Visuals : MonoBehaviour
{

    [SerializeField] private Sprite[] bushSprites, fruitSprites, drySprites;
    [SerializeField] private SpriteRenderer[] fruitRenderers;

    public enum BushVariant
    { Green, Cyan, Yellow }

    private BushVariant _bushVariant;
    public float hideTimePerFruit = 0.2f;
    [FormerlySerializedAs("waterTheBush")] public float _waterTheBush = 0.5f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _bushVariant = (BushVariant) Random.Range(0, bushSprites.Length);
        _spriteRenderer.sprite = bushSprites[(int) _bushVariant];

        if (Random.Range(0, 2) == 1)
            _spriteRenderer.flipX = true;

        foreach (var fruit in fruitRenderers)
        {
            fruit.sprite = fruitSprites[(int) _bushVariant];
            fruit.enabled = false;
        }
    }

    public BushVariant GetBushVariant()
    {
        return _bushVariant;
    }

    public void SetBushToDry()
    {
        _spriteRenderer.sprite = drySprites[(int) _bushVariant];
    }

    IEnumerator _HideFruits(float time, int index)
    {
        yield return new WaitForSeconds(time);
        fruitRenderers[index].enabled = false;
    }

    public void HideFruits()
    {
        float waitTimeForFruit = hideTimePerFruit;

      for(var i = 0; i < fruitRenderers.Length; i++)
        {
            StartCoroutine(_HideFruits(waitTimeForFruit, i));
            waitTimeForFruit += hideTimePerFruit;
        }
    }

    public void ShowFruit()
    {
        foreach (var fruit in fruitRenderers)
            fruit.enabled = true;
    }

    IEnumerator _SetToHealthyBush(float time)
    {
        yield return new WaitForSeconds(time);
        _spriteRenderer.sprite = bushSprites[(int) _bushVariant];
    }

    public void SetToHealthyBush()
    {
        StartCoroutine(_SetToHealthyBush(_waterTheBush));
    }
}// class





