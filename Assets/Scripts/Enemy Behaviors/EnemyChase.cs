using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : StateMachineBehaviour
{
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private LayerMask _layerGround;
    private GameObject _player;


    public float speed = 32.0f;
    public float _chaseRange;
    public float _stopRange;
    public float _retreatRange;


    private int _lookDir = 1;
    private bool _isInstantiated = false;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_isInstantiated)
        {
            _player = PlayerController.instance.gameObject;
            _body = animator.GetComponent<Rigidbody2D>();
            _renderer = animator.GetComponent<SpriteRenderer>();
            _layerGround = LayerMask.GetMask("Ground");
            _isInstantiated = true;
        }

        _stopRange = animator.GetFloat("stopRange");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(animator.transform.position, Vector3.right * _lookDir + Vector3.down, 16.0f, _layerGround);
        RaycastHit2D wallCheck = Physics2D.Raycast(animator.transform.position, Vector3.right * _lookDir, 16.0f, _layerGround);

        Vector2 toPlayer = _player.transform.position - animator.transform.position;

        _lookDir = 1 * (int)Mathf.Sign(toPlayer.x);

        if (groundCheck.collider != null)
        {
            if (toPlayer.magnitude < _chaseRange)
            {
                if (toPlayer.magnitude > _stopRange)
                    _body.velocity = Vector2.right * _lookDir * speed * 60.0f * Time.deltaTime;
                else if (toPlayer.magnitude < _stopRange && toPlayer.magnitude > _retreatRange)
                {
                    animator.SetBool("isAttacking", true);
                    _body.velocity = Vector2.zero;
                }
                else if (toPlayer.magnitude < _retreatRange)
                    _body.velocity = Vector2.right * _lookDir * -speed * 60.0f * Time.deltaTime;
            }
            else
                animator.SetBool("isPatrolling", true);
        }
        else
        {
            _lookDir = _lookDir == 1 ? -1 : 1;
        }

        if (wallCheck.collider != null)
        {
            _lookDir = _lookDir == 1 ? -1 : 1;
        }

        _renderer.flipX = _lookDir == 1 ? false : true;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("isChasing", false);
    }
}
