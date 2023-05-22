using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [field: SerializeField] public Vector3 Position;

#if UNITY_EDITOR

    private void Reset()
    {
        Position = transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        const float SIZE = 0.5f;
        
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Position, SIZE);
    }

#endif
}
