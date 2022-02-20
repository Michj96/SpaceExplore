using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sandbox.Michael.Sector
{
    public class Celestial : ICelestial
    {
        public string Name { get; set; }
        public float Radius { get; protected set; }
        public float Diameter { get { return Radius * 2f; } }
        public float Volume { get { return (4f / 3f) * Mathf.PI * Mathf.Pow(Radius, 3f); } }
        public float Density { get; protected set; }
        public float Mass { get { return Volume * Density; } }

        public Orbit Orbit { get; set; }

        public List<Celestial> Sattelites = new List<Celestial>();

        public float HillSphere(Celestial secondary, float d)
        {
            return d * Mathf.Pow(secondary.Mass / (3f * Mass), 1f / 3f);
        }

        public float RocheLimit(Celestial secondary)
        {
            return (Radius * Mathf.Pow(2f * (Density / secondary.Density), 1f / 3f)) + Radius;
        }
    }
}
