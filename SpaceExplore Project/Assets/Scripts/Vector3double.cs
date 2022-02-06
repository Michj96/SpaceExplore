using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Vector3double
{
    public double x;
    public double y;
    public double z;

    public Vector3double(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static double Distance(Vector3double a, Vector3double b)
    {
        return Math.Pow(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2) + Math.Pow(b.z - a.z, 2), 0.5);
    }
}
