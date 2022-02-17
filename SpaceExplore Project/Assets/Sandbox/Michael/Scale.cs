using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Scale
{
    public float LoghRandom(float lowest, float highest)
    {
        float[] p1 = { 1, lowest };
        float[] p2 = { 10, highest };

        float a = Mathf.Pow((p2[1] / p1[1]), 1 / (p2[0] - p1[0]));
        float b = p1[2] / Mathf.Pow(a, p1[0]);

        return b * Mathf.Pow(a, Random.Range(1f, 10f));
    }
}
