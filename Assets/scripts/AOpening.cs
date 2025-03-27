using UnityEngine;
using System.Collections;
using TMPro; // For TextMeshPro

using StarterAssets; // Correct namespace for the new FirstPersonController

public class AOpening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;

    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<TMPro.TMP_Text>().text = "Will have to get out of this house ASAP!";
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<TMPro.TMP_Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
