using Assets.Sandbox.Michael.Sector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Celestial
{
    public enum Class
    {
        O,
        B,
        A,
        F,
        G,
        K,
        M
    }

    Dictionary<Class, float[]> _sizeRanges = new Dictionary<Class, float[]>
    {
        { Class.O, new float[] { 6.6f, 30f } },
        { Class.B, new float[] { 1.81f, 6.6f } },
        { Class.A, new float[] { 1.4f, 1.8f } },
        { Class.F, new float[] { 1.15f, 1.4f } },
        { Class.G, new float[] { 0.96f, 1.15f } },
        { Class.K, new float[] { 0.7f, 0.96f } },
        { Class.M, new float[] { 0.1f, 0.7f } }
    };

    public Class StarClass { get; private set; }

    public float SizeMultiplier { get; private set; }

    public float SurfaceTemperature { get { return (4394 * SizeMultiplier + 1163); } }

    public Star(Class c)
    {
        StarClass = c;
        SizeMultiplier = Random.Range(_sizeRanges[c][0], _sizeRanges[c][1]);
        Radius = SizeMultiplier * 100;
    }

    public Star()
    {

    }
}
