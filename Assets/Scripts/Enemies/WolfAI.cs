using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAI : MonoBehaviour
{

    [SerializeField] private bool isEater;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int attackDamage = 5;
    [SerializeField] private float attackTimeThreshold = 1f;
    [SerializeField] private float eatTimeThreshold = 2f;
    [SerializeField] private LayerMask bushMask;
    [HideInInspector] public bool isMoving, left;
    private ArtifactController _artifact;
    private BushFruits _bushFruitsTarget;
    private float attackTimer;
    private float eatTimer;
    private bool killingBush;
    private bool isAttacking;

    private void Start()
    {
        if (isEater)
        {
            SearchForTarget();
            killingBush = false;
        }
        else
        {
            isAttacking = false;
            
        }

        _artifact = GameObject.FindWithTag("Artifact").GetComponent<ArtifactController>();
    }

    private void Update()
    {
        WolfLogic();
    }

    private void SearchForTarget()
    {
        _bushFruitsTarget = null;

        Collider2D[] hits;

        for (int i = 0; i < 50; i++)
        {
            hits = Physics2D.OverlapCircleAll(transform.position, Mathf.Exp(i), bushMask);
            foreach (var hit in hits)
            {
                if (hit && (hit.GetComponent<BushFruits>().HasFruits && hit.GetComponent<BushFruits>().enabled))
                {
                    _bushFruitsTarget = hit.GetComponent<BushFruits>();
                    break;
                }
            }

            if (_bushFruitsTarget)
                break;
        }
    }

    private void Attack()
    {
        _artifact.TakeDamage(attackDamage);
    }

    private void WolfLogic()
    {
        if (!_artifact)
            return;
        if (isEater)
        {
            if (_bushFruitsTarget && _bushFruitsTarget.enabled && _bushFruitsTarget.HasFruits && !killingBush)
            {
                if (Vector2.Distance(transform.position, _bushFruitsTarget.transform.position) > 0.5f)
                {
                    var step = moveSpeed * Time.deltaTime;
                    transform.position =
                        Vector2.MoveTowards(transform.position, _bushFruitsTarget.transform.position, step);

                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                    _bushFruitsTarget.HarvestFruits();
                    eatTimer = Time.time + eatTimeThreshold;
                    killingBush = true; 
                }
            }
            else if (killingBush)
            {
                if (Time.time > eatTimer)
                {
                    _bushFruitsTarget.EatBushFruits();
                    killingBush = false;
                    SearchForTarget();
                }
            }
            else
            {
                SearchForTarget();
            }

            if(!_bushFruitsTarget)
                SearchForTarget();

            if (_bushFruitsTarget)
            {
                left = _bushFruitsTarget.transform.position.x < transform.position.x;
            }
            
            
        }
        else
        {
            if (Vector2.Distance(transform.position, _artifact.transform.position) > 1.5f)
            {
                isMoving = true;
                var step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, _artifact.transform.position, step);
            }
            else if(!isAttacking)
            {
                isMoving = false;
                attackTimer = Time.time + attackTimeThreshold;
                isAttacking = true;
            }

            if (isAttacking)
            {
                if (Time.time > attackTimer)
                {
                    Attack();
                    attackTimer = Time.time + attackTimeThreshold;
                }
            }

            left = _artifact.transform.position.x < transform.position.x;
        }
    }
}
