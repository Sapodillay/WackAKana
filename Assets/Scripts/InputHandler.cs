using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class InputHandler : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI text;

    [SerializeField]
    string currentText;

    [SerializeField]
    public int charLimit;

    [SerializeField]
    public KanaManager kanaManager;

    private void Update()
    {
        //Submit the text to the KanaManager.cs Submit() function
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Submit();
            return;
        }
        //Handle removing text
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            currentText = currentText.Remove(currentText.Length - 1);
        }


        //Check that the text isn't over the character limit
        if(currentText.Length > charLimit)
        {
            return;
        }
        //Only add alpha characters
        currentText += Regex.Replace(Input.inputString, "[^A-Za-z -]", "");
        //Add text to the display
        text.text = currentText;
    }


    /// <summary>
    /// Empties the string and calls the KanaManager.cs Submit function with the text
    /// </summary>
    private void Submit()
    {
        string tmpText = currentText;
        currentText = "";
        text.text = "";
        kanaManager.Submit(tmpText);
    }



    

}
