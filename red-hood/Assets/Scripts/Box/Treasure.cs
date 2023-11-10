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
    public GameObject player;
    public Player numberOfKeys;
    public UGS_Analytic UGS_Analytic;

    // Start is called before the first frame update
    void Start()
    {
        opened = false;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 2 && inventory.NumberOfDiamonds < 10 && opened == false)
        {
            StartCoroutine(ShowMessage("You don't have enough diamonds", 2));
        }
        else if (distance < 2 && inventory.NumberOfDiamonds >= 10 && opened == false) {
        StartCoroutine(ShowMessage("Press [O] to open the box", 2));
            if (pressedKey())
            {
                inventory.NumberOfDiamonds -= 10;
                diamondUI.UpdateDiamondText(inventory);
                GetComponent<Animator>().SetBool("Open", true);
                PowerUpsInBox();
                opened = true;
            }
        }
    }
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Reach" && inventory.NumberOfDiamonds < 10 && opened == false)
    //    {
    //        StartCoroutine(ShowMessage("You don't have enough diamonds", 2));
    //    }
    //    else if (collision.gameObject.tag == "Reach" && inventory.NumberOfDiamonds >= 10 && opened == false)
    //    {
    //        StartCoroutine(ShowMessage("Press [O] to open the box", 2));
    //        if (pressedKey() == true && opened == false)
    //        {
    //            inventory.NumberOfDiamonds -= 10;
    //            diamondUI.UpdateDiamondText(inventory);
    //            GetComponent<Animator>().SetBool("Open", true);
    //            PowerUpsInBox();
    //            opened = true;
    //        }
    //    }
    //}

    private void PowerUpsInBox()
    {
        if (objectInside.gameObject.tag == "Battery")
        {
            flashlight.batteries += 1;
            flashlight.batteryText.text = flashlight.batteries.ToString();
            UGS_Analytic.CurrentNumberOfBatteries((int)flashlight.batteries);
        }
        else if (objectInside.gameObject.tag == "Gem")
        {
            inventory.NumberOfDiamonds += 20;
            diamondUI.UpdateDiamondText(inventory);
            UGS_Analytic.CurrentNumberOfDiamonds(inventory.NumberOfDiamonds);
        }
        else if(objectInside.gameObject.tag == "Key")
        {
            numberOfKeys.numberOfKeys += 1;
            keyText.text = numberOfKeys.numberOfKeys.ToString();
            UGS_Analytic.CurrentNumberOfKeys(numberOfKeys.numberOfKeys);
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

    private bool pressedKey()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            return true;
        }
        return false;
    }
}
