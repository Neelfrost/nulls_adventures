using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D _collder;
    private Animator _animator;

    public bool isActive = false;

    private void Awake()
    {
        _collder = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();

        _animator.SetBool("isActive", isActive);
        _collder.enabled = isActive;
    }

    public void Activate()
    {
        if (!isActive)
        {
            _animator.SetTrigger("Enable");
            _collder.enabled = true;
        }
        else
        {
            _animator.SetTrigger("Disable");
            _collder.enabled = false;
        }
    }
}
