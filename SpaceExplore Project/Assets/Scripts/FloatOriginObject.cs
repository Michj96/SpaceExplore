using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOriginObject
{
    public double x;
    public double y;
    public double z;
    public Vector3double Location { get { return new Vector3double(x, y, z); } }

    public FloatOriginObject(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public void UpdateByVelocity(Vector3 Velocity)
    {
        x += Velocity.x;
        y += Velocity.y;
        z += Velocity.z;
    }

    public void UpdateByLocation(Vector3double Location)
    {
        x = Location.x;
        y = Location.y;
        z = Location.z;
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}
