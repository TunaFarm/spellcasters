using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayerController
{
    [SerializeField] Collider2D boundary;

    private float _timeElapsed = 0.0f;
    private float _speed = 1.4f;
    private Collider2D _playerCollider;
    private float _playerWidth;
    private float _playerHeight;

    private void Awake()
    {
        _playerCollider = transform.GetComponent<Collider2D>();
        _playerWidth = _playerCollider.bounds.size.x / 2;
        _playerHeight = _playerCollider.bounds.size.y / 2;
    }

    private void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, boundary.bounds.min.x + _playerWidth, boundary.bounds.max.x - _playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, boundary.bounds.min.y + _playerHeight, boundary.bounds.max.y - _playerHeight);
        transform.position = viewPos;
    }

    public void MoveTo(Vector2 position)
    {
        var distance = Vector2.Distance(transform.position, position);
        if (Mathf.Round(distance * 1000) == 0)
        {
            transform.position = position;
            _timeElapsed = 0.0f;
        }

        var moveDuration = distance * 100 / _speed;

        if (_timeElapsed < moveDuration)
        {
            transform.position = Vector2.Lerp(transform.position, position, _timeElapsed / moveDuration);
            _timeElapsed += Time.deltaTime;
        }
    }
}
