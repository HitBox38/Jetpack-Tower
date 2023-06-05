using System;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float currentScore = 0;

    public float CurrentScore
    {
        get { return currentScore; }
    }

    public static event Action<float> OnScoreChanged;

    private void OnEnable()
    {
        PlayerCollider.OnRingCollect += AddScore;
    }

    private void OnDisable()
    {
        PlayerCollider.OnRingCollect -= AddScore;
    }

    void Update()
    {
        scoreText.text = currentScore.ToString();
    }

    public void AddScore(float points)
    {
        currentScore += points;
        OnScoreChanged?.Invoke(currentScore);
    }
}
