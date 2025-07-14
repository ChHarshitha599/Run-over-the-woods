using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;

    // Property to track hearts collected
    public int HeartsCollected { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Initialize other GameManager logic
        DontDestroyOnLoad(gameObject);
    }

    // Method to collect hearts (example)
    public void CollectHeart()
    {
        HeartsCollected++;
        Debug.Log("Heart collected! Total hearts: " + HeartsCollected);
    }

    // Additional GameManager logic as needed
}
