using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 3f;
    private Rigidbody2D _playerRB;
    private Vector2 _moveVector;
    private SpriteRenderer _playerSR;
    private Animator _playerAnimator;
    private float harvestTimer;
    private bool isHarvesting;
    private GameObject artifact;
    private string MOVEMENT_HORIZONTAL = "Horizontal";
    private string MOVEMENT_VERTICAL = "Vertical";
    private string WALKING = "Walking";
    private bool isWalking;

    
    
    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerSR = GetComponent<SpriteRenderer>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.time > harvestTimer) isHarvesting = false;
        AnimatePlayer();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (isHarvesting)
        {
            _playerRB.velocity = Vector2.zero;
        }
        else
        {
            _moveVector = new Vector2(Input.GetAxis(MOVEMENT_HORIZONTAL), Input.GetAxis(MOVEMENT_VERTICAL));
            if (_moveVector.sqrMagnitude > 1)
            {
                _moveVector = _moveVector.normalized;
            }
            _playerRB.velocity = new Vector2(_moveVector.x * movementSpeed,
                _moveVector.y * movementSpeed);
        }
    }
    private void FlipSprite()
    {
        if (Input.GetAxisRaw(MOVEMENT_HORIZONTAL) == 1)
            _playerSR.flipX = false;
        else if (Input.GetAxisRaw(MOVEMENT_HORIZONTAL) == -1)
            _playerSR.flipX = true;
    }

    private void AnimatePlayer()
    {
        if (isHarvesting)
            isWalking = false;
        if (Math.Abs(Input.GetAxisRaw(MOVEMENT_HORIZONTAL)) >= 0.5 ||
            Math.Abs(Input.GetAxisRaw(MOVEMENT_VERTICAL)) >= 0.5)
            isWalking = true;
        else
            isWalking = false;
        
        
        _playerAnimator.SetBool(WALKING, isWalking);
    }

    public void HarvestStopMovement(float time)
    {
        isHarvesting = true;
        harvestTimer = Time.time + time;
            
    }

    public bool IsHarvesting => isHarvesting;
}
