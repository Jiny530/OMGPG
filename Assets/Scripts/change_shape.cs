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

    public GameObject[] colliders;

    void Start()
    {
        
        if (Data.stick < 0)
        {
            //원본 유지
        }
        else //옷갈아입히기
        {
            colliders[Data.stick].SetActive(true);
            Collider col = gaktoe.GetComponent<Collider>();
            col.enabled = false;

            this.transform.localPosition = new Vector3(0.1f, 0f, 0f);
            this.transform.localEulerAngles = new Vector3(90, 10, 90);
            if (Data.stick == 2) //아이스크림이면 좀더 얇게 바꿈
            {
                this.transform.localScale = new Vector3(5f, 7f, 5f);
            }
            else
            {
                this.transform.localScale = new Vector3(7f, 7f, 7f);
            }

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
