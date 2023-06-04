using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private Transform collectibles;
    [SerializeField] private GameObject endTrigger;
    [SerializeField] private TMP_Text endText;
    [SerializeField] private TMP_Text dropText;
    [SerializeField] private float timeUntilGone = 3f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            scoreManager.AddScore(10);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.name == "DropTrigger")
        {
            EnableChildrenInGameObject(collectibles);
            endTrigger.SetActive(true);
            StartCoroutine(ShowDropTextAndHide(timeUntilGone));
        }
        if (other.CompareTag("Finish"))
        {
            Debug.Log("finished");
            timeManager.StopTimer();
            endText.enabled = true;
            endText.text = "Score: " + scoreManager.CurrentScore + "<br>Time: " + (string.Format("{0:00}:{1:00}", (int)(timeManager.ElapsedTime / 60), (int)(timeManager.ElapsedTime % 60)));
        }
    }

    private void EnableChildrenInGameObject(Transform parent)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).CompareTag("Collectible"))
            {
                parent.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    IEnumerator ShowDropTextAndHide(float duration)
    {
        dropText.enabled = true;
        yield return new WaitForSeconds(duration);
        dropText.enabled = false;
    }
}
