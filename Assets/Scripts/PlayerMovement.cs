using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _jumpImpulse;
    
    private Transform _camera;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _camera = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
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

        if (Input.GetKeyDown(KeyCode.Space)) // Fix
            _rigidbody.AddForce(Vector3.up * _jumpImpulse, ForceMode.Impulse);
    }
}
