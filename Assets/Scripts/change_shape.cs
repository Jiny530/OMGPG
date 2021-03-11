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
        
        if (Data.stick < 0)
        {
            //원본 유지
        }
        else //옷갈아입히기
        {

            this.transform.localScale = new Vector3(5f, 5f, 5f);
            this.transform.localEulerAngles = new Vector3(0, 10, 90);

            meshFilter = GetComponent<MeshFilter>();
            meshFilter.sharedMesh = meshs[Data.stick];

            mat = gaktoe.GetComponent<MeshRenderer>().materials;
            mat[0] = material[Data.stick];
            gaktoe.GetComponent<MeshRenderer>().materials = mat;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
