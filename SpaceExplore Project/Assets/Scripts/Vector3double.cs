using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Vector3double
{
    public double x;
    public double y;
    public double z;

    static readonly Vector3double zeroVector = new Vector3double(0F, 0F, 0F);
    static readonly Vector3double oneVector = new Vector3double(1F, 1F, 1F);
    static readonly Vector3double upVector = new Vector3double(0F, 1F, 0F);
    static readonly Vector3double downVector = new Vector3double(0F, -1F, 0F);
    static readonly Vector3double leftVector = new Vector3double(-1F, 0F, 0F);
    static readonly Vector3double rightVector = new Vector3double(1F, 0F, 0F);
    static readonly Vector3double forwardVector = new Vector3double(0F, 0F, 1F);
    static readonly Vector3double backVector = new Vector3double(0F, 0F, -1F);
    static readonly Vector3double positiveInfinityVector = new Vector3double(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
    static readonly Vector3double negativeInfinityVector = new Vector3double(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

    // Shorthand for writing @@Vector3double(0, 0, 0)@@
    public static Vector3double zero { get { return zeroVector; } }
    // Shorthand for writing @@Vector3double(1, 1, 1)@@
    public static Vector3double one { get { return oneVector; } }
    // Shorthand for writing @@Vector3double(0, 0, 1)@@
    public static Vector3double forward { get { return forwardVector; } }
    public static Vector3double back {  get { return backVector; } }
    // Shorthand for writing @@Vector3double(0, 1, 0)@@
    public static Vector3double up {  get { return upVector; } }
    public static Vector3double down {  get { return downVector; } }
    public static Vector3double left {  get { return leftVector; } }
    // Shorthand for writing @@Vector3double(1, 0, 0)@@
    public static Vector3double right {  get { return rightVector; } }
    // Shorthand for writing @@Vector3double(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity)@@
    public static Vector3double positiveInfinity {  get { return positiveInfinityVector; } }
    // Shorthand for writing @@Vector3double(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity)@@
    public static Vector3double negativeInfinity {  get { return negativeInfinityVector; } }

    public static Vector3double operator +(Vector3double a, Vector3double b) { return new Vector3double(a.x + b.x, a.y + b.y, a.z + b.z); }
    public static Vector3double operator -(Vector3double a, Vector3double b) { return new Vector3double(a.x - b.x, a.y - b.y, a.z - b.z); }
    public static Vector3double operator +(Vector3double a, Vector3 b) { return new Vector3double(a.x + b.x, a.y + b.y, a.z + b.z); }
    public static Vector3double operator -(Vector3double a, Vector3 b) { return new Vector3double(a.x - b.x, a.y - b.y, a.z - b.z); }

    public Vector3double(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3double(Vector3 vector)
    {
        this.x = vector.x;
        this.y = vector.y;
        this.z = vector.z;
    }

    public static double Distance(Vector3double a, Vector3double b)
    {
        return Math.Pow(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2) + Math.Pow(b.z - a.z, 2), 0.5);
    }
}
