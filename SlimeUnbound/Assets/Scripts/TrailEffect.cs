using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEffect : MonoBehaviour
{
    public TrailRenderer trail;

    public void CreateTrailCollider()
    {
        MeshCollider collider = GetComponent<MeshCollider>();

        if(collider == null)
        {
            collider = gameObject.AddComponent<MeshCollider>();
        }

        Mesh mesh = new Mesh();
        trail.BakeMesh(mesh,true);
        collider.sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        CreateTrailCollider();
    }
}
