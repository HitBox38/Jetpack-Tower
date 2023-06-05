using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class MessageManager : MonoBehaviour
{

    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text dropText;
    [SerializeField] private float timeUntilGone = 3f;

    private void OnEnable()
    {
        PlayerCollider.OnTopReached += ActiveDropText;
        PlayerCollider.OnFinishReached += DisplayFinishText;
    }

    private void OnDisable()
    {
        PlayerCollider.OnTopReached -= ActiveDropText;
        PlayerCollider.OnFinishReached -= DisplayFinishText;
    }

    private void DisplayFinishText()
    {
        endText.enabled = true;
        endText.text = "Score: " + GetComponent<ScoreManager>().CurrentScore + "<br>Time: " + (string.Format("{0:00}:{1:00}", (int)(GetComponent<TimeManager>().ElapsedTime / 60), (int)(GetComponent<TimeManager>().ElapsedTime % 60)));
    }

    private void ActiveDropText()
    {
        StartCoroutine(ShowDropTextAndHide());
    }

    IEnumerator ShowDropTextAndHide()
    {
        dropText.enabled = true;
        yield return new WaitForSeconds(timeUntilGone);
        dropText.enabled = false;
    }
}
