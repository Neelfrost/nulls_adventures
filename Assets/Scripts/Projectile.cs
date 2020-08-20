using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 direction = PlayerController.instance.transform.position - Enemy.trigger.position;
        _body.velocity = direction.normalized * speed * 60.0f * Time.deltaTime;
    }

    private void Update()
    {
        speed += (1 / 8) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerStats>().Damage(1.0f);

        if (other.CompareTag("Player") || other.CompareTag("Untagged"))
            Destroy(gameObject);
    }
}
