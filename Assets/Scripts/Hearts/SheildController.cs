using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float shieldDuration = 10f; // Duration of the shield in seconds

    private GameObject player; // Reference to the player object
    private bool isShieldActive = false; // Flag to track if shield is active

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("tpose"); // Find the player object
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tpose") && !isShieldActive)
        {
            ActivateShield();
            Destroy(gameObject); // Destroy the shield pickup object after pickup
        }
    }

    void ActivateShield()
    {
        isShieldActive = true;
        // TODO: Implement visual feedback such as enabling a shield effect around the player

        // Disable collision with obstacles (example)
        Physics.IgnoreLayerCollision(player.layer, LayerMask.NameToLayer("Rocks (6)"), true);

        // Start a timer to deactivate the shield after shieldDuration seconds
        Invoke(nameof(DeactivateShield), shieldDuration);
    }

    void DeactivateShield()
    {
        isShieldActive = false;
        // TODO: Disable the shield visual effect

        // Enable collision with obstacles again (example)
        Physics.IgnoreLayerCollision(player.layer, LayerMask.NameToLayer("Rocks (6)"), false);
    }
}
