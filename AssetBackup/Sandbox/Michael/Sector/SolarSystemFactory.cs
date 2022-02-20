using Assets.Sandbox.Michael.Sector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SolarSystemFactory
{
    public static SolarSystem New()
    {
        SolarSystem ss = new SolarSystem();
        ss.Name = "Nonsolis System";

        ss.star = new Star(GenerateMainStarClass());
        GeneratePlanets(ss.star);

        return ss;
    }

    public void GenerateStar()
    {

    }

    public static void GeneratePlanets(Star star)
    {
        int amount = Random.Range(10, 30);
        //List<Celestial> planets = new List<Celestial>();

        #region Planet Spawning
        List<Celestial> unAssigned = new List<Celestial>();
        for (int i = 0; i <= amount; i++)
        {
            Planet p = new Planet(Scale.LoghRandom(0.1f, 5f) * SolarSystemUnit.PlanetRadius, Random.Range(3f,6f));
            p.Orbit = new Orbit(Scale.LoghRandom(star.Radius, star.Radius * 100));
            Debug.Log(star.RocheLimit(p));
            if (p.Orbit.Radius > star.RocheLimit(p))
            {
                unAssigned.Add(p);
            }
            
        }
        unAssigned = unAssigned.OrderByDescending(x => x.Mass).ToList();
        #endregion

        List<Celestial> toRemove = new List<Celestial>();
        Celestial p_working;
        while (unAssigned.Count > 0)
        {
            p_working = unAssigned.First();
            unAssigned.Remove(p_working);
            float hill = star.HillSphere(p_working, p_working.Orbit.Radius);

            foreach (Planet p in unAssigned)
            {
                if (hill > Mathf.Abs(p_working.Orbit.Radius - p.Orbit.Radius))
                {
                    Debug.Log("In the Sphere!");
                    p_working.Sattelites.Add(p);
                    toRemove.Add(p);
                }
                else
                {
                    Debug.Log("Not a SPhere object");
                }
            }

            toRemove.ForEach(planet => unAssigned.Remove(planet));

            star.Sattelites.Add(p_working);
            //foreach (Planet p in unAssigned)
            //{
            //    float hill = star.HillSphere(p_working, p_working.Orbit.Radius);

            //    if (star.HillSphere(p_working, p_working.Orbit.Radius) > Mathf.Abs(p_working.Orbit.Radius - p.Orbit.Radius))
            //    {
            //        if (Mathf.Abs(p_working.Orbit.Radius - p.Orbit.Radius) > p_working.RocheLimit(p))
            //        {
            //            p_working.Sattelites.Add(p);
            //        }
            //        toRemove.Add(p);
            //    }
            //}

            //toRemove.ForEach(planet => unAssigned.Remove(planet));
        }


        #region Moon Assignment
        //Planet pWorking;
        //while (unSorted.Count > 0)
        //{
        //    pWorking = (Planet)unSorted.First();
        //    float hillSphere = star.HillSphere(pWorking, pWorking.Orbit.Radius);

        //    foreach(Planet pSub in unSorted.Skip(1))
        //    {
        //        if (hillSphere > Mathf.Abs(pWorking.Orbit.Radius - pSub.Orbit.Radius))
        //        {
        //            //Debug.Log("In the sphere");
        //            pWorking.Sattelites.Add(pSub);
        //        }
        //        else
        //        {
        //            //Debug.Log("Not the sphere");
        //        }
        //    }
        //    pWorking.Sattelites.ForEach(planet => unSorted.Remove(planet));

        //    star.Sattelites.Add(pWorking);
        //    unSorted.Remove(pWorking);
        //}
        #endregion

        #region Naming
        int pNumber = 1;
        foreach (Planet p in star.Sattelites.OrderBy(x => x.Orbit.Radius))
        {
            p.Name = "Nonsolis " + pNumber;
            int mNumber = 1;
            foreach (Planet monn in p.Sattelites)
            {
                monn.Name = $"Nonsolis {pNumber} Moon {mNumber}";
                mNumber++;
            }
            pNumber++;
        }
        #endregion
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
