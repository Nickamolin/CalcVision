using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;
using System;
using System.Linq.Expressions;
using System.Collections.Specialized;
using System.Diagnostics;

public class TwoDDrawGraph : MonoBehaviour
{
    public double uDomain;
    public double res;

    public ParticleSystem plot;

    Vector3[] temp = new Vector3[40401];

    ParticleSystem.Particle[] points = new ParticleSystem.Particle[40401];

    public void Draw()
    {
        int vertCount = 0;
        uDomain = TwoDGlobalVariables.universalDomain;
        res = 0.005*uDomain;

        org.mariuszgromada.math.mxparser.Argument x = new org.mariuszgromada.math.mxparser.Argument("x");
        org.mariuszgromada.math.mxparser.Argument y = new org.mariuszgromada.math.mxparser.Argument("y");

        string localEq = TwoDGlobalVariables.equation;

        org.mariuszgromada.math.mxparser.Expression rel = new org.mariuszgromada.math.mxparser.Expression(localEq, x, y);

        int indexOfSpace = localEq.IndexOf('=');

        string leftSide = localEq.Substring(0, indexOfSpace);
        string rightSide = localEq.Substring(indexOfSpace + 1);

        UnityEngine.Debug.Log(leftSide);
        UnityEngine.Debug.Log(rightSide);

        org.mariuszgromada.math.mxparser.Expression leftEx;
        org.mariuszgromada.math.mxparser.Expression rightEx;

        leftEx = new org.mariuszgromada.math.mxparser.Expression(leftSide, x, y);
        rightEx = new org.mariuszgromada.math.mxparser.Expression(rightSide, x, y);

        for (double i = -200; i <= 200; i++)
        {
            for (double j = -200; j <= 200; j++)
            {
                x.setArgumentValue(i * res);
                y.setArgumentValue(j * res);

                double dif = leftEx.calculate() - rightEx.calculate();

                if (dif > (-0.015*uDomain) && dif < (0.015*uDomain))
                {
                    temp[vertCount] = new Vector3((float)(i * 0.05), (float)(j * 0.05), 0);
                    vertCount++;

                }
            }
        }

        Vector3[] vertices = new Vector3[vertCount];

        for (int i = 0; i < vertCount; i++)
        {
            vertices[i] = temp[i];
        }

        //UnityEngine.Debug.Log(vertCount);

        plot.Emit(vertCount);

        plot.GetParticles(points);

        for (int i = 0; i < vertCount; i++)
        {
            points[i].velocity = Vector3.zero;
            points[i].angularVelocity = 0.0f;
            points[i].rotation = 0.0f;
            points[i].startSize = 0.25f;
            points[i].startLifetime = 100000f;
            points[i].position = vertices[i];

            int colorNum = TwoDGlobalVariables.colorChoice;

            switch (colorNum)
            {
                case 0:
                    points[i].startColor = Color.red;
                    break;
                case 1:
                    points[i].startColor = Color.green;
                    break;
                case 2:
                    points[i].startColor = Color.blue;
                    break;
                default:
                    break;
            }


        }

        plot.SetParticles(points, vertCount);
    }
}
