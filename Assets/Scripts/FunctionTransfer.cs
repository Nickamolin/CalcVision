using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FunctionTransfer : MonoBehaviour
{
    public string inputEquation;
    public InputField inputField;
    
    public void StoreEquation()
    {
        inputEquation = inputField.text;
        GlobalVariables.equation = inputEquation;
    }
}