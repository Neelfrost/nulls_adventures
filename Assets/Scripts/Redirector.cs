using UnityEngine;

public class Redirector : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _redirectTo;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Debug.Log(transform.eulerAngles.z + gameObject.name);
    }

    private void Start()
    {
        switch ((int)transform.eulerAngles.z)
        {
            case 0:
                _redirectTo = new Vector3(1.0f, 1.0f, 0.0f);
                break;
            case 270:
                _redirectTo = new Vector3(1.0f, -1.0f, 0.0f);
                break;
            case 180:
                _redirectTo = new Vector3(-1.0f, -1.0f, 0.0f);
                break;
            case 90:
                _redirectTo = new Vector3(-1.0f, 1.0f, 0.0f);
                break;
        }
        // Debug.Log(_redirectTo );
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.forward * -90.0f);
        _redirectTo = Vector3.Cross(Vector3.back, _redirectTo);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Fire")
        {
            _animator.SetTrigger("Hit");

            Rigidbody2D ball = other.GetComponent<Rigidbody2D>();
            ball.velocity = ball.velocity.magnitude * (ball.velocity.normalized + (Vector2)_redirectTo);
        }
    }
}
