using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.UI;


public class TextGenAndLPM : MonoBehaviour
{
    private Boolean pressed = false, game = false;
    private float timeStart;
    public Text GenText, stats, userInp;
    public int RanChar = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called on  ce per frame
    void Update()
    {
        
        if (userInp.text.Length == GenText.text.Length && game)
        {
            game = false;
            stats.text = "DONE";

            float acc = 0.0f;
            for (int i = 0; i < userInp.text.Length; i++)
            {
                if (userInp.text.Substring(i,1).ToLower().Equals(GenText.text.Substring(i, 1).ToLower()))
                {
                    acc++;
                }
            }
            acc = Mathf.Round(acc / RanChar * 100.0f);
            stats.text = "TIME: " + Math.Round((decimal)(Time.time - timeStart), 2).ToString() + " ACCURACY : " + acc.ToString() + "%";
        }
        else if (game)
        {
            stats.text = "TIME: " + Math.Round((decimal)(Time.time - timeStart), 2).ToString();
        }

        if (OVRInput.Get(OVRInput.Button.Four) && pressed == false)
        {
            System.Random rnd = new System.Random();
            pressed = true;
            timeStart = Time.time;
            game = true;
            GenText.text = "";
            userInp.text = "";
            for (int i = 0; i < RanChar; i++) {
                GenText.text += Convert.ToChar(rnd.Next(97, 122));
            }

        }
        else if (!(OVRInput.Get(OVRInput.Button.Four))) {
            pressed = false;
        }
    }
}
