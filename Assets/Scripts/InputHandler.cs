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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Submit();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            currentText = currentText.Remove(currentText.Length - 1);
        }



        if(currentText.Length > charLimit)
        {
            return;
        }
        currentText += Regex.Replace(Input.inputString, "[^A-Za-z -]", "");
        text.text = currentText;
    }


    //Handle submit
    //currently just empties string
    private void Submit()
    {
        currentText = "";
        text.text = "";



    }



    

}
