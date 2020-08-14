using UnityEngine;

public class Redirector : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _redirectFrom;
    private Transform _center;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        //Child's transfrom is at an offset of (2,2) from parent,
        //used to tweak the ball position
        _center = transform.GetChild(0);
    }

    //Get the orientation of redirector
    private void Start()
    {
        switch ((int)transform.eulerAngles.z)
        {
            case 0:
                _redirectFrom = new Vector3(1.0f, 1.0f, 0.0f);
                break;
            case 270:
                _redirectFrom = new Vector3(1.0f, -1.0f, 0.0f);
                break;
            case 180:
                _redirectFrom = new Vector3(-1.0f, -1.0f, 0.0f);
                break;
            case 90:
                _redirectFrom = new Vector3(-1.0f, 1.0f, 0.0f);
                break;
        }
    }

    //Rotates along z axis 
    public void Rotate()
    {
        transform.Rotate(Vector3.forward * -90.0f);
        _redirectFrom = Vector3.Cross(Vector3.back, _redirectFrom);
    }

    //Redirect incoming ball
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Fire"))
        {
            if (other.GetComponent<NullFire>().Redirect(_redirectFrom, _center))
                //Play hit animation
                _animator.SetTrigger("Hit");
        }
    }
}
