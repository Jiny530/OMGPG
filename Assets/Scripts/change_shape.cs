using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_shape : MonoBehaviour
{
    public GameObject gaktoe;
    public Mesh[] meshs;
    private MeshFilter meshFilter;
    public Material[] material;
    Material[] mat;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.sharedMesh = meshs[Data.stick];

        mat = gaktoe.GetComponent<MeshRenderer>().materials;
        mat[0] = material[Data.stick];
        gaktoe.GetComponent<MeshRenderer>().materials = mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
