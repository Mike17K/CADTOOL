using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class MeshBoolean
{
    public static bool CalculateTriangleIntersection(Vector3[] t1, Vector3[] t2)
    {
        Assert.IsFalse(t1.Length == 3, "the triagle1 should have 3 verticies, not " + t1.Length);
        Assert.IsFalse(t2.Length == 3, "the triagle2 should have 3 verticies, not " + t2.Length);


        return true;
    }

}
