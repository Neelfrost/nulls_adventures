using System.Collections;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] targets;
    private Animator _animator;

    private bool _pressed = false;
    private bool _hasBeenPressed = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetBool("isPressed", true);
        _pressed = true;

        if (_pressed && !_hasBeenPressed)
        {
            StartCoroutine(StartActivating());
            _hasBeenPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _animator.SetBool("isPressed", false);
    }

    IEnumerator StartActivating()
    {
        foreach (GameObject target in targets)
        {
            target.GetComponent<Beacon>().Activate();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
