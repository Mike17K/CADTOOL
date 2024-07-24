using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class MeshBoolean
{
    public static Vector3[] CalculateTriangleIntersection(Vector3[] v1, Vector3[] v2)
    {
        Assert.IsFalse(v1.Length == 3, "the triagle1 should have 3 verticies, not " + v1.Length);
        Assert.IsFalse(v2.Length == 3, "the triagle2 should have 3 verticies, not " + v2.Length);

        // Calculation of the triangle 2 plane
        Vector3 N2 = Vector3.Cross(v2[1] - v2[0], v2[2] - v2[0]);
        float d2 = -Vector3.Dot(N2, v2[0]);

        // calculate the progection of the points into the second plane
        float dv1x = Vector3.Dot(N2, v1[0]) + d2;
        float dv1y = Vector3.Dot(N2, v1[1]) + d2;
        float dv1z = Vector3.Dot(N2, v1[2]) + d2;

        if (dv1x < 0 && dv1y < 0 && dv1z < 0 ) return null;
        if (dv1x > 0 && dv1y > 0 && dv1z > 0 ) return null;

        // Calculation of the triangle 1 plane
        Vector3 N1 = Vector3.Cross(v1[1] - v1[0], v1[2] - v1[0]);
        float d1 = -Vector3.Dot(N2, v1[0]);

        // calculate the progection of the points into the second plane
        float dv2x = Vector3.Dot(N1, v2[0]) + d1;
        float dv2y = Vector3.Dot(N1, v2[1]) + d1;
        float dv2z = Vector3.Dot(N1, v2[2]) + d1;

        if (dv2x < 0 && dv2y < 0 && dv2z < 0) return null;
        if (dv2x > 0 && dv2y > 0 && dv2z > 0) return null;


        // NOTE: if ==0 all 3 then the triangles are co-planar

        // Now its sure that there is intersection

        Vector3 D = Vector3.Cross(N1, N2);

        float maxAxis = Mathf.Max(Mathf.Abs(D.x), Mathf.Abs(D.y), Mathf.Abs(D.z));
        Vector3 PV1 = new(); // projection of V into L (line of intersection)
        Vector3 PV2 = new(); // projection of V into L (line of intersection)
        if (Mathf.Abs(D.x) == maxAxis) {
            PV1.x = v1[0].x;
            PV1.y = v1[1].x;
            PV1.z = v1[2].x;

            PV2.x = v2[0].x;
            PV2.y = v2[1].x;
            PV2.z = v2[2].x;
        }
        if (Mathf.Abs(D.y) == maxAxis) {
            PV1.x = v1[0].y;
            PV1.y = v1[1].y;
            PV1.z = v1[2].y;

            PV2.x = v2[0].y;
            PV2.y = v2[1].y;
            PV2.z = v2[2].y;
        }
        if (Mathf.Abs(D.z) == maxAxis) {
            PV1.x = v1[0].z;
            PV1.y = v1[1].z;
            PV1.z = v1[2].z;

            PV2.x = v2[0].z;
            PV2.y = v2[1].z;
            PV2.z = v2[2].z;
        }

        float t1 = PV1[0] + (PV1[1] - PV1[0]) * dv1x / (dv1x - dv1y);
        float t2 = PV2[0] + (PV2[1] - PV2[0]) * dv2x / (dv2x - dv2y);

        Vector3[] intersectionPoints = new Vector3[2];
        intersectionPoints[0] = t1 * D;
        intersectionPoints[1] = t2 * D;

        return intersectionPoints;
    }

}
