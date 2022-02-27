using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorObject
{
    public double x;
    public double y;
    public double z;

    public SectorObject(double x, double y, double z)
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

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}
