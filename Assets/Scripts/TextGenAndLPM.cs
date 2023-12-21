using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextGenAndLPM : MonoBehaviour
{
    private Boolean pressed = false, game = false;
    private float timeStart;
    public Text GenText, stats, userInp, KeyboardTime, KeyboardAcc, PinwheelTime, PinwheelAcc;
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
            decimal seconds;
            for (int i = 0; i < userInp.text.Length; i++)
            {
                if (userInp.text.Substring(i,1).ToLower().Equals(GenText.text.Substring(i, 1).ToLower()))
                {
                    acc++;
                }
            }
            acc = Mathf.Round(acc / RanChar * 100.0f);
            seconds = Math.Round((decimal)(Time.time - timeStart), 2);
            stats.text = "TIME: " + seconds.ToString() + " ACCURACY : " + acc.ToString() + "%";
            UpdateScoreboard(seconds, acc);
        }
        else if (game)
        {
            decimal seconds;
            seconds = Math.Round((decimal)(Time.time - timeStart), 2);
            stats.text = "TIME: " + seconds.ToString();
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
        else if (!OVRInput.Get(OVRInput.Button.Four))
        {
            pressed = false;
        }
    }

    void UpdateScoreboard(decimal newSeconds, float newAcc)
    {
        bool pinwheelActive = ModeSwitcher.Pinwheel;
        if (pinwheelActive)
        {
            decimal pinwheelSecValue = Convert.ToDecimal(PinwheelTime.text);
            float pinwheelAccValue = float.Parse(PinwheelAcc.text);

            if (newAcc > pinwheelAccValue)
            {
                PinwheelTime.text = newSeconds.ToString();
                PinwheelAcc.text = newAcc.ToString();
            }
            if ((newAcc == pinwheelAccValue) && newSeconds < pinwheelSecValue)
            {
                KeyboardTime.text = newSeconds.ToString();
            }
        }
        else
        {
            decimal keyboardSecValue = Convert.ToDecimal(KeyboardTime.text);
            float keyboardAccValue = float.Parse(KeyboardAcc.text);

            if (newAcc > keyboardAccValue)
            {
                KeyboardTime.text = newSeconds.ToString();
                KeyboardAcc.text = newAcc.ToString();
            }
            if ((newAcc == keyboardAccValue) && newSeconds < keyboardSecValue)
            {
                KeyboardTime.text = newSeconds.ToString();
            }
        }
    }
}
