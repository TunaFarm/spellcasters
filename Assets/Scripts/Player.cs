using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] Collider2D boundary;

    public bool mine;
    public string id;
    public string name;
    public TMP_Text nameLabel;

    private float _timeElapsed = 0.0f;
    private float _speed = 4.4f;
    private Collider2D _playerCollider;
    private float _playerWidth;
    private float _playerHeight;

    private SpriteRenderer spriteRenderer;

    public GamePlay gamePlay;
    public PlayerMovement playerMovement;
    
    private void Start()
    {
        gameObject.name = name;
        nameLabel.text = name;

        _playerCollider = transform.GetComponent<Collider2D>();
        _playerWidth = _playerCollider.bounds.size.x / 2;
        _playerHeight = _playerCollider.bounds.size.y / 2;

        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
    }

    private void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, boundary.bounds.min.x + _playerWidth, boundary.bounds.max.x - _playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, boundary.bounds.min.y + _playerHeight,
            boundary.bounds.max.y - _playerHeight);
        transform.position = viewPos;
    }

    public void Move(Vector3 target)
    {
        if (!mine)
        {
            return;
        }

        gamePlay.Send(new
        {
            action = "MOVE",
            position = new
            {
                x = target.x,
                y = target.y,
                z = target.z
            }
        });
    }

  
}