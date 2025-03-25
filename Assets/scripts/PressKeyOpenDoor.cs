using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class PressKeyOpenDoor : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject AnimeObject;
    public GameObject ThisTrigger;
    public AudioSource DoorOpenSound;
    public bool Action = false;
    public bool hasKey = false;
    public TMP_Text messageText; // Use TMP_Text for TextMeshPro support

    void Start()
    {
        Instruction.SetActive(false);
        if (messageText != null)
            messageText.text = ""; // Clear the text at the start
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
        if (messageText != null)
            messageText.text = ""; // Clear message when leaving
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Action)
        {
            if (hasKey) // If player has the key, open the door
            {
                Instruction.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DoorOpen");
                ThisTrigger.SetActive(false);
                DoorOpenSound.Play();
                Action = false;
                if (messageText != null)
                    messageText.text = ""; // Clear message
            }
            else
            {
                if (messageText != null)
                    messageText.text = "You need a key to open the door!";
            }
        }
    }

    public void CollectKey()
    {
        hasKey = true;
    }

    public void DropKey()
    {
        hasKey = false;
    }
}
