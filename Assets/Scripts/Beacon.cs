using System.Collections;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    public SpriteRenderer[] _sprites;

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
        yield return new WaitForSeconds(5.0f);
        GameManager.Instance.LoadScene();
    }
}
