using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Transform collectibles;
    [SerializeField] private GameObject endTrigger;

    public static event Action<float> OnRingCollect;
    public static event Action OnTopReached;
    public static event Action OnFinishReached;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            OnRingCollect?.Invoke(10);
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
            OnTopReached?.Invoke();
        }
        if (other.CompareTag("Finish"))
        {
            OnFinishReached?.Invoke();
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


}
