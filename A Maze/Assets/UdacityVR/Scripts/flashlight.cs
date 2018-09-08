using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour {

    private float clicked = 0;
    private float clicktime = 0;
    private float clickdelay = 0.5f;

    void Update () {
        //Checking if the button or screen is pressed two times quickly
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (GetComponent<Light>().enabled == false)
                    {
                        GetComponent<Light>().enabled = true;
                    }
                    else
                    {
                        GetComponent<Light>().enabled = false;
                    }
                }
                clicked = 0;
                clicktime = 0;
            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
        }
       
    }
}
