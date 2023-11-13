using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public UGS_Analytic UGS_Analytic;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if(playerInventory != null)
        {
            playerInventory.DiamondCollected();
            Destroy(this.gameObject);
            UGS_Analytic.CurrentNumberOfDiamonds(playerInventory.NumberOfDiamonds);
            //destroygameObject.SetActive(false);
        }
    }
}
