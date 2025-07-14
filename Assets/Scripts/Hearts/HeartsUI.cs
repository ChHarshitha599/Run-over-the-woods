using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    public Image[] heartImages; // Drag and drop the heart images into this array in the Inspector

    void Start()
    {
        // Hide all heart images initially
        foreach (var heartImage in heartImages)
        {
            heartImage.enabled = false;
        }
    }

    public void UpdateHearts(int heartsCollected)
    {
        // Display collected hearts based on the heartsCollected parameter
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < heartsCollected)
            {
                heartImages[i].enabled = true; // Enable the heart image if collected
            }
            else
            {
                heartImages[i].enabled = false; // Disable the heart image if not collected
            }
        }
    }
}
