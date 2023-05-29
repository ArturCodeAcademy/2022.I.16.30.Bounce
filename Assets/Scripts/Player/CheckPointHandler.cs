using UnityEngine;

public class CheckPointHandler : MonoBehaviour
{
    private Vector3 _lastCheckPoint;
    Rigidbody _rb;

    private void Start()
    {
        _lastCheckPoint = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CheckPoint point))
        {
            _lastCheckPoint = point.Position;
            Destroy(point.gameObject);
            return;
        }
        if (other.TryGetComponent(out Obstacle _))
            SetPosition(_lastCheckPoint);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle _))
            SetPosition(_lastCheckPoint);
    }

    private void SetPosition(Vector3 point)
    {
        transform.position = point;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}
