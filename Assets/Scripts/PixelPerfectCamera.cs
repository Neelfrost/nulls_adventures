using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
    public static float pixelToUnits = 1.0f;
    public static float scale = 1.0f;
    public Vector2 nativeResolution = new Vector2(480, 320);
    private Camera _camera;
    void Awake()
    {
        _camera = GetComponent<Camera>();

        if (_camera.orthographic)
        {
            scale = Screen.height / nativeResolution.y;
            pixelToUnits *= scale;
            _camera.orthographicSize = (Screen.height / 2.0f) / pixelToUnits;
        }
    }
}
