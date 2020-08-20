using UnityEngine;

public class TextSway : MonoBehaviour
{
    private bool swayEnabled = false;
    private float _yOffset;

    private void Start()
    {
        _yOffset = transform.localPosition.y;
    }

    private void Update()
    {
        if (swayEnabled)
        {
            Vector3 swayPos = Vector3.up * Mathf.Cos(Time.time) / 48.0f;
            transform.localPosition += swayPos;
        }
    }

    private void Sway()
    {
        swayEnabled = !swayEnabled;
        transform.localPosition = new Vector3(0.0f, _yOffset, 0.0f);
    }
}
