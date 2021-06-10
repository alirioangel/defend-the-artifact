using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    private Transform _player;

    private Vector3 _tempCameraPosition;

    [SerializeField] private float minimumX ,maximumX;

    
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    
    private void LateUpdate()
    {
        if (!_player)
            return;
        
        _tempCameraPosition = transform.position;
        _tempCameraPosition.x = _player.position.x;
        _tempCameraPosition.y = _player.position.y;
        transform.position = _tempCameraPosition;
    }
}
