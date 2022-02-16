using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Sandbox.Michael.Sector
{
    public class Celestial : ICelestial
    {
        public float Radius { get; protected set; }

        public float Diameter { get { return Radius * 2; } }
        public float Density { get; }

        public OrbitDetail Orbit { get; protected set; }

        public List<Celestial> Sattelites;

    }
}
