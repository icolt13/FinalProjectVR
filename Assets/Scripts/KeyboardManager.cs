using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class KeyboardManager : MonoBehaviour
{
    public static KeyboardManager instance;
    public Button shiftButton;
    public Button deleteButton;
    public Button spaceButton;
    public Text inputField;

    private bool isShifted = false;
    private Image shiftButtonImage;

    private void Awake()
    {
        instance = this;
        shiftButton.onClick.AddListener(Shifted);
        deleteButton.onClick.AddListener(Delete);
        spaceButton.onClick.AddListener(Space);
        shiftButtonImage = shiftButton.gameObject.GetComponent<Image>();
    }

    private void Shifted()
    {
        isShifted = !isShifted;
        if (isShifted == true)
        {
            shiftButtonImage.color = Color.yellow;
        }
        else
        {
            shiftButtonImage.color = Color.white;
        }
    }

    private void Delete()
    {
        int inputLength = inputField.text.Length - 1;
        inputField.text = inputField.text.Substring(0, inputLength);
    }

    private void Space()
    {
        inputField.text += " ";
    }
}
