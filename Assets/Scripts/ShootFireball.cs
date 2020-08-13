using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public float speed = 100.0f;
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }
    public void Shoot(int dir)
    {
        Rigidbody2D _projectile;
        _projectile = Instantiate(_body, _body.transform.position, Quaternion.identity);
        _projectile.GetComponent<CircleCollider2D>().radius = 1.0f;
        _projectile.AddForce(new Vector2(speed * Mathf.Sign(dir), 0.0f), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Untagged")
        {
            Destroy(gameObject);
        }
    }
}
