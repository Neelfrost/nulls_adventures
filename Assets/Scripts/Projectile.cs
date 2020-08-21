using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    private float _timer;
    private float _maxLife = 5.0f;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 direction = PlayerController.instance.transform.position - transform.position;
        _body.AddForce(direction.normalized * speed * 60.0f * Time.deltaTime);

        _timer = 0;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _maxLife)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerStats>().Damage(1.0f);

        if (other.CompareTag("Player") || other.CompareTag("Untagged"))
            Destroy(gameObject);
    }
}
