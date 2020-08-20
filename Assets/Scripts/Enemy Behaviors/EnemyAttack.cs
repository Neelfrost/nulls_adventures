using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : StateMachineBehaviour
{
    private GameObject _player;
    private SpriteRenderer _renderer;
    private GameObject _projectile;

    public float _stopRange;
    public float _fireRate;


    private int _lookDir = 1;
    private bool _isInstantiated = false;
    private float _timer;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_isInstantiated)
        {
            _player = PlayerController.instance.gameObject;
            _renderer = animator.GetComponent<SpriteRenderer>();
            _projectile = animator.GetComponent<Enemy>().projectile;
            _isInstantiated = true;
        }

        _timer = 0;
        _stopRange = animator.GetFloat("stopRange");
        animator.SetBool("isChasing", false);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;

        Vector2 toPlayer = _player.transform.position - animator.transform.position;

        _lookDir = 1 * (int)Mathf.Sign(toPlayer.x);

        if (toPlayer.magnitude > _stopRange)
            animator.SetBool("isChasing", true);
        else
        {
            if (_timer > _fireRate)
            {
                Shoot();
                _timer = 0;
            }
        }

        if (_lookDir == 1)
        {
            _renderer.flipX = false;
            Enemy.trigger.localPosition = Vector2.right * 8.0f;
        }
        else
        {
            _renderer.flipX = true;
            Enemy.trigger.localPosition = Vector2.right * -8.0f;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false);
    }

    private void Shoot()
    {
        Instantiate(_projectile, Enemy.trigger.position, Quaternion.identity);
    }
}
