using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestMeshVisualizer : MonoBehaviour
{
    private bool visualizedMesh1;
    private void VisualizeMesh1()
    {
        Mesh mesh = new Mesh();
        mesh.SetVertices(new Vector3[3]
        {
            new(0f,0f, 1f),
            new(1f,0f, 1f),
            new(1f,1f, 0f)
        }, 0, 3);
        mesh.SetTriangles(new int[3]
        {
            0, 1, 2
        },0);
        mesh.RecalculateNormals();

        visualizedMesh1 = true;
    }

    void Start()
    {
        MeshVisual.parent = this.gameObject;
    }

    void Update()
    {
        if (!visualizedMesh1) VisualizeMesh1();
    }
}
