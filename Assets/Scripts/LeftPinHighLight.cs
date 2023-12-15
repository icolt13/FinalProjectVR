using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftPinHighLight : MonoBehaviour
{
    public GameObject[] PieSecs, Pro, Opp;
    public Material Selected, Unselected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject selPie = null;
        float x = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x;
        float y = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y;
        float angle = Mathf.Atan2(y, x) / Mathf.PI * 180;
        for (int i = 0; i < PieSecs.Length; i++)
        {
            PieSecs[i].GetComponent<MeshRenderer>().material = Unselected;
        }


        if (angle <= 112.5f && angle > 67.5f)
        {
            PieSecs[0].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[0];

        }
        else if (angle <= 67.5f && angle > 22.5f)
        {
            PieSecs[1].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[1];
        }
        else if (angle <= 22.5f && angle > -22.5f && x != 0)
        {
            PieSecs[2].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[2];
        }
        else if (angle <= -22.5f && angle > -67.5f)
        {
            PieSecs[3].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[3];
        }
        else if (angle <= -67.5f && angle > -112.5f)
        {
            PieSecs[4].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[4];
        }
        else if (angle <= -112.5f && angle > -157.5f)
        {
            PieSecs[5].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[5];
        }
        else if (angle <= -157.5f || angle > 157.5f)
        {
            PieSecs[6].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[6];
        }
        else if (angle <= 157.5f && angle > 112.5)
        {
            PieSecs[7].GetComponent<MeshRenderer>().material = Selected;
            selPie = Pro[7];
        }
        if (selPie != null)
        {
            for (int i = 0; i < selPie.GetComponent<TextMesh>().text.Length; i++)
            {
                Opp[i].GetComponent<TextMesh>().text = selPie.GetComponent<TextMesh>().text[i].ToString();
            }
        }
    }
}
