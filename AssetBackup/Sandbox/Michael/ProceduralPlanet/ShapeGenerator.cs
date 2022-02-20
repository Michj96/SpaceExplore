using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Procedural
{
    public class ShapeGenerator
    {
        ShapeSetting settings;

        public ShapeGenerator(ShapeSetting settings)
        {
            this.settings = settings;
        }

        public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
        {
            return pointOnUnitSphere * settings.planetRadius;
        }
    }
}