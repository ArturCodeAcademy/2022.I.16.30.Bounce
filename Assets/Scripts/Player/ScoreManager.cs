using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int> OnScoreValueChanged;
    public int Score { get; private set; } = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collectable collectable))
        {
            Score += collectable.Score;
            OnScoreValueChanged?.Invoke(Score);
            collectable.Take();
        }
    }
}
