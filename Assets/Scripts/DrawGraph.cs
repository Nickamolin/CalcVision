using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using org.mariuszgromada.math.mxparser;
using System;
using System.Linq.Expressions;
using System.Collections.Specialized;
using System.Diagnostics;

public class DrawGraph : MonoBehaviour
{
    public double uDomain;
    public double res;

    public ParticleSystem plot;

    Vector3[] temp = new Vector3[1030301];

    ParticleSystem.Particle[] points = new ParticleSystem.Particle[1030301];

    public void Draw()
    {
        int vertCount = 0;
        uDomain = GlobalVariables.universalDomain;
        res = 0.02*uDomain;

        org.mariuszgromada.math.mxparser.Argument x = new org.mariuszgromada.math.mxparser.Argument("x");
        org.mariuszgromada.math.mxparser.Argument y = new org.mariuszgromada.math.mxparser.Argument("y");
        org.mariuszgromada.math.mxparser.Argument z = new org.mariuszgromada.math.mxparser.Argument("z");

        string localEq = GlobalVariables.equation;

        org.mariuszgromada.math.mxparser.Expression rel = new org.mariuszgromada.math.mxparser.Expression(localEq, x, y, z);

        int indexOfSpace = localEq.IndexOf('=');

        string leftSide = localEq.Substring(0, indexOfSpace);
        string rightSide = localEq.Substring(indexOfSpace + 1);

        UnityEngine.Debug.Log(leftSide);
        UnityEngine.Debug.Log(rightSide);

        org.mariuszgromada.math.mxparser.Expression leftEx;
        org.mariuszgromada.math.mxparser.Expression rightEx;

        leftEx = new org.mariuszgromada.math.mxparser.Expression(leftSide, x, y, z);
        rightEx = new org.mariuszgromada.math.mxparser.Expression(rightSide, x, y, z);

        for (double i = -50; i <= 50; i++)
        {
            for (double j = -50; j <= 50; j++)
            {
                for (double k = -50; k <= 50; k++)
                {
                    x.setArgumentValue(i*res);
                    y.setArgumentValue(j*res);
                    z.setArgumentValue(k*res);

                    double dif = leftEx.calculate() - rightEx.calculate();

                    if (dif > (-0.015*uDomain) && dif < (0.015*uDomain))
                    {
                        temp[vertCount] = new Vector3((float)(i * 0.2), (float)(j * 0.2), (float)(k * 0.2));
                        vertCount++;
                        //UnityEngine.Debug.Log(uDomain + " " + res);
                        //UnityEngine.Debug.Log((float)(i * res) + " " + (float)(j * res) + " " + (float)(k * res));
                    }
                }
            }
        }

        Vector3[] vertices = new Vector3[vertCount];

        for (int i = 0; i < vertCount; i++)
        {
            vertices[i] = temp[i];
        }

        UnityEngine.Debug.Log(vertCount);

        plot.Emit(vertCount);
        
        plot.GetParticles(points);

        for (int i = 0; i < vertCount; i++)
        {
            //
            points[i].velocity = Vector3.zero;
            points[i].angularVelocity = 0.0f;
            points[i].rotation = 0.0f;
            points[i].startSize = 0.5f;
            points[i].startLifetime = 100000f;
            points[i].position = vertices[i];

            

            int colorNum = GlobalVariables.colorChoice;

            switch (colorNum)
            {
                case 0:
                    points[i].startColor = Color.black;
                    break;
                case 1:
                    points[i].startColor = Color.grey;
                    break;
                case 2:
                    Vector3 maxD = new Vector3(10, 10, 10);
                    float dist = (float)(vertices[i].magnitude / maxD.magnitude);
                    points[i].startColor = new Color(1 - dist, (float)Math.Abs(0.5 - dist), dist, 1);
                    break;
                case 3:
                    points[i].startColor = new Color((float)((10.0 + vertices[i].x) / 20.0), (float)((10.0 + vertices[i].y) / 20.0), (float)((10.0 + vertices[i].z) / 20.0), 1);
                    break;
                default:
                    break;
            }

            
        }

        plot.SetParticles(points, vertCount);
    }
}
