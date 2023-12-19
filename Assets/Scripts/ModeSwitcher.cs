using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    private Boolean Pinwheel = true, pressed = false;
    public GameObject LPin, RPin, LCon, Rcon, Keyboard;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Three) && pressed == false)
        {
            pressed = true;
            Pinwheel = !Pinwheel;
            LPin.SetActive(Pinwheel); 
            RPin.SetActive(Pinwheel);
            LCon.SetActive(!Pinwheel);
            Rcon.SetActive(!Pinwheel);
            Keyboard.SetActive(!Pinwheel);


        }
        else if (!OVRInput.Get(OVRInput.Button.Three) && pressed == true)
        {
            pressed = false;
        }
    }
}