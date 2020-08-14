using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 75;
    public float jumpSpeed = 120;
    public float fallMultiplier = 3.0f;
    public float lowJumpMultiplier = 6.0f;
    private float _inputHorizontal;
    private int _lookDir;
    private bool _isGrounded;

    public Transform _groundCheck_L, _groundCheck_R;
    private Rigidbody2D _body;
    private SpriteRenderer _renderer;
    private Animator _animator;
    private ShootFireball _shoot;

    [SerializeField] public LayerMask layerGround;
    [SerializeField] public LayerMask layerInteract;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _shoot = GetComponent<ShootFireball>();
    }

    private void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.velocity = Vector2.up * jumpSpeed;
        }

        if (_body.velocity.y < 0)
            _body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (_body.velocity.y > 0 && !Input.GetButton("Jump"))
            _body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        //Attack
        if (Input.GetKeyDown(KeyCode.F) && _isGrounded)
        {
            _animator.SetTrigger("Attack");
            Interact();
        }

        FlipSprite();
        ChangeAnimations();
    }

    private void FixedUpdate()
    {
        //Check for ground
        _isGrounded = Physics2D.OverlapCircle(_groundCheck_L.position, 0.5f, layerGround) || Physics2D.OverlapCircle(_groundCheck_R.position, 0.5f, layerGround);

        //Move player smoothly 
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 targetVelocity = new Vector2(_inputHorizontal * speed * 60.0f * Time.fixedDeltaTime, _body.velocity.y);
        _body.velocity = targetVelocity;
    }

    private void FlipSprite()
    {
        if (_inputHorizontal == 1)
        {
            _lookDir = 1;
            _renderer.flipX = false;
        }
        else if (_inputHorizontal == -1)
        {
            _lookDir = -1;
            _renderer.flipX = true;
        }
    }

    private void ChangeAnimations()
    {
        if (Mathf.Abs(_body.velocity.x) > 20)
            _animator.SetBool("isRunning", true);
        else
            _animator.SetBool("isRunning", false);

        if (_body.velocity.y > 0)
            _animator.SetBool("isJumping", true);

        if (_body.velocity.y < 0)
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isFalling", true);
        }
        else if (_isGrounded)
            _animator.SetBool("isFalling", false);
    }

    private void Interact()
    {
        //Cast a ray to check for interactables
        RaycastHit2D interactable = Physics2D.Raycast(transform.position, Vector2.right * _lookDir, 13.0f, layerInteract);

        if (interactable.collider != null)
        {
            //Here we call the respective methods
            if (interactable.collider.tag == "Fire")
                interactable.collider.GetComponent<ShootFireball>().Shoot(_lookDir);
            else if (interactable.collider.tag == "Redirector")
                interactable.collider.GetComponentInParent<Redirector>().Rotate();
        }
    }
}