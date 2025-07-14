using UnityEngine;

public class Heart : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tpose"))
        {
            // Notify the GameManager that a heart has been collected
            GameManager.Instance.CollectHeart();
            Destroy(gameObject); // Destroy the heart object after collection
        }
    }
}
