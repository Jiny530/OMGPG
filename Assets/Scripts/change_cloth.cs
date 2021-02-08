using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class change_cloth : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject[] pyeongyeong;
    public GameObject[] frames;
    public Material[] material;
    Material[] mat;

    void Start()
    {   
        if (Data.stone < 0)
        {
            //원본 유지
        }
        else //옷갈아입히기
        {
            for (int i=0;i<16;i++){
                mat = pyeongyeong[i].GetComponent<MeshRenderer>().materials;
                mat[0] = material[Data.stone];
                pyeongyeong[i].GetComponent<MeshRenderer>().materials = mat;
            }
        }

        if (Data.frame < 0)
        {
            //원본 유지
        }
        else //옷갈아입히기
        {
            for (int i=0;i<16;i++){
                mat = frames[i].GetComponent<MeshRenderer>().materials;
                mat[0] = material[Data.frame];
                frames[i].GetComponent<MeshRenderer>().materials = mat;
            }
        }
    }

}
