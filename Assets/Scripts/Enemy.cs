using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public LayerMask layerGround;
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private Animator _animator;

    public float speed = 32.0f;
    private int _lookDir = 1;
    private bool _isMoving = false;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isMoving = _body.velocity.magnitude != 0.0f ? true : false;
        _animator.SetBool("isMoving", _isMoving);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector3.right * _lookDir + Vector3.down, 16.0f, layerGround);
        RaycastHit2D wallCheck = Physics2D.Raycast(transform.position, Vector3.right * _lookDir, 16.0f, layerGround);

        if (groundCheck.collider != null)
        {
            _body.velocity = Vector3.right * _lookDir * speed * 60.0f * Time.fixedDeltaTime;
        }
        else
        {
            _renderer.flipX = !_renderer.flipX;
            _lookDir = _lookDir == 1 ? -1 : 1;
        }

        if (wallCheck.collider != null)
        {
            _renderer.flipX = !_renderer.flipX;
            _lookDir = _lookDir == 1 ? -1 : 1;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.right * _lookDir + Vector3.down) * 16.0f);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.right * _lookDir) * 16.0f);
    }
}
