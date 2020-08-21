using UnityEngine;

public class TeleportToPlatform : MonoBehaviour
{
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.transform.position = _transform.position;
    }
}
