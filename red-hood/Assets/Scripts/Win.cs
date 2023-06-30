using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject normalCanvas;
    public GameObject winCanvas;
    public Player keysOfObject;
    public TextMeshProUGUI guiText;
    // Start is called before the first frame update
    void Start()
    {
        winCanvas.SetActive(false);
        normalCanvas.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Reach") && keysOfObject.numberOfKeys == 4)
        {
            Time.timeScale = 0;
            normalCanvas.SetActive(false);
            winCanvas.SetActive(true);
        }
        else if(collision.gameObject.CompareTag("Reach") && keysOfObject.numberOfKeys < 4)
        {
            StartCoroutine(ShowMessage("You don't have four keys", 2f));
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        guiText.text = message;
        guiText.enabled = true;
        yield return new WaitForSeconds(delay);
        guiText.enabled = false;
    }
}
