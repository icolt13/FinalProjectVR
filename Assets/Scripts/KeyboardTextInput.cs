using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardTextInput : MonoBehaviour
{
    public Text userInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            userInput.text += "W";
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            userInput.text = userInput.text.Substring(0, userInput.text.Length - 1);
        }
    }
}
