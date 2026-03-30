using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;
using System.Runtime.InteropServices;
using System.Linq.Expressions;

public class mxpTest : MonoBehaviour
{
    public string grabEquation;

    // Start is called before the first frame update
    void Start()
    {
        Function F = new Function("F(x) = x ^ 3 + 5 * x + 3");
        org.mariuszgromada.math.mxparser.Expression e1 = new org.mariuszgromada.math.mxparser.Expression("F(3)", F);
        TextMesh textObject = GameObject.Find("New Text").GetComponent<TextMesh>();
        double n = e1.calculate();
        textObject.text = "bruh " + n.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        grabEquation = GlobalVariables.equation;
        Function F = new Function(grabEquation);
        org.mariuszgromada.math.mxparser.Expression e1 = new org.mariuszgromada.math.mxparser.Expression("F(3)", F);
        TextMesh textObject = GameObject.Find("New Text").GetComponent<TextMesh>();
        double n = e1.calculate();
        textObject.text = "bruh " + n.ToString();
    }
}
