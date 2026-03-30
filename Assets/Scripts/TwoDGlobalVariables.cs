using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDGlobalVariables : MonoBehaviour
{
    public static string equation;
    public static double universalDomain;
    public static double graphResolution;
    public static int colorChoice;

    // Start is called before the first frame update
    void Start()
    {
        equation = " ";
        universalDomain = 10.0;
        colorChoice = 0;
    }

    public void SetColorOption(int C)
    {
        colorChoice = C;
    }
}
