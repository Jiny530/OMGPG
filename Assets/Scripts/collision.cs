using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class collision : MonoBehaviour
{
    public AudioSource[] pg_sound;  //pg1, pg2, pg3, pg4, pg5, pg6, pg7, pg8, pg9, pg10, pg11, pg12, pg13, pg14, pg15, pg16;
    //public GameObject[] pyeongyeong;  //PG1, PG2, PG3, PG4, PG5, PG6, PG7, PG8, PG9, PG10, PG11, PG12, PG13, PG14, PG15, PG16;
    public string[] tags;
    public static int hitCheck;

    public void OnCollisionEnter(Collision col)
    {   
        for(int i=0;i<16;i++){
            if (col.collider.CompareTag(tags[i])){
                pg_sound[i].PlayOneShot(pg_sound[i].clip);
                hitCheck = i;
                break;
            }
        }
    }
}
