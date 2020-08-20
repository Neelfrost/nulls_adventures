using UnityEngine;

public class Guide : MonoBehaviour
{
    public Animator _animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _animator.SetBool("isActive", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            _animator.SetBool("isActive", false);
    }
}
