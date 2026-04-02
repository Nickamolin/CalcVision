using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoDFunctionTransfer : MonoBehaviour
{
    public string inputEquation;
    public InputField inputField;

    public void StoreEquation()
    {
        inputEquation = inputField.text;
        TwoDGlobalVariables.equation = inputEquation;
    }
}
