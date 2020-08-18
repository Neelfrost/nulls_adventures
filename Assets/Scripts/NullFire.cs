using UnityEngine;

public class NullFire : MonoBehaviour
{
    public float speed = 100.0f;
    private Rigidbody2D _body;
    private ParticleSystem _system;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _system = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!_system.IsAlive())
            Destroy(_body.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Untagged") || other.CompareTag("NullSwitch"))
        {
            _system.Stop();
        }
    }

    //Instantiates a clone of the ball in the given dir
    public void Shoot(int dir)
    {
        Rigidbody2D _projectile;

        _projectile = Instantiate(_body, _body.transform.position, Quaternion.identity);

        // Reduce the collider size
        _projectile.GetComponent<CircleCollider2D>().radius = 1.0f;
        _projectile.AddForce(new Vector2(speed * Mathf.Sign(dir), 0.0f), ForceMode2D.Impulse);
    }

    //Redirects ball according to redirector's orientation
    //Returns true if ball can be redirected, to trigger animation
    public bool Redirect(Vector3 redirectFrom, Transform center)
    {
        //Here we calculate the direction to redirect the ball to,
        Vector2 redirectTo = _body.velocity.normalized + (Vector2)redirectFrom;
        float redirectToMagnitude = redirectTo.magnitude;

        //If the ball travels in a non - redirectable direction,
        //stop emitting particles and destroy ball
        if (redirectToMagnitude != 1)
        {
            _body.velocity = new Vector2(0.0f, 0.0f);
            _system.Stop();
        }
        else
        {
            //Redirect the ball
            _body.velocity = _body.velocity.magnitude * (redirectTo);
            //Tweak the position of the ball to redirector's center
            _body.transform.position = center.position;
        }

        return (redirectToMagnitude == 1);
    }
}
