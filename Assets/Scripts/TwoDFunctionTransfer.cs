using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwoDFunctionTransfer : MonoBehaviour
{
    public string inputEquation;
    public GameObject inputField;

    public void StoreEquation()
    {
        inputEquation = inputField.GetComponent<Text>().text;
        TwoDGlobalVariables.equation = inputEquation;
    }
}
