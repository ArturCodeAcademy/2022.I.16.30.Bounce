using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private TMP_Text _scoreText;

    private void Start()
    {
        _scoreManager.OnScoreValueChanged += UpdateUI;
        UpdateUI(_scoreManager.Score);
    }

    private void UpdateUI(int score)
    {
        _scoreText.text = $"Score: {score:00000}";
    }

    private void OnDestroy()
    {
        _scoreManager.OnScoreValueChanged -= UpdateUI;
    }
}
