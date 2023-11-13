using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    private bool inReach;
    private GameObject flashlight;
    public UGS_Analytic UGS_Analytic;
    // Start is called before the first frame update
    void Start()
    {
        inReach= false;
        flashlight = GameObject.Find("FlashLightSpot");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Reach")
        {
            //inReach = true;
            flashlight.GetComponent<FlashLight>().batteries += 1;
            inReach = false;
            Destroy(gameObject);
            UGS_Analytic.CurrentNumberOfBatteries((int)flashlight.GetComponent<FlashLight>().batteries);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inReach)
        {
            flashlight.GetComponent<FlashLight>().batteries += 1;
            inReach= false;
            Destroy(gameObject);
        }
    }
}
