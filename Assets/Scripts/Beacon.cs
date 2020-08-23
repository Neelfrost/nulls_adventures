using System.Collections;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public SpriteRenderer[] _sprites;

    private Transition _transition;

    private void Awake()
    {
        _transition = GameObject.FindGameObjectWithTag("Transition").GetComponent<Transition>();
    }

    public void Activate()
    {
        StartCoroutine(StartActivating());
    }

    IEnumerator StartActivating()
    {
        foreach (SpriteRenderer sprite in _sprites)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(1.0f / 6.0f);
        }
        yield return new WaitForSeconds(1.0f);
        _transition.LoadNextLevel();
    }
}
