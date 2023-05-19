using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;
    public TextMeshProUGUI guiText;
    public KeyCode openKey = KeyCode.O;
    public bool opened;
    public DiamondUI diamondUI;
    public FlashLight flashlight;
    public GameObject objectInside;
    public TextMeshProUGUI keyText;
    public int numberOfKeys { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        numberOfKeys = 0;
        opened = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Reach" && inventory.NumberOfDiamonds < 10 && opened == false)
        {
            StartCoroutine(ShowMessage("You don't have enough diamonds", 2));
        }
        else if (collision.gameObject.tag == "Reach" && inventory.NumberOfDiamonds >= 10 && opened == false)
        {
            StartCoroutine(ShowMessage("Press [O] to open the box", 2));
            if (Input.GetKey(openKey) && opened == false)
            {
                inventory.NumberOfDiamonds -= 10;
                diamondUI.UpdateDiamondText(inventory);
                GetComponent<Animator>().SetBool("Open", true);
                PowerUpsInBox();
                opened = true;
            }


        }
    }

    private void PowerUpsInBox()
    {
        if (objectInside.gameObject.tag == "Battery")
        {
            flashlight.batteries += 1;
            flashlight.batteryText.text = flashlight.batteries.ToString();
        }
        else if (objectInside.gameObject.tag == "Gem")
        {
            inventory.NumberOfDiamonds += 20;
            diamondUI.UpdateDiamondText(inventory);
        }
        else if(objectInside.gameObject.tag == "Key")
        {
            numberOfKeys += 1;
            keyText.text = numberOfKeys.ToString();
        }
        Destroy(objectInside, 2f);
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        guiText.text = message;
        guiText.enabled = true;
        yield return new WaitForSeconds(delay);
        guiText.enabled = false;
    }
}
