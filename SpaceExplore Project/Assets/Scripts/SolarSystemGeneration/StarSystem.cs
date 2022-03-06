using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class StarSystem
    {
        const int SIZE_STAR_MIN = 4000;
        const int SIZE_STAR_MAX = 6000;
        const int SIZE_PLANET_MIN = 1000;
        const int SIZE_PLANET_MAX = 3000;

        const int SYSTEM_ORBIT_MIN = 10000;
        const int SYSTEM_ORBIT_MAX = 200000;

        public Star star { get; }

        public StarSystem()
        {
            star = GenerateStar();

            int planets = Random.Range(0, 7);
            float remainOrbit = SYSTEM_ORBIT_MAX;

            for (int i = 0; i < planets; i++)
            {
                float d = Random.Range(SYSTEM_ORBIT_MIN, (remainOrbit / (planets - i)));
                remainOrbit -= d;
                star.sattelites.Add(GeneratePlanet(star, d + (SYSTEM_ORBIT_MAX - remainOrbit)));
            }
        }

        private Star GenerateStar()
        {
            int radius = Random.Range(SIZE_STAR_MIN, SIZE_STAR_MAX + 1);
            float density = Random.Range(1200, 1500);
            return new Star(radius, density);
        }

        private Planet GeneratePlanet(Star star, float distance)

        {
            int radius = Random.Range(SIZE_PLANET_MIN, SIZE_PLANET_MAX + 1);
            return new Planet(radius, Random.Range(3000, 6000), new OrbitSettings(distance));
        }

        public void GenerateMoon()
        {

        }
    }

    public class Celestial
    {
        public float Radius;
        public float Diameter { get { return Radius * 2; } }

        public float Density;

        public float Mass;

        public OrbitSettings Orbit;

        public List<Celestial> sattelites = new List<Celestial>();
    }

    public class Planet : Celestial
    {
        public Planet(float radius, float density)
        {
            Radius = radius;
            Density = density;
        }

        public Planet(float radius, float density, OrbitSettings orbit)
        {
            Radius = radius;
            Density = density;
            Orbit = orbit;
        }
    }

    public class Star : Celestial
    {
        public Star(float radius, float density)
        {
            Radius = radius;
            Density = density;
        }
    }

    public class OrbitSettings
    {
        public float Radius;

        public OrbitSettings(float radius)
        {
            Radius = radius;
        }
    }