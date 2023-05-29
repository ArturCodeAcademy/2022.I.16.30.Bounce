using UnityEngine;

public class SpawnAction : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    public void Spawn()
    {
        Instantiate(_prefab, _position, _rotation);
    }

    private void Reset()
    {
        _position = transform.position;
        _rotation = transform.rotation;
    }
}
