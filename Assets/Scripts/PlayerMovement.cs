using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _horizontalForce;
    [SerializeField, Min(0.1f)] private float _jumpImpulse;
    [SerializeField, Min(1)] private int _jumpCount;

    private int _leftJumps;
    private Transform _camera;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _leftJumps = _jumpCount;
        _camera = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_leftJumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = _rigidbody.velocity;
            velocity.y = 0;
            _rigidbody.velocity = velocity;
            _rigidbody.AddForce(Vector3.up * _jumpImpulse, ForceMode.Impulse);
            _leftJumps--;
        }
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(x, 0, y).normalized;
        Vector3 directionForward = _camera.forward;
        Vector3 directionRight = _camera.right;
        directionForward.y = directionRight.y = 0;
        Vector3 force = input.x * directionRight + input.z * directionForward;
        force *= _horizontalForce;
        _rigidbody.AddForce(force);      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Any(x => x.point.y < transform.position.y))
            _leftJumps = _jumpCount;
    }
}
