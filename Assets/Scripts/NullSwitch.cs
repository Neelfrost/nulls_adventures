using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;

public class NullSwitch : MonoBehaviour
{
    public GameObject[] targets;
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

            if (targets != null)
                StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
        foreach (var target in targets)
        {
            if (target.CompareTag("Beacon"))
                target.GetComponent<Beacon>().Activate();
            else if (target.CompareTag("Platform"))
                target.GetComponent<Platform>().Activate();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
