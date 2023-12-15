using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RightPinHighLight : MonoBehaviour
{
    public GameObject[] PieSecs, textObjs;
    public Material Selected, Unselected;
    private Boolean triggered, aPress, bPress;
    public Text userInput;

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        aPress = false;
        bPress = false; 
    }

    // Update is called once per frame
    void Update()
    {
        String selPie = null;
        float x = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
        float y = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;
        float angle = Mathf.Atan2(y, x) / Mathf.PI * 180;
        for (int i = 0; i < PieSecs.Length; i++)
        {
            PieSecs[i].GetComponent<MeshRenderer>().material = Unselected;
        }

        if (angle <= 112.5f && angle > 67.5f)
        {
            PieSecs[0].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[0].GetComponent<TextMesh>().text;
        }
        else if (angle <= 67.5f && angle > 22.5f)
        {
            PieSecs[1].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[1].GetComponent<TextMesh>().text;
        }
        else if (angle <= 22.5f && angle > -22.5f && x != 0)
        {
            PieSecs[2].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[2].GetComponent<TextMesh>().text;

        }
        else if (angle <= -22.5f && angle > -67.5f)
        {
            PieSecs[3].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[3].GetComponent<TextMesh>().text;

        }
        else if (angle <= -67.5f && angle > -112.5f)
        {
            PieSecs[4].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[4].GetComponent<TextMesh>().text;

        }
        else if (angle <= -112.5f && angle > -157.5f)
        {
            PieSecs[5].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[5].GetComponent<TextMesh>().text;
        }
        else if (angle <= -157.5f || angle > 157.5f)
        {
            PieSecs[6].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[6].GetComponent<TextMesh>().text;
        }
        else if (angle <= 157.5f && angle > 112.5)
        {
            PieSecs[7].GetComponent<MeshRenderer>().material = Selected;
            selPie = textObjs[7].GetComponent<TextMesh>().text;
        }
        if (!triggered && OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.3)
        {
            userInput.text += selPie;
            triggered = true;
        }
        else if (triggered && OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) < 0.2)
        {
            triggered = false; 
        }
        if (OVRInput.Get(OVRInput.Button.One) && aPress == false)
        {
            aPress = true;
            userInput.text += " ";
        }
        else if (!OVRInput.Get(OVRInput.Button.One) && aPress == true)
        {
            aPress = false; 
        }
        if (OVRInput.Get(OVRInput.Button.Two) && bPress == false)
        {
            bPress = true;
            userInput.text = userInput.text.Substring(0, userInput.text.Length - 1);
        }
        else if (!OVRInput.Get(OVRInput.Button.Two) && bPress == true)
        {
            bPress = false;
        }
        
    }
}
