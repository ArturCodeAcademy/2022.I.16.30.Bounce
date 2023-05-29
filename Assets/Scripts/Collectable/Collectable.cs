using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    public UnityEvent OnTake;
    [field:SerializeField, Min(0)] public int Score { get; private set; }

    [SerializeField] private bool _destroyOnTake;

    private void Awake()
    {
        OnTake ??= new UnityEvent();
    }

    public virtual void Take()
    {
        OnTake?.Invoke();
        if (_destroyOnTake)
            Destroy(gameObject);
    }
}
