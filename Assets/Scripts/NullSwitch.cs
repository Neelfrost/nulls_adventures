using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;

public class NullSwitch : MonoBehaviour
{
    public GameObject[] target;
    private Animator _animator;

    private Light2D _light;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _light = GetComponentInChildren<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fire"))
        {
            _animator.SetTrigger("isActive");
            _light.enabled = true;

            if (target != null)
                StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        foreach (GameObject platform in target)
        {
            platform.GetComponent<Platform>().Activate();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
