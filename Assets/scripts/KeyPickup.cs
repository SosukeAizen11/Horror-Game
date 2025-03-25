using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioClip dropSound;
    public PressKeyOpenDoor doorScript; // Reference to the door script
    public GameObject keyInHand; // The key object in the player's hand
    public Transform dropPosition; // Where the key will drop when released

    private bool hasKey = false; // Track if the player has the key

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Press F to pick up or drop
        {
            if (!hasKey)
            {
                PickupKey();
            }
            else
            {
                DropKey();
            }
        }
    }

    void PickupKey()
    {
        hasKey = true;
        doorScript.CollectKey(); // Give the player the key

        keyInHand.SetActive(true); // Show key in hand
        gameObject.SetActive(false); // Hide key from the world

        if (pickupSound)
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
    }

    void DropKey()
    {
        hasKey = false;
        doorScript.hasKey = false; // Remove key from player’s inventory

        keyInHand.SetActive(false); // Hide key in hand
        gameObject.SetActive(true); // Make key reappear in the world
        transform.position = dropPosition.position; // Move key to drop position

        if (dropSound)
            AudioSource.PlayClipAtPoint(dropSound, transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasKey)
        {
            // The player can pick up the key when nearby
            PickupKey();
        }
    }
}
