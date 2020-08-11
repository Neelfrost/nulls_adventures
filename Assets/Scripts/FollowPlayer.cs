using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing = 10.0f;

    private Vector3 _offset;

    private void Start()
    {
        _offset.y = 20.0f;
        _offset.z = transform.position.z - player.position.z;
    }
    private void LateUpdate()
    {
        Vector3 targetPosition = player.position + _offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
