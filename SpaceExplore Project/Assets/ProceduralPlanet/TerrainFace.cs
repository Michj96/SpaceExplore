using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralPlanet
{
    public class TerrainFace
    {
        ShapeGenerator shapeGenerator;
        Mesh mesh;
        int resolution;
        Vector3 localUp;
        Vector3 axisA;
        Vector3 axisB;

        public TerrainFace(ShapeGenerator shapeGenerator, Mesh mesh, int resolution, Vector3 localUp)
        {
            this.shapeGenerator = shapeGenerator;
            this.mesh = mesh;
            this.resolution = resolution;
            this.localUp = localUp;

            axisA = new Vector3(localUp.y, localUp.z, localUp.x);
            axisB = Vector3.Cross(localUp, axisA);
        }

        public void ConstructMesh()
        {
            Vector3[] vertices = new Vector3[resolution * resolution];
            int[] triangles = new int[(resolution - 1) * (resolution - 1) * 6];
            int triIndex = 0;

            for (int y = 0; y < resolution; y++)
            {
                for (int x = 0; x < resolution; x++)
                {
                    int i = x + y * resolution;
                    Vector2 percent = new Vector2(x, y) / (resolution - 1);
                    Vector3 pointOnUnitCube = localUp + (percent.x - .5f) * 2 * axisA + (percent.y - .5f) * 2 * axisB;
                    Vector3 pointOnUnitSphere = pointOnUnitCube.normalized;

                    //Vector3 pointOnUnitSphere = pointOnUnitCube / Mathf.Sqrt(pointOnUnitCube.x * pointOnUnitCube.x + pointOnUnitCube.y * pointOnUnitCube.y + pointOnUnitCube.z * pointOnUnitCube.z);

                    //float x2 = pointOnUnitCube.x * pointOnUnitCube.x;
                    //float y2 = pointOnUnitCube.y * pointOnUnitCube.y;
                    //float z2 = pointOnUnitCube.z * pointOnUnitCube.z;
                    //float xp = pointOnUnitCube.x * Mathf.Sqrt(1 - (y2 + z2) / 2 + (y2 * z2) / 3);
                    //float yp = pointOnUnitCube.y * Mathf.Sqrt(1 - (z2 + x2) / 2 + (z2 * x2) / 3);
                    //float zp = pointOnUnitCube.z * Mathf.Sqrt(1 - (x2 + y2) / 2 + (x2 * y2) / 3);

                    //Vector3 pointOnUnitSphere = new Vector3(xp, yp, zp);
                    vertices[i] = shapeGenerator.CalculatePointOnPlanet(pointOnUnitSphere);

                    if (x != resolution - 1 && y != resolution - 1)
                    {
                        triangles[triIndex] = i;
                        triangles[triIndex + 1] = i + resolution + 1;
                        triangles[triIndex + 2] = i + resolution;

                        triangles[triIndex + 3] = i;
                        triangles[triIndex + 4] = i + 1;
                        triangles[triIndex + 5] = i + resolution + 1;
                        triIndex += 6;
                    }
                }
            }
            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
        }
    }
}
