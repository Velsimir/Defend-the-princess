using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]

public class MovingClouds : MonoBehaviour
{
    [SerializeField] private float _speed;

    private SpriteRenderer _sprite;
    [SerializeField] private float _startImagePositionX;
    [SerializeField] private float _currentImagePositionX;
    [SerializeField] private float _endImagePositionX;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _sprite.drawMode = SpriteDrawMode.Tiled;

        _startImagePositionX = _sprite.size.x;
        _currentImagePositionX = _sprite.size.x;
        _endImagePositionX = _sprite.size.x * 3;
    }

    private void Update()
    {
        _currentImagePositionX += _speed * Time.deltaTime;

        if (_currentImagePositionX >= _endImagePositionX)
            _currentImagePositionX = _startImagePositionX;

        _sprite.size = new Vector2(_currentImagePositionX, _sprite.size.y);
    }
}
