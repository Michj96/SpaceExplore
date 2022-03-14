using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOriginManager : MonoBehaviour
{
    public float ScalingStart;
    private float ScalingEnd;

    FloatOriginObject _originObject;
    List<FloatOriginObject> _objectList = new List<FloatOriginObject>();

    // Start is called before the first frame update
    void Start()
    {
        ScalingEnd = ScalingStart + 30000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(FloatOriginObject sectorObject)
    {
        _objectList.Add(sectorObject);
    }

    public void RemoveObject(FloatOriginObject floatObject)
    {
        if (_objectList.Contains(floatObject))
        {
            _objectList.Remove(floatObject);
        }
    }

    public void SetOrigin(FloatOriginObject originObject)
    {
        if (_originObject != null)
        {
            Debug.Log("Origin Object was already set. Was overriden (Only one origin object per scene.)");
        }
        _originObject = originObject;
    }

    public Vector3 LocationInScene(FloatOriginObject sectorObject)
    {
        double distance = DistanceInWorld(sectorObject);

        if (distance > ScalingStart)
        {
            Vector3double pDistance = PointAtDistance(_originObject.Location, sectorObject.Location, ScalingStart);
            return new Vector3((float)(_originObject.x - pDistance.x), (float)(_originObject.y - pDistance.y), (float)(_originObject.z - pDistance.z));
        }
        else
        {
            return new Vector3((float)(sectorObject.x - _originObject.x), (float)(sectorObject.y - _originObject.y), (float)(sectorObject.z - _originObject.z));
        }
    }

    public Vector3 ScaleInSceneMultiplier(FloatOriginObject sectorObject)
    {
        double distance = DistanceInWorld(sectorObject);

        float mStart = 1;
        float mEnd = 0;

        if (distance > ScalingStart)
        {
            float a = (float)((mStart - mEnd) / Math.Log(ScalingStart / ScalingEnd));
            float b = (float)Math.Exp((mEnd * Math.Log(ScalingStart) - mStart * Math.Log(ScalingEnd)) / (mStart - mEnd));
            float scale = Mathf.Clamp01( (float)(a * Math.Log(b * distance)) );
            return new Vector3(scale,scale,scale);
        }
        else
        {
            return new Vector3(1,1,1);
        }
    }

    public double DistanceInWorld(FloatOriginObject sectorObject)
    {
        return Vector3double.Distance(sectorObject.Location, _originObject.Location);
    }

    public Vector3double PointAtDistance(Vector3double origin, Vector3double destination, double distance)
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
}
