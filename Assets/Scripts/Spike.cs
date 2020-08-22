using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private bool canTakeDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTakeDamage)
        {
            StartCoroutine(TakeDamage(other));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        StopAllCoroutines();
    }

    IEnumerator TakeDamage(Collider2D target)
    {
        canTakeDamage = false;
        target.GetComponent<PlayerStats>().Damage(Random.Range(0.0f, 7.5f));
        yield return new WaitForSeconds(0.25f);
        canTakeDamage = true;
        StartCoroutine(TakeDamage(target));
    }
}
