using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public static class Helpers {
    public static Mesh MeshOfBounds(Bounds b) {
        Assert.IsFalse(b == null, "Bounds can't be null");

        Mesh mesh = new Mesh();

        //POSITIVE Z
        //1,1,1
        Vector3 v1 = new(b.size.x + b.extents.x,b.size.y + b.extents.y,b.size.z + b.extents.z);

        //-1,1,1
        Vector3 v2 = new(b.size.x - b.extents.x,b.size.y + b.extents.y,b.size.z + b.extents.z);


        //-1,-1,1
        Vector3 v3 = new(b.size.x - b.extents.x,b.size.y - b.extents.y,b.size.z + b.extents.z);


        //1,-1,1
        Vector3 v4 = new(b.size.x + b.extents.x,b.size.y - b.extents.y,b.size.z + b.extents.z);

        //NEGATIVE Z
        //1,1,-1
        Vector3 v5 = new(b.size.x + b.extents.x,b.size.y + b.extents.y,b.size.z - b.extents.z);

        //-1,1,-1
        Vector3 v6 = new(b.size.x - b.extents.x,b.size.y + b.extents.y,b.size.z - b.extents.z);

        //-1,-1,-1
        Vector3 v7 = new(b.size.x - b.extents.x,b.size.y - b.extents.y,b.size.z - b.extents.z);


        //1,-1,-1
        Vector3 v8 = new(b.size.x + b.extents.x,b.size.y - b.extents.y,b.size.z - b.extents.z);

        Vector3[] verticies = new Vector3[8]
        {
            v1,v2,v3,v4,v5,v6,v7,v8
        };

        int[] triangles = new int[36]
        {
            0,1,2, // z side
            2,3,0,
            0,3,7, // x side
            7,4,0,
            7,6,5, // -z side
            5,4,7,
            2,1,5, // -x side
            5,6,2,
            0,4,5, // y side
            5,1,0,
            2,6,7, // -y side
            7,3,2
        };


        mesh.SetVertices(verticies);
        mesh.SetTriangles(triangles, 0);

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();

        return mesh;
    }

    public static Bounds BoundsOfMesh(Mesh mesh)
    {
        Assert.IsFalse(mesh == null, "The mesh cannot be null");
        Assert.IsFalse(mesh.vertices.Length <= 0, "The mesh verticies cannot be empty");

        Vector3 min = mesh.vertices[0];
        Vector3 max = mesh.vertices[0];
        foreach (var t in mesh.vertices)
        {
            min = Vector3.Min(min, t);
            max = Vector3.Max(max, t);
        }
        return new Bounds((max + min) / 2, max - min);
    }
}
