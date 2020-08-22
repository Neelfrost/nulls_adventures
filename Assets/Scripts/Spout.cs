using UnityEngine;

public class Spout : MonoBehaviour
{
    public GameObject prefab;
    private Animator _animator;
    private bool _hasBeenActivated = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerAnimation()
    {
        if (!_hasBeenActivated)
        {
            _animator.SetTrigger("Enable");
            _hasBeenActivated = true;
        }
    }

    public void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
