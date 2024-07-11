using UnityEngine;
using UnityEngine.Assertions;

public class MeshVisual
{
    public static GameObject parent { get; set; }
    public static void Visualize(Mesh mesh, Material m = null)
    {
        Assert.IsNotNull(mesh,"Mesh cannot be null");

        GameObject g = new();
        g.AddComponent<MeshFilter>().sharedMesh = mesh;
        g.AddComponent<MeshRenderer>().material = (m != null) ? m : Material.FindAnyObjectByType<MeshRenderer>().material;
        g.transform.SetParent(parent.transform, true);
    }
}

