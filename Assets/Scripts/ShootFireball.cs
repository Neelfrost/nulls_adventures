using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public float speed = 100.0f;
    public Rigidbody2D _ballPrefab;

    public void Shoot()
    {
        Rigidbody2D _projectile;

        Collider2D _contact = Physics2D.OverlapCircle(_ballPrefab.transform.position, 10.0f);

        if (_contact.tag == "Player")
        {
            Vector2 shootDir = _ballPrefab.transform.position - _contact.transform.position;

            _projectile = Instantiate(_ballPrefab, _ballPrefab.transform.position, Quaternion.identity);
            _projectile.AddForce(new Vector2(speed * Mathf.Sign(shootDir.x), 0.0f), ForceMode2D.Impulse);
        }
    }
}
