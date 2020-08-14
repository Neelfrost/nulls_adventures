using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D _collder;
    private Animator _animator;

    private void Awake()
    {
        _collder = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }

    public void Activate()
    {
        _animator.SetTrigger("isActive");
        _collder.enabled = true;
    }
}
