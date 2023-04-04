using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    //[SerializeField] GameObject FlashlightLight;
    //private bool FlashlightAcrive = false;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    FlashlightLight.gameObject.SetActive(false);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.F))
    //    {
    //        if (FlashlightAcrive == false)
    //        {
    //            FlashlightLight.gameObject.SetActive(true);
    //            FlashlightAcrive = true;
    //        }
    //        else
    //        {
    //            FlashlightLight.gameObject.SetActive(false);
    //            FlashlightAcrive = false;
    //        }
    //    }
    //}
    public Light light;
    public TMP_Text text;
    public TMP_Text batteryText;
    public float lifetime = 100;
    public float batteries = 0;

    private bool on;
    private bool off;

    void Start()
    {
        text.text = "Flashlight : " + lifetime + " %";
        light = GetComponent<Light>();
        off = true;
        light.enabled = false;
    }

    void Update()
    {
        text.text = lifetime.ToString("0") + " % of flashlight";
        if(batteries == 1)
        {
            batteryText.text = batteries.ToString() + " Battery";
        }
        if(batteries != 1)
        {
            batteryText.text = batteries.ToString() + " Batteries";
        }

        if (Input.GetKeyDown(KeyCode.F) && off)
        {
            light.enabled = true;
            on = true;
            off = false;
        }
        else if (Input.GetKeyDown(KeyCode.F) && on)
        {
            light.enabled = false;
            on = false; 
            off = true;
        }

        if(on)
        {
            lifetime -= 1 * Time.deltaTime;
        }
        if (lifetime <= 0)
        {
            light.enabled = false;
            on = false;
            off = true;
            lifetime = 0;
        }
        if(lifetime >= 100)
        {
            lifetime = 100;
        }

        if(Input.GetKeyDown(KeyCode.R) && batteries >= 1)
        {
            batteries -= 1;
            lifetime += 50;
        }

        if (Input.GetKeyDown(KeyCode.R) && batteries == 0)
        {
            return;
        }

        if(batteries <= 0)
        {
            batteries = 0;
        }

    }
}
