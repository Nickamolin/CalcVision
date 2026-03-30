using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
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
        graphResolution = 1.0;
        colorChoice = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColorOption(int C)
    {
        colorChoice = C;
    }
}
