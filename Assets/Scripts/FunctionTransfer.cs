using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class FunctionTransfer : MonoBehaviour
{
    public string inputEquation;
    public GameObject inputField;
    
    public void StoreEquation()
    {
        inputEquation = inputField.GetComponent<Text>().text;
        GlobalVariables.equation = inputEquation;
    }
}