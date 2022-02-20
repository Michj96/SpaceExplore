using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLocationController : MonoBehaviour
{
    public GameObject PlayerShip;

    public List<SpaceObject> LocationObjects;

    public SpaceObject PlayerObject;

    public class SpaceObject
    {
        public double x;
        public double y;
        public double z;

        public SpaceObject(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = new SpaceObject(0,0,0);
        LocationObjects = new List<SpaceObject>();
        LocationObjects.Add(new SpaceObject(0, 0, 50000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        foreach (SpaceObject locObject in LocationObjects)
        {

        }
    }

    public static Vector3double PointAtDistance(Vector3double origin, Vector3double destination, double distance)
    {
        double cx = origin.x;
        double cy = origin.y;
        double cz = origin.z;

        double px = origin.x;
        double py = origin.y;
        double pz = origin.z;

        double vx = destination.x - px;
        double vy = destination.y - py;
        double vz = destination.z - pz;

        double A = vx * vx + vy * vy + vz * vz;
        double B = 2.0 * (px * vx + py * vy + pz * vz - vx * cx - vy * cy - vz * cz);
        double C = px * px - 2 * px * cx + cx * cx + py * py - 2 * py * cy + cy * cy +
                   pz * pz - 2 * pz * cz + cz * cz - distance * distance;

        // discriminant
        double D = B * B - 4 * A * C;

        // D < 0

        double t1 = (-B - Math.Sqrt(D)) / (2.0 * A);

        Vector3double solution1 = new Vector3double(origin.x * (1 - t1) + t1 * destination.x,
                                                    origin.y * (1 - t1) + t1 * destination.y,
                                                    origin.z * (1 - t1) + t1 * destination.z);

        return solution1;
    }

    //public static Point3D[] FindLineSphereIntersections(Point3D linePoint0, Point3D linePoint1, Point3D circleCenter, double circleRadius)
    //{
    //    // http://www.codeproject.com/Articles/19799/Simple-Ray-Tracing-in-C-Part-II-Triangles-Intersec

    //    double cx = circleCenter.X;
    //    double cy = circleCenter.Y;
    //    double cz = circleCenter.Z;

    //    double px = linePoint0.X;
    //    double py = linePoint0.Y;
    //    double pz = linePoint0.Z;

    //    double vx = linePoint1.X - px;
    //    double vy = linePoint1.Y - py;
    //    double vz = linePoint1.Z - pz;

    //    double A = vx * vx + vy * vy + vz * vz;
    //    double B = 2.0 * (px * vx + py * vy + pz * vz - vx * cx - vy * cy - vz * cz);
    //    double C = px * px - 2 * px * cx + cx * cx + py * py - 2 * py * cy + cy * cy +
    //               pz * pz - 2 * pz * cz + cz * cz - circleRadius * circleRadius;

    //    // discriminant
    //    double D = B * B - 4 * A * C;

    //    if (D < 0)
    //    {
    //        return new Point3D[0];
    //    }

    //    double t1 = (-B - Math.Sqrt(D)) / (2.0 * A);

    //    Point3D solution1 = new Point3D(linePoint0.X * (1 - t1) + t1 * linePoint1.X,
    //                                     linePoint0.Y * (1 - t1) + t1 * linePoint1.Y,
    //                                     linePoint0.Z * (1 - t1) + t1 * linePoint1.Z);
    //    if (D == 0)
    //    {
    //        return new Point3D[] { solution1 };
    //    }

    //    double t2 = (-B + Math.Sqrt(D)) / (2.0 * A);
    //    Point3D solution2 = new Point3D(linePoint0.X * (1 - t2) + t2 * linePoint1.X,
    //                                     linePoint0.Y * (1 - t2) + t2 * linePoint1.Y,
    //                                     linePoint0.Z * (1 - t2) + t2 * linePoint1.Z);

    //    // prefer a solution that's on the line segment itself

    //    if (Math.Abs(t1 - 0.5) < Math.Abs(t2 - 0.5))
    //    {
    //        return new Point3D[] { solution1, solution2 };
    //    }

    //    return new Point3D[] { solution2, solution1 };
    //}
}
