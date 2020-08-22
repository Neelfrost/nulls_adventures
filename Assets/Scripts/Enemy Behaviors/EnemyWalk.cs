using UnityEngine;

public class EnemyWalk : StateMachineBehaviour
{
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private LayerMask _layerGround, _layerPlayer;


    public float speed = 32.0f;
    private int _lookDir = 1;


    private float _timer;
    private float _patrolTime;
    private bool _isInstantiated = false;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_isInstantiated)
        {
            _body = animator.GetComponent<Rigidbody2D>();
            _renderer = animator.GetComponent<SpriteRenderer>();
            _layerGround = LayerMask.GetMask("Ground");
            _layerPlayer = LayerMask.GetMask("Player");
            _isInstantiated = true;
        }

        _timer = 0.0f;
        _patrolTime = Random.Range(5.0f, 10.0f);

        _lookDir = _renderer.flipX ? -1 : 1;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;

        if (_timer > _patrolTime)
        {
            if (Random.Range(1, 4) == 1)
            {
                animator.SetBool("isPatrolling", false);
                animator.SetFloat("idlePeriod", Random.Range(1.0f, 4.0f));
            }
            else
            {
                _lookDir = Random.Range(1, 2) == 1 ? 1 : -1;
                _renderer.flipX = _lookDir == 1 ? false : true;
                _patrolTime = Random.Range(5.0f, 10.0f);
            }
        }
        else
        {
            RaycastHit2D groundCheck = Physics2D.Raycast(animator.transform.position, Vector3.right * _lookDir * 2.0f + Vector3.down, 18.0f, _layerGround);
            RaycastHit2D wallCheck = Physics2D.Raycast(animator.transform.position, Vector3.right * _lookDir, 16.0f, _layerGround);
            RaycastHit2D playerCheck = Physics2D.Raycast(animator.transform.position, Vector3.right * _lookDir, 48.0f, _layerPlayer);

            // Debug.DrawRay(animator.transform.position, (Vector3.right * _lookDir * 2.0f + Vector3.down) * 18, Color.red);

            if (groundCheck.collider != null)
            {
                if (playerCheck.collider == null)
                    _body.velocity = Vector2.right * _lookDir * speed * 60.0f * Time.fixedDeltaTime;
                else
                    animator.SetBool("isChasing", true);
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
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool("isPatrolling", false);
    }
}
