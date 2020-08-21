using System.Collections;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject[] targets;
    public PressurePlate connectedPlate;
    private Animator _animator;

    public bool canBePressedByPlayer = false;
    public bool isAND = false;
    private bool _pressed = false;
    private bool _hasBeenPressed = false;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canBePressedByPlayer)
            Press();
        else
            if (other.CompareTag("Pushblock"))
            Press();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _animator.SetBool("isPressed", false);
    }

    IEnumerator StartActivating()
    {
        foreach (GameObject target in targets)
        {
            if (target.CompareTag("Beacon"))
                target.GetComponent<Beacon>().Activate();
            else if (target.CompareTag("Platform"))
                target.GetComponent<Platform>().Activate();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Press()
    {
        _pressed = true;
        _animator.SetBool("isPressed", true);

        if (isAND)
        {
            if (_pressed && !_hasBeenPressed && connectedPlate._pressed)
            {
                StartCoroutine(StartActivating());
                _hasBeenPressed = true;
            }
        }
        else
        {
            if (_pressed && !_hasBeenPressed)
            {
                StartCoroutine(StartActivating());
                _hasBeenPressed = true;
            }
        }

    }
}
