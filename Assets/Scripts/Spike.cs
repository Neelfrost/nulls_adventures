using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // private bool canTakeDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().Damage(0.5f);
            other.attachedRigidbody.velocity = new Vector2(0.0f, 75.0f);
        }
    }
    // private void OnTriggerStay2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player") && canTakeDamage)
    //     {
    //         StartCoroutine(TakeDamage(other));
    //     }
    // }

    // IEnumerator TakeDamage(Collider2D target)
    // {
    //     canTakeDamage = false;
    //     target.GetComponent<PlayerStats>().Damage(0.5f);
    //     target.attachedRigidbody.AddForce(new Vector2(0.0f, 10.0f));
    //     yield return new WaitForSeconds(0.5f);
    //     canTakeDamage = true;
    // }
}
