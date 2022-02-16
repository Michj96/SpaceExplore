using Assets.Sandbox.Michael.Sector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemFactory
{
    public static SolarSystem New()
    {
        SolarSystem ss = new SolarSystem();
        ss.Name = "Testdromeda";

        ss.star = new Star(GenerateMainStarClass());


        //ss.Planets = GeneratePlanets();

        return ss;
    }

    public void GenerateStar()
    {

    }

    public static List<Planet> GeneratePlanets()
    {
        int amount = Random.Range(0, 30);
        List<Planet> planets = new List<Planet>();

        for (int i = 0; i <= amount; i++)
        {
            float size = Mathf.Pow(1.5f, Random.Range(1f, 7f));
            Planet p = new Planet(size);
            //Temp
            //p.OriginDist = Mathf.Pow(2f, Random.Range(1f, 7f));

            planets.Add(p);
        }

        return planets;
    }

    public static Star.Class GenerateMainStarClass()
    {
        int weight = Random.Range(0, 101);

        if (weight <= 35)
        {
            return Star.Class.M;
        }
        else if (weight <= 55)
        {
            return Star.Class.K;
        }
        else if (weight <= 70)
        {
            return Star.Class.G;
        }
        else if (weight <= 82)
        {
            return Star.Class.F;
        }
        else if (weight <= 92)
        {
            return Star.Class.A;
        }
        else if (weight <= 97)
        {
            return Star.Class.B;
        }
        else
        {
            return Star.Class.O;
        }
    }
}
