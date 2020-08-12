using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMovement : MonoBehaviour
{
    public float speed = 100.0f;
    public float dir = -1.0f;

    private void Update()
    {
        Vector2 input = new Vector2(dir, Input.GetAxisRaw("Vertical"));
        transform.Translate(input * speed * Time.deltaTime);

        dir = Mathf.Sin(Time.time * 2);
    }
}
