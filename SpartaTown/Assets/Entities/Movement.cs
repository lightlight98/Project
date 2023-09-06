using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharaterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _righdbody;


    [SerializeField] private SpriteRenderer characterRenderer;
    private void Awake()
    {
        _controller = GetComponent<CharaterController>();
        _righdbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        characterRenderer.flipX = mouse.x < transform.position.x;

    }
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        _righdbody.velocity = direction;
    }
}