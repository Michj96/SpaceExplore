using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DistanceUnit
{
    public class Unit
    {

    }
    
    public static double Convert(double distance)
    {
        if (distance > 9460730472580800) // Lightyear
        {
            return distance / 9460730472580800;
        }
        if (distance > 149597870700)
        {
            return distance / 149597870700;
        }
        if (distance > 1000)
        {
            return distance / 1000;
        }
        else
        {
            return distance;
        }
    }
}
