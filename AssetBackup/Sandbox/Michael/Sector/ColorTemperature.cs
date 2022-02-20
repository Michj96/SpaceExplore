using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorTemperature
{
    public static Color ToRGB(float temperature)
    {
        float temp = Mathf.Clamp(temperature, 1000, 40000) / 100;

        float r, g, b;

        if (temp <= 66)
        {
            r = 255;
        }
        else
        {
            r = Mathf.Clamp( (float)(329.698727446 * Math.Pow(temp - 60, -0.1332047592)), 0, 255);
        }

        if (temp <= 66)
        {
            g = Mathf.Clamp( (float)(99.4708025861 * Math.Log(temp) - 161.1195681661), 0, 255);
        }
        else
        {
            g = Mathf.Clamp((float)(288.1221695283 * Math.Pow(temp - 60, -0.0755148492)), 0, 255);
        }

        if (temp >= 66)
        {
            b = 255;
        }
        else if (temp <= 19)
        {
            b = 0;
        }
        else
        {
            b = Mathf.Clamp((float)(138.5177312231 * Math.Log(temp - 10) - 305.0447927307), 0, 255);
        }

        return new Color(r / 255, g / 255, b / 255);

        //float x = (float)(temperature / 1000.0);
        //float x2 = x * x;
        //float x3 = x2 * x;
        //float x4 = x3 * x;
        //float x5 = x4 * x;

        //float R, G, B = 0f;

        //// red
        //if (temperature <= 6600)
        //    R = 1f;
        //else
        //    R = 0.0002889f * x5 - 0.01258f * x4 + 0.2148f * x3 - 1.776f * x2 + 6.907f * x - 8.723f;

        //// green
        //if (temperature <= 6600)
        //    G = -4.593e-05f * x5 + 0.001424f * x4 - 0.01489f * x3 + 0.0498f * x2 + 0.1669f * x - 0.1653f;
        //else
        //    G = -1.308e-07f * x5 + 1.745e-05f * x4 - 0.0009116f * x3 + 0.02348f * x2 - 0.3048f * x + 2.159f;

        //// blue
        //if (temperature <= 2000f)
        //    B = 0f;
        //else if (temperature < 6600f)
        //    B = 1.764e-05f * x5 + 0.0003575f * x4 - 0.01554f * x3 + 0.1549f * x2 - 0.3682f * x + 0.2386f;
        //else
        //    B = 1f;

        //return new Color(R, G, B);
    }
}
