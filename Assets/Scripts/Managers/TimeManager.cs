using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    private float elapsedTime = 0f;
    private bool timerRunning = true;

    public float ElapsedTime
    {
        get { return elapsedTime; }
    }

    public delegate void TimeStoppedDelegate();
    public event TimeStoppedDelegate OnTimeStopped;

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = (int)(elapsedTime / 60);
            int seconds = (int)(elapsedTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StopTimer()
    {
        timerRunning = false;
        OnTimeStopped?.Invoke();
    }
}
