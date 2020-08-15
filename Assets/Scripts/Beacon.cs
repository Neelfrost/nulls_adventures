using System.Collections;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public SpriteRenderer[] _sprites;

    public void Activate()
    {
        StartCoroutine(Start());
    }

    IEnumerator Start()
    {
        foreach (SpriteRenderer sprite in _sprites)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(1.0f / 12.0f);
        }
    }
}
