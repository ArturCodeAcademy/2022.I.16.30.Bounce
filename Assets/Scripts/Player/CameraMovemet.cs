using UnityEngine;

public class CameraMovemet : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _xAxisTransform;
    [SerializeField] private float _xAxisSpeed;
    [SerializeField] private float _yAxisSpeed;
    [SerializeField] private bool _xInversion;
    [SerializeField] private bool _yInversion;

    private float _xAxis = 0;

    private const float MAX_X_AXIS = 75;
    private const float MIN_X_AXIS = 0;

    void LateUpdate()
    {
        transform.position = _player.position;

        float x = Input.GetAxis("Mouse X");
        if (_xInversion)
            x *= -1;
        float y = Input.GetAxis("Mouse Y");
        if (_yInversion)
            y *= -1;

        transform.Rotate(Vector3.up, x * _xAxisSpeed);

        _xAxis = Mathf.Clamp(_xAxis + y * _yAxisSpeed,
            MIN_X_AXIS, MAX_X_AXIS);
        Vector3 rot = _xAxisTransform.rotation.eulerAngles;
        rot.x = _xAxis;
        _xAxisTransform.rotation = Quaternion.Euler(rot);
    }
}
