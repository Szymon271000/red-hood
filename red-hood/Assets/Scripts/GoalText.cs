using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalText : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI guiText;

    void Start()
    {
        StartCoroutine(ShowMessage("Find all four keys and get the house of grandma", 2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        guiText.enabled = true;
        guiText.text = message;
        yield return new WaitForSeconds(delay);
        guiText.enabled = false;
    }
}
