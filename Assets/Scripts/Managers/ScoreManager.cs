using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int currentScore = 0;

    public int CurrentScore
    {
        get { return currentScore; }
    }

    public delegate void ScoreChangedDelegate(int newScore);
    public event ScoreChangedDelegate OnScoreChanged;

    void Update()
    {
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        OnScoreChanged?.Invoke(currentScore);
    }
}
