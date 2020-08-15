using System.Collections;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] target;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetBool("isPressed", true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _animator.SetBool("isPressed", false);
    }
}
